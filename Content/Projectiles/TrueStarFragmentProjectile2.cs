using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace MoreShortswords.Content.Projectiles
{
    public class TrueStarFragmentProjectile2 : ModProjectile
    {
        public override string Texture => "MoreShortswords/Content/Projectiles/StarProj";

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Type] = 20;
            ProjectileID.Sets.TrailingMode[Type] = 3;
        }

        public override void SetDefaults()
        {
            Projectile.Size = new(32);
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.alpha = 50;
            Projectile.scale = 0.8f;
            Projectile.tileCollide = false;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 20;
            Projectile.aiStyle = -1;
            Projectile.extraUpdates = 1;
        }

        public override void AI()
        {
            if (Projectile.soundDelay == 0)
            {
                Projectile.soundDelay = 40;
                SoundEngine.PlaySound(SoundID.Item105, Projectile.position);
            }

            Projectile.tileCollide = Projectile.position.Y > Projectile.ai[1];

            if (Main.rand.NextBool(10))
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.YellowStarDust, 0f, 0f, 150, default, 1.2f);
            }
            if (Main.rand.NextBool(20))
            {
                Gore.NewGore(Projectile.GetSource_FromThis(), Projectile.position, Projectile.velocity * 0.2f, Main.rand.Next(16, 18));
            }
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2 * Projectile.spriteDirection;
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = (Texture2D)ModContent.Request<Texture2D>(Texture);
            Texture2D glowTexture = (Texture2D)ModContent.Request<Texture2D>("MoreShortswords/Assets/GlowSphere");

            Color drawColor = Color.White;
            Color drawColorGlow = new(255, 255, 128, 0);

            Vector2 origin = Projectile.Size / 2f;

            SpriteEffects spriteEffects = SpriteEffects.None;
            if (Projectile.direction == -1)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }

            for (int j = 0; j < Projectile.oldPos.Length; j++)
            {
                Vector2 drawPos = Projectile.oldPos[j] - Main.screenPosition + Projectile.Size / 2f + new Vector2(0f, Projectile.gfxOffY);
                
                drawColorGlow *= 0.5f;
                drawColor *= 0.6f;

                Main.EntitySpriteDraw(glowTexture, drawPos, glowTexture.Frame(), drawColorGlow, Projectile.rotation, glowTexture.Size() / 2f, Projectile.scale - j / (float) Projectile.oldPos.Length, SpriteEffects.None, 0);
                Main.EntitySpriteDraw(texture, drawPos, texture.Frame(), drawColor, Projectile.rotation, origin, Projectile.scale - j / (float) Projectile.oldPos.Length, spriteEffects, 0);
            }
            
            Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), texture.Frame(), Color.White, Projectile.rotation, origin, Projectile.scale, spriteEffects, 0);            
            return false;
        }

        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
            for (int i = 0; i < 10; i++)
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.YellowTorch, 0, 0, 150, default, 2f);
                dust.noGravity = true;
                dust.velocity *= 4f;
            }
            Gore gore = Gore.NewGoreDirect(Projectile.GetSource_Death(), Projectile.position, Vector2.Zero, Main.rand.Next(16, 18));
            gore.velocity *= 2f;
        }
    }
}
