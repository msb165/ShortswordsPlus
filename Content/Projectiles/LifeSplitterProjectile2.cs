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
        public override string Texture => "MoreShortswords/Content/Projectiles/DayAbominationProjectile2";

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Type] = 30;
            ProjectileID.Sets.TrailingMode[Type] = 3;
            ProjectileID.Sets.CultistIsResistantTo[Type] = true;
        }

        public override void SetDefaults()
        {            
            Projectile.tileCollide = false;
            Projectile.timeLeft = 100;
            Projectile.penetrate = 1;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.Size = new(20);
        }

        public override void AI()
        {
            float detectRadiusMax = 300f;
            float projSpeed = 20f;

            for (int i = 0; i < 3; i++)
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Clentaminator_Green, 0, 0, 0, Color.Green, 1f);
                dust.noGravity = true;
                dust.velocity *= 0.5f;
                dust.velocity -= Projectile.velocity * 0.1f;

                Dust dust2 = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.SpectreStaff, 0, 0, 0, Color.Green, 1.5f);
                dust2.noGravity = true;
                dust2.velocity *= 0.5f;
                dust2.velocity -= Projectile.velocity * 0.1f;
            }

            Projectile.rotation = Projectile.velocity.ToRotation();

            NPC closestNPC = FindClosestNPC(detectRadiusMax);
            if (closestNPC is null)
            {
                return;
            }
            
            Projectile.velocity = Vector2.Lerp(Projectile.velocity, (closestNPC.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * projSpeed, 0.2f);
        }

        public override Color? GetAlpha(Color lightColor) => Color.Green with { A = 0 };

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

        public override bool PreDraw(ref Color lightColor)
        {
            float glowScale = 0.5f;
            SpriteBatch spriteBatch = Main.spriteBatch;
            Texture2D texture = TextureAssets.Projectile[Type].Value;
            Texture2D glowTexture = (Texture2D)ModContent.Request<Texture2D>("MoreShortswords/Assets/GlowSphere");

            Vector2 drawOrigin = texture.Size() / 2;
            Vector2 drawOriginGlow = glowTexture.Size() / 2;
            Color drawColor = new(64, 255, 27, 0);
            Color drawColorTrail = drawColor;
            Color drawColorGlow = drawColor;

            for (int i = 0; i < Projectile.oldPos.Length; i++)
            {
                Vector2 drawPosTrail = Projectile.oldPos[i] + drawOrigin - Main.screenPosition;

                drawColorTrail *= 0.75f;
                drawColorGlow *= 0.5f;

                spriteBatch.Draw(glowTexture, drawPosTrail, glowTexture.Frame(), drawColorGlow, Projectile.rotation, drawOriginGlow, glowScale, SpriteEffects.None, 0);
                spriteBatch.Draw(texture, drawPosTrail, texture.Frame(), drawColorTrail, Projectile.rotation, drawOrigin, Projectile.scale - i / (float)Projectile.oldPos.Length, SpriteEffects.None, 0);
            }

            spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition, texture.Frame(), drawColor, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            return false;
        }
    }
}
