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
        public override string Texture => "MoreShortswords/Content/Projectiles/StarFragmentProjectile";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Star Fragment");
        }

        public override void SetDefaults()
        {
            Projectile.width = 40;
            Projectile.height = 40;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.alpha = 50;
            Projectile.scale = 0.8f;
            Projectile.tileCollide = false;
            Projectile.ArmorPenetration = 25;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 20;
        }

        public override void AI()
        {
            if (Projectile.soundDelay == 0)
            {
                Projectile.soundDelay = 20 + Main.rand.Next(40);
                SoundEngine.PlaySound(SoundID.Item105, Projectile.position);
            }

            if (Projectile.position.Y > Projectile.ai[1])
            {
                Projectile.tileCollide = true;
            }

            if (Projectile.localAI[0] == 0f)
            {
                Projectile.localAI[0] = 1f;
            }

            Projectile.alpha += (int)(25f * Projectile.localAI[0]);

            if (Projectile.alpha > 200)
            {
                Projectile.alpha = 200;
                Projectile.localAI[0] = -1f;
            }
            if (Projectile.alpha < 0)
            {
                Projectile.alpha = 0;
                Projectile.localAI[0] = 1f;
            }

            Projectile.light = 0.9f;
            if (!Main.dedServ)
            {
                if (Main.rand.NextBool(10))
                {
                    Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Enchanted_Pink, Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f, 150, default, 1.2f);
                }
                if (Main.rand.NextBool(20))
                {
                    Gore.NewGore(Projectile.GetSource_FromThis(), Projectile.position, new Vector2(Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f), Main.rand.Next(16, 18));
                }
            }

            Projectile.rotation += Projectile.velocity.ToRotation() * Projectile.spriteDirection;
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = (Texture2D)ModContent.Request<Texture2D>(Texture);

            Texture2D trailFire = TextureAssets.Extra[91].Value;
            Rectangle trailFrame = trailFire.Frame();
            Color drawColor = Projectile.GetAlpha(lightColor);
            Color colorHotPink = Color.HotPink * 0.3f;
            colorHotPink.A = 0;

            int frameHeight = texture.Height / Main.projFrames[Projectile.type];
            int startY = frameHeight * Projectile.frame;

            Rectangle sourceRectangle = new(0, startY, texture.Width, frameHeight);
            Vector2 origin = sourceRectangle.Size() / 2f;

            SpriteEffects spriteEffects = SpriteEffects.None;
            if (Projectile.direction == -1)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }

            float offsetX = 20f;
            origin.X = Projectile.spriteDirection == -1 ? sourceRectangle.Width - offsetX : offsetX;           

            Main.EntitySpriteDraw(trailFire, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), trailFrame, colorHotPink, Projectile.velocity.ToRotation() + MathHelper.PiOver2, origin, 1.5f, spriteEffects, 0);
            Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), sourceRectangle, drawColor, Projectile.rotation, origin, Projectile.scale, spriteEffects, 0);            
            return false;
        }

        public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
            for (int num562 = 0; num562 < 10; num562++)
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Enchanted_Pink, Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f, 150, default, 1.2f);
            }
            for (int num563 = 0; num563 < 3; num563++)
            {
                Gore.NewGore(Projectile.GetSource_Death(), Projectile.position, new Vector2(Projectile.velocity.X * 0.05f, Projectile.velocity.Y * 0.05f), Main.rand.Next(16, 18));
            }
        }
    }
}
