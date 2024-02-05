using Terraria.GameContent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using MoreShortswords.Content.Dusts;

namespace MoreShortswords.Content.Projectiles
{
    public class SkyBladeProjectile2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0; 
        }
        public override void SetDefaults()
        {
            Projectile.width = 32;
            Projectile.height = 32;                     
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.friendly = true;
            Projectile.timeLeft = 200;
            Projectile.aiStyle = -1;
            Projectile.alpha = 0;
            Projectile.DamageType = DamageClass.MeleeNoSpeed;            
            Projectile.extraUpdates = 1;
            Projectile.ownerHitCheck = true;
            Projectile.light = 0.5f;
            //AIType = ProjectileID.SkyFracture;
        }

        public Player Owner => Main.player[Projectile.owner];
        public override void AI()
        {
            base.AI();
            if (Projectile.soundDelay == 0)
            {
                Projectile.soundDelay = 25;
                SoundEngine.PlaySound(SoundID.Item9, Projectile.position);
            }
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver4;
        }

        public override bool PreDraw(ref Color lightColor)
        {            
            Texture2D texture = TextureAssets.Projectile[ModContent.ProjectileType<SkyBladeProjectile2>()].Value;
            Color drawColor = Color.LightCyan with { A = 0 };
            Color drawColorTrail = drawColor;

            for (int j = 0; j < Projectile.oldPos.Length; j++)
            {
                Vector2 drawPos = Projectile.oldPos[j] - Main.screenPosition + texture.Size() / 2f + new Vector2(0f, Projectile.gfxOffY);                
                
                drawColorTrail *= 0.5f;

                Main.EntitySpriteDraw(texture, drawPos, null, drawColorTrail, Projectile.rotation, texture.Size() / 2f, Projectile.scale - j / (float) Projectile.oldPos.Length, SpriteEffects.None, 0);
                
            }

            Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, drawColor, Projectile.rotation, texture.Size() / 2f, Projectile.scale, SpriteEffects.None, 0);
            return false;
        }

        public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.NPCHit3, Projectile.position);
            for (int i = 0; i < 16; i++)
            {
                Dust dustExplode = Main.dust[Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), Projectile.velocity.X, Projectile.velocity.Y, 0, Color.Cyan, 1f)];
                dustExplode.scale *= 1.1f;
            }
        }
    }
}
