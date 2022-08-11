using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace MoreShortswords.Content.Projectiles
{
    public class BetelgueseProjectile2 : ModProjectile
    {
        public override string Texture => "MoreShortswords/Content/Projectiles/StarFragmentProjectile";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Betelguese");
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 8;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }

        public override void SetDefaults()
        {
            Projectile.width = 40;
            Projectile.height = 40;
            Projectile.friendly = true;
            Projectile.penetrate = 1;
            Projectile.scale = 0.8f;
            Projectile.tileCollide = false;
            Projectile.ArmorPenetration = 200;
            Projectile.timeLeft = 200;
        }

        public override void AI()
        {
            float detectRadiusMax = 300f;
            float projSpeed = 20f;

            NPC closestNPC = FindClosestNPC(detectRadiusMax);
            if (closestNPC == null)
            {
                return;
            }
            Projectile.velocity = (closestNPC.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * projSpeed;
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D trailFire = TextureAssets.Extra[91].Value;
            Rectangle trailFrame = trailFire.Frame();
            Color colorHotPink = Color.HotPink * 0.3f;
            colorHotPink.A = 0;

            int frameHeight = trailFire.Height / Main.projFrames[Projectile.type];
            int startY = frameHeight * Projectile.frame;

            Rectangle sourceRectangle = new(0, startY, trailFire.Width, frameHeight);
            Vector2 origin = sourceRectangle.Size() / 2f;

            SpriteEffects spriteEffects = SpriteEffects.None;
            if (Projectile.direction == -1)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }

            Vector2 drawOrigin = new(trailFire.Width / 2, trailFire.Height / 2);
            for (int i = 0; i < Projectile.oldPos.Length; i++)
            {
                float num = 8 - i;
                Color drawColor2 = Projectile.GetAlpha(lightColor) * ((Projectile.oldPos.Length - i) / (float)Projectile.oldPos.Length);
                drawColor2 *= num / (ProjectileID.Sets.TrailCacheLength[Projectile.type] * 1.5f);
                Main.EntitySpriteDraw(trailFire, (Projectile.oldPos[i] - Main.screenPosition) + drawOrigin + new Vector2(0f, Projectile.gfxOffY), null, drawColor2, Projectile.velocity.ToRotation() + MathHelper.PiOver2, drawOrigin, Projectile.scale, spriteEffects, 0);
            }

            float offsetX = 20f;
            origin.X = Projectile.spriteDirection == -1 ? sourceRectangle.Width - offsetX : offsetX;

            Main.EntitySpriteDraw(trailFire, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), trailFrame, colorHotPink, Projectile.velocity.ToRotation() + MathHelper.PiOver2, origin, Projectile.scale, spriteEffects, 0);            
            return false;
        }


        public NPC FindClosestNPC(float maxDistance)
        {
            NPC closestNPC = null;

            float sqrMaxDistance = maxDistance * maxDistance;
            for (int j = 0; j < Main.maxNPCs; j++)
            {
                NPC target = Main.npc[j];

                if (target.CanBeChasedBy())
                {
                    float sqrDistanceToTarget = Vector2.DistanceSquared(target.Center, Projectile.Center);
                    if (sqrDistanceToTarget < sqrMaxDistance)
                    {
                        sqrMaxDistance = sqrDistanceToTarget;
                        closestNPC = target;
                    }
                }

            }
            return closestNPC;
        }

    }
}
