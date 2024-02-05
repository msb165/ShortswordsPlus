using Microsoft.Xna.Framework;
using Terraria.Audio;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;

namespace MoreShortswords.Content.Projectiles
{
    public class DayAbominationProjectile3 : DayAbominationProjectile2
    {
        public override string Texture => "MoreShortswords/Content/Projectiles/DayAbominationProjectile2";

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Daylight's Abomination");
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 10;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }

        public override Color? GetAlpha(Color lightColor) => new Color(255, 127, 39, 43);

        public override void SetDefaults()
        {
            base.SetDefaults();
        }

        public override void AI()
        {
            base.AI();           
        }
        public override bool PreDraw(ref Color lightColor)
        {
            SpriteBatch spriteBatch = Main.spriteBatch;
            Texture2D glowTexture = (Texture2D)ModContent.Request<Texture2D>("MoreShortswords/Assets/DayGlow");

            Color drawColorGlowSecond = new(255, 201, 14, 49);
            Vector2 drawOrigin = new(glowTexture.Width / 2, glowTexture.Height / 2);

            for (int i = 0; i < Projectile.oldPos.Length; i++)
            {
                float num = 10 - i;
                Color drawColor = Projectile.GetAlpha(lightColor) * ((Projectile.oldPos.Length - i) / (float)Projectile.oldPos.Length);
                drawColor *= num / (ProjectileID.Sets.TrailCacheLength[Projectile.type] * 1.5f);

                spriteBatch.Draw(glowTexture, (Projectile.oldPos[i] - Main.screenPosition) + new Vector2(Projectile.width / 2f, Projectile.height / 2f) + new Vector2(0f, Projectile.gfxOffY), null, drawColor, Projectile.rotation, drawOrigin, (Projectile.scale * 1.5f) - i / (float)Projectile.oldPos.Length, SpriteEffects.None, 0);
                spriteBatch.Draw(glowTexture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, drawColor, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }

            spriteBatch.Draw(glowTexture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, drawColorGlowSecond, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            return false;
        }

        public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.NPCHit3, Projectile.position);
            for (int numOfParticles = 0; numOfParticles < 16; numOfParticles++)
            {
                int dustExplode = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Pixie, Projectile.oldVelocity.X, Projectile.oldVelocity.Y, 255, default, 1.2f);
                Main.dust[dustExplode].noGravity = true;
                Dust dustExplodeAlt = Main.dust[dustExplode];
                dustExplodeAlt.scale *= 1.25f;
                dustExplodeAlt.velocity *= 0.5f;
                Projectile.rotation = Projectile.velocity.ToRotation();
            }
        }

    }
}
