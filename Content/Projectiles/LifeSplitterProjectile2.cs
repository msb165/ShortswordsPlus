using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using MoreShortswords.Content.Dusts;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace MoreShortswords.Content.Projectiles
{
    public class LifeSplitterProjectile2 : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Type] = 30;
            ProjectileID.Sets.TrailingMode[Type] = 2;
            ProjectileID.Sets.CultistIsResistantTo[Type] = true;
        }

        public override void SetDefaults()
        {            
            Projectile.tileCollide = false;
            Projectile.timeLeft = 100;
            Projectile.penetrate = 1;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.Size = new(16);
        }

        public override void AI()
        {
            float detectRadiusMax = 300f;
            float projSpeed = 20f;

            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;

            NPC closestNPC = FindClosestNPC(detectRadiusMax);
            if (closestNPC is null)
            {
                return;
            }
            
            Projectile.velocity = Vector2.Lerp(Projectile.velocity, (closestNPC.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * projSpeed, 0.2f);
        }

        public NPC FindClosestNPC(float maxDistance)
        {
            NPC closestNPC = null;

            float sqrMaxDistance = maxDistance * maxDistance;
            for (int j = 0; j < Main.maxNPCs; j++)
            {
                NPC closestTarget = Main.npc[j];

                if (closestTarget.CanBeChasedBy(this))
                {
                    float sqrDistanceToTarget = Vector2.DistanceSquared(closestTarget.Center, Projectile.Center);
                    if (sqrDistanceToTarget < sqrMaxDistance)
                    {
                        sqrMaxDistance = sqrDistanceToTarget;
                        closestNPC = closestTarget;
                    }
                }
                
            }
            return closestNPC;
        }

        public override bool PreDraw(ref Color lightColor)
        {
            float glowScale = 0.5f;
            SpriteBatch spriteBatch = Main.spriteBatch;
            Texture2D texture = TextureAssets.Projectile[Type].Value;
            Texture2D glowTexture = (Texture2D)ModContent.Request<Texture2D>("MoreShortswords/Assets/GlowSphere");

            Vector2 drawOrigin = texture.Size() / 2;
            Vector2 drawOriginGlow = glowTexture.Size() / 2;
            Color drawColor = Color.White;
            Color drawColorTrail = drawColor;
            Color drawColorGlow = Color.GreenYellow with { A = 0 }; 

            for (int i = 0; i < Projectile.oldPos.Length; i++)
            {
                Vector2 drawPosTrail = Projectile.oldPos[i] + drawOrigin - Main.screenPosition;

                drawColorTrail *= 0.75f;
                drawColorGlow *= 0.75f;

                spriteBatch.Draw(texture, drawPosTrail, texture.Frame(), drawColorTrail, Projectile.rotation, drawOrigin, (Projectile.scale * 1.25f) - i / (float)Projectile.oldPos.Length, SpriteEffects.None, 0);
                spriteBatch.Draw(glowTexture, drawPosTrail, glowTexture.Frame(), drawColorGlow, Projectile.rotation, drawOriginGlow, glowScale, SpriteEffects.None, 0);
            }

            return false;
        }
    }
}
