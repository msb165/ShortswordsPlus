using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MoreShortswords.Content.Dusts;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoreShortswords.Content.Projectiles
{
    public class HybridShortProjectile2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {            
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 15;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }
        public override void SetDefaults()
        {
            Projectile.aiStyle = -1;
            Projectile.tileCollide = false;
            Projectile.Size = new(48);
            Projectile.alpha = 0;
            Projectile.timeLeft = 400;
            Projectile.penetrate = 3;
            Projectile.friendly = true;
        }

        public override void AI()
        {
            base.AI();            

            Projectile.ai[0] += 1f;

            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver4 * Projectile.spriteDirection;

            if (Projectile.ai[0] == 60f)
            {
                Projectile.ai[0] = 0f;
                Projectile.velocity.Y *= -1;
            }

            Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), 0f, 0f, 0, Color.HotPink, 1.5f);
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = TextureAssets.Projectile[Type].Value;
            Vector2 drawOrigin = texture.Size() / 2f;
            Color drawColor = Color.White;
            Color drawColor2 = drawColor;

            for (int i = 0; i < Projectile.oldPos.Length; i++)
            {               
                drawColor2 *= 0.75f;
                Main.EntitySpriteDraw(texture, (Projectile.oldPos[i] - Main.screenPosition) + drawOrigin + new Vector2(0f, Projectile.gfxOffY), null, drawColor2, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }

            Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, drawColor, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            return false;
        }

        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.NPCHit3, Projectile.position);
            for (int i = 0; i < 10; i++)
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), 0f, 0f, 0, Color.HotPink, 1.5f);
            }
        }
    }
}
