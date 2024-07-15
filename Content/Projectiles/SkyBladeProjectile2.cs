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
            ProjectileID.Sets.TrailingMode[Type] = 0;
            ProjectileID.Sets.TrailCacheLength[Type] = 30;
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
            Projectile.extraUpdates = 3;
            Projectile.ownerHitCheck = true;
            Projectile.light = 0.5f;
        }

        public Player Owner => Main.player[Projectile.owner];
        public override void AI()
        {
            if (Projectile.soundDelay == 0)
            {
                Projectile.soundDelay = 80;
                SoundEngine.PlaySound(SoundID.Item9, Projectile.position);
            }

            Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Clentaminator_Cyan, 0, 0, 0, default, 0.75f);
            dust.noGravity = true;
            dust.velocity *= 0.5f;

            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver4;
        }

        public override bool PreDraw(ref Color lightColor)
        {            
            Texture2D texture = TextureAssets.Projectile[Type].Value;
            Color drawColor = Color.White with { A = 0 };
            Color drawColorTrail = drawColor;

            for (int j = 0; j < Projectile.oldPos.Length; j++)
            {
                Vector2 drawPos = Projectile.oldPos[j] - Main.screenPosition + texture.Size() / 2f + new Vector2(0f, Projectile.gfxOffY);                
                
                drawColorTrail *= 0.75f;

                Main.EntitySpriteDraw(texture, drawPos, null, drawColorTrail, Projectile.rotation, texture.Size() / 2f, Projectile.scale * 1.5f - j / (float) Projectile.oldPos.Length, SpriteEffects.None, 0);                
                Main.EntitySpriteDraw(texture, drawPos, null, drawColorTrail, Projectile.rotation, texture.Size() / 2f, Projectile.scale - j / (float) Projectile.oldPos.Length, SpriteEffects.None, 0);                
            }

            Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, drawColor * 0.5f, Projectile.rotation, texture.Size() / 2f, Projectile.scale * 1.25f, SpriteEffects.None, 0);
            Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, drawColor, Projectile.rotation, texture.Size() / 2f, Projectile.scale, SpriteEffects.None, 0);
            return false;
        }

        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.NPCHit3, Projectile.position);
            for (int i = 0; i < 20; i++)
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Clentaminator_Cyan, 0, 0, 0, default, 1f);
                dust.noGravity = true;
                dust.velocity *= 4f;
            }
        }
    }
}
