using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using MoreShortswords.Content.Dusts;

namespace MoreShortswords.Content.Projectiles
{
    public class CosmicLaser : ModProjectile
    {
		public override string Texture => $"Terraria/Images/Projectile_{ProjectileID.RainbowCrystalExplosion}";

        public override void SetDefaults()
        {
			Projectile.width = 4;
			Projectile.height = 4;
			Projectile.alpha = 255;
			Projectile.extraUpdates = 100;
			Projectile.friendly = true;
			Projectile.timeLeft = 200;
			Projectile.aiStyle = -1;
		}

		public override void AI()
        {
			Projectile.ai[0]++;
			if (Projectile.ai[0] % 2f == 0)
			{
                Dust dungeonDust = Dust.NewDustDirect(Projectile.position, 10, 10, DustID.Clentaminator_Cyan);
                dungeonDust.position = Projectile.Center;
                dungeonDust.noGravity = true;
                dungeonDust.velocity = Vector2.Zero;
            }

			if (Main.player[Projectile.owner].ownedProjectileCounts[ModContent.ProjectileType<CosmicLaser>()] >= 3)
			{
				Projectile.Kill();
			}

			if (Projectile.velocity.X != Projectile.oldVelocity.X)
            {
				Projectile.position.X += Projectile.velocity.X;
				Projectile.velocity.X = -Projectile.velocity.X;
			}
			if (Projectile.velocity.Y != Projectile.oldVelocity.Y)
			{
				Projectile.position.Y += Projectile.velocity.Y;
				Projectile.velocity.Y = -Projectile.velocity.Y;
			}
		}		
	}
}
