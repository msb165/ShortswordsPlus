using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MoreShortswords.Content.Projectiles
{
    public class DayAbominationProjectile2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Daylight's Abomination");
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 10;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }
        public override void SetDefaults()
        {       
            Projectile.penetrate = 2;
            Projectile.friendly = true;
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.timeLeft = 200;
            Projectile.Opacity = 0.5f;
            Projectile.light = 0.5f;
        }

        public override void AI()
        {
            int fireDust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.GemTopaz, Projectile.velocity.X, Projectile.velocity.Y, 100, default, 1.5f);
            Main.dust[fireDust].noGravity = true;
            Dust secFireDust = Main.dust[fireDust];
            secFireDust.alpha = 100;
            secFireDust.velocity *= 0.3f;            

            Projectile.rotation = Projectile.velocity.ToRotation();


            if (Projectile.ai[1] == 0f)
            {
                Projectile.ai[1] = 1f;
                SoundEngine.PlaySound(SoundID.Item8, Projectile.position);
            }
        }

        public override Color? GetAlpha(Color lightColor) => new Color(255, 127, 39, 43);


        public override bool PreDraw(ref Color lightColor)
        {
            SpriteBatch spriteBatch = Main.spriteBatch;
            Texture2D glowTexture = (Texture2D)ModContent.Request<Texture2D>("MoreShortswords/Assets/DayGlow");

            Color drawColorGlowSecond = new(255, 242, 14, 49);
            Vector2 drawOrigin = glowTexture.Size() / 2f; 
            

            for (int i = 0; i < Projectile.oldPos.Length; i++)
            {
                float num = 10 - i;
                Color drawColor = Projectile.GetAlpha(lightColor) * ((Projectile.oldPos.Length - i) / (float)Projectile.oldPos.Length);
                drawColor *= num / (ProjectileID.Sets.TrailCacheLength[Projectile.type] * 1.5f);

                spriteBatch.Draw(glowTexture, (Projectile.oldPos[i] - Main.screenPosition) + Projectile.Size / 2f + new Vector2(0f, Projectile.gfxOffY), null, drawColor, Projectile.rotation, drawOrigin, (Projectile.scale * 1.5f) - i / (float) Projectile.oldPos.Length, SpriteEffects.None, 0);
                spriteBatch.Draw(glowTexture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, drawColor, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }

            spriteBatch.Draw(glowTexture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, drawColorGlowSecond, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            return false;
        }

        public override void OnKill(int timeLeft)
        {
            if (Projectile.ai[0] == 1f)
            {
                return;
            }

            SoundEngine.PlaySound(SoundID.NPCHit3, Projectile.position);
            for (int numOfParticles = 0; numOfParticles < 16; numOfParticles++) 
            { 
                int dustExplode = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.GemTopaz, Projectile.oldVelocity.X, Projectile.oldVelocity.Y, 100, default, 1.2f);
                Main.dust[dustExplode].noGravity = true;
                Dust dustExplodeAlt = Main.dust[dustExplode];
                dustExplodeAlt.scale *= 1.25f;
                dustExplodeAlt.velocity *= 0.5f;
                Projectile.rotation = Projectile.velocity.ToRotation();
            }       

            for (int j = 0; j < 2; j++)
            {
                Vector2 newVelocity = Vector2.Normalize(Projectile.velocity) * 14f;
                float[] value = {0f, 5f, -5f};
                newVelocity = newVelocity.RotatedBy(value[j] * MathHelper.PiOver2 - MathHelper.PiOver4);
                Projectile.NewProjectile(Projectile.GetSource_Death(), new Vector2(Projectile.position.X + (10f * Projectile.direction), Projectile.position.Y + 10f), newVelocity, ModContent.ProjectileType<DayAbominationProjectile2>(), Projectile.damage / 3, 4f, Projectile.owner, 1f);                 
            }          
            
        }

    }
}
