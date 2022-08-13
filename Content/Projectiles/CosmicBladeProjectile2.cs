using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System;
using Terraria.Audio;
using Terraria.GameContent.Drawing;

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
			Projectile.friendly = true;
			Projectile.ownerHitCheck = true;
			Projectile.width = 28;
			Projectile.height = 28;
			Projectile.penetrate = -1;
			Projectile.alpha = 0;
			Projectile.extraUpdates = 1;
			Projectile.timeLeft = 200;
			Projectile.aiStyle = 1;
            Projectile.damage *= (int)0.90;
        }

        public override void AI()
        {
			Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2 - MathHelper.PiOver4 * Projectile.spriteDirection;

			if (Main.rand.NextBool(3))
            {
				Projectile.NewProjectile(Projectile.GetSource_FromAI(), Projectile.position, Projectile.velocity.RotatedByRandom(15f), ModContent.ProjectileType<CosmicBladeProjectile3>(), Projectile.damage, 0f, Projectile.owner, 0f);
			}

			SetVisualOffsets();
		}

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			ParticleOrchestrator.RequestParticleSpawn(false, ParticleOrchestraType.StellarTune, new ParticleOrchestraSettings
			{
				PositionInWorld = target.Center
			});
		}

        public override void Kill(int timeLeft)
		{
			SoundEngine.PlaySound(SoundID.NPCHit3, Projectile.position);
			for (int numOfParticles = 0; numOfParticles < 16; numOfParticles++)
			{
				int dustExplode = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.DungeonSpirit, Projectile.velocity.X, Projectile.velocity.Y, 255, default, 1f);
				Main.dust[dustExplode].noGravity = true;
				Dust dustExplodeAlt = Main.dust[dustExplode];
				dustExplodeAlt.scale *= 1.1f;
				dustExplodeAlt.velocity = Projectile.velocity.RotatedByRandom(15f);
				Projectile.rotation = Projectile.velocity.ToRotation();
			}
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
