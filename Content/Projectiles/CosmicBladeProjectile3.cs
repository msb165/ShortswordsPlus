using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Audio;

namespace MoreShortswords.Content.Projectiles
{
    public class CosmicBladeProjectile3 : ModProjectile
    {
		public override string Texture => $"Terraria/Images/Projectile_{ProjectileID.RainbowCrystalExplosion}";

        public override void SetDefaults()
        {
            base.SetDefaults();
			Projectile.width = 4;
			Projectile.height = 4;
			Projectile.alpha = 255;
			Projectile.extraUpdates = 100;
			Projectile.friendly = true;
			Projectile.timeLeft = 200;
		}

		public override void AI()
        {
            base.AI();

			Projectile.localAI[0] += 1f;
			if (Projectile.localAI[0] % 2f == 0)
			{
                if (Main.rand.NextBool(2))
                {
					Dust dungeonDust = Main.dust[Dust.NewDust(Projectile.position, 10, 10, DustID.DungeonSpirit, Projectile.oldVelocity.X, Projectile.velocity.Y)];
					dungeonDust.position = Projectile.Center;
                    dungeonDust.noGravity = true;
					dungeonDust.velocity = Vector2.Zero;					
				}
			}

			if (Main.player[Projectile.owner].ownedProjectileCounts[ModContent.ProjectileType<CosmicBladeProjectile3>()] >= 3)
			{
				Projectile.Kill();
			}

			if (Projectile.velocity.X != Projectile.oldVelocity.X)
            {
				Projectile.position.X += Projectile.velocity.X;
				Projectile.velocity.X = 0f - Projectile.velocity.X;
			}
			if (Projectile.velocity.Y != Projectile.oldVelocity.Y)
			{
				Projectile.position.Y += Projectile.velocity.Y;
				Projectile.velocity.Y = 0f - Projectile.velocity.Y;
			}
		}
		
	}
}
