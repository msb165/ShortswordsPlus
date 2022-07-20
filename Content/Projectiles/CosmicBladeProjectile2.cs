using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System;


namespace MoreShortswords.Content.Projectiles
{
    public class CosmicBladeProjectile2 : ModProjectile
    {
		public override string Texture => "MoreShortswords/Content/Projectiles/CosmicBladeProjectile";

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cosmic Blade");
		}

		public override void SetDefaults()
        {
			Projectile.CloneDefaults(ProjectileID.CrystalVileShardShaft);			
        }

        public override void AI()
        {
			Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2 - MathHelper.PiOver4 * Projectile.spriteDirection;
			Projectile.rotation += 0.06f;
			if (Projectile.ai[0] == 0f)
			{								
				Projectile.alpha = 0;
				Projectile.ai[0] = 1f;
				if (Projectile.alpha > 0)
				{
					return;
				}

				if (Projectile.ai[1] == 0f)
				{
					Projectile.ai[1] += 1f;
					Projectile.position += Projectile.velocity * 1f;
				}

				Projectile.velocity += new Vector2(0.25f, 0.25f);
				
				Projectile.alpha += 4;
				if (Projectile.alpha >= 255)
				{
					Projectile.Kill();
				}
				
			}
			SetVisualOffsets();
		}

		private void SetVisualOffsets()
		{
			int halfProjWidth = Projectile.width / 2;
			int halfProjHeight = Projectile.height / 2;

			DrawOriginOffsetX = 0;
			DrawOffsetX = -((56 / 2) - halfProjWidth);
			DrawOriginOffsetY = -((56 / 2) - halfProjHeight);
		}

	}
}
