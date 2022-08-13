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

        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Cosmic Laser");
		}

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
			if (Projectile.localAI[0] % 3f == 0)
			{
                if (Main.rand.NextBool(5))
                {
					Vector2 vector34 = Projectile.Center;
					vector34 -= Projectile.velocity;
					int num369 = Dust.NewDust(vector34, 1, 1, DustID.DungeonSpirit, Projectile.oldVelocity.X, Projectile.velocity.Y);
					Main.dust[num369].noGravity = true;
					Main.dust[num369].velocity *= 0.3f;
					Main.dust[num369].scale = Main.rand.Next(70, 110) * 0.013f;
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
