using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MoreShortswords.Content.Projectiles
{
    public class LifeSplitterProjectile2 : ModProjectile
    {
        public override string Texture => $"Terraria/Images/Projectile_{ProjectileID.NightBeam}";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Life Splitter Projectile");
            ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.EmeraldBolt);
            Projectile.tileCollide = false;
            Projectile.timeLeft = 200;
            Projectile.penetrate = 1;
        }

        public override void AI()
        {
            float detectRadiusMax = 300f;
            float projSpeed = 20f;

            int fireDust = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.GemEmerald, Projectile.velocity.X, Projectile.velocity.Y, 255, default, 1.5f);
            Main.dust[fireDust].noGravity = true;
            Dust secFireDust = Main.dust[fireDust];
            secFireDust.velocity *= 0.4f;
            
            NPC closestNPC = FindClosestNPC(detectRadiusMax);
            if (closestNPC == null)
            {
                return;
            }

            Projectile.velocity = (closestNPC.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * projSpeed;
            Projectile.rotation = Projectile.velocity.ToRotation();
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
