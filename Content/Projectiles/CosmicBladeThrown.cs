using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using Terraria.GameContent.Drawing;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics;
using Terraria.GameContent;
using MoreShortswords.Content.Weapons;

namespace MoreShortswords.Content.Projectiles
{
    public class CosmicBladeThrown : ModProjectile
    {
        public override string Texture => ModContent.GetInstance<CosmicBlade>().Texture;

        public override void SetStaticDefaults()
        {
			ProjectileID.Sets.TrailCacheLength[Type] = 15;
			ProjectileID.Sets.TrailingMode[Type] = 2;
        }

        public override void SetDefaults()
        {	
			Projectile.friendly = true;
			Projectile.ownerHitCheck = true;
			Projectile.width = 18;
			Projectile.height = 18;
			Projectile.penetrate = -1;
			Projectile.alpha = 0;
			Projectile.extraUpdates = 1;
			Projectile.timeLeft = 200;
			Projectile.aiStyle = -1;
            Projectile.damage = 94;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 17;
        }

        public override void AI()
        {
			Projectile.velocity.Y += 0.4f;
			Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2 - MathHelper.PiOver4 * Projectile.spriteDirection;

			if (Main.rand.NextBool(3))
            {
				Projectile.NewProjectile(Projectile.GetSource_FromAI(), Projectile.position, Projectile.velocity.RotatedByRandom(15f), ModContent.ProjectileType<CosmicLaser>(), Projectile.damage, 0f, Projectile.owner, 0f);
			}
		}

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
			ParticleOrchestrator.RequestParticleSpawn(false, ParticleOrchestraType.StellarTune, new ParticleOrchestraSettings
			{
				PositionInWorld = target.Center
			});
		}

        public override void OnKill(int timeLeft)
		{
			SoundEngine.PlaySound(SoundID.NPCHit3, Projectile.position);
			for (int numOfParticles = 0; numOfParticles < 16; numOfParticles++)
			{
				int dustExplode = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.DungeonSpirit, Projectile.velocity.X, Projectile.velocity.Y, 255, default, 1.25f);
				Main.dust[dustExplode].noGravity = true;
				Dust dustExplodeAlt = Main.dust[dustExplode];				

				dustExplodeAlt.scale *= 1.25f;
				dustExplodeAlt.velocity = Projectile.velocity.RotatedByRandom(15f);
			}
		}


        public override bool PreDraw(ref Color lightColor)
		{
            SpriteBatch spriteBatch = Main.spriteBatch;
            Texture2D texture = TextureAssets.Projectile[Type].Value;

            Rectangle sourceRectangle = new(0, 0, texture.Width, texture.Height);			
			Color drawColorTrail = Color.White with { A = 0 };

			Vector2 drawOrigin = new(texture.Width, 0f);


            for (int i = 0; i < Projectile.oldPos.Length; i++)
			{	
				Vector2 drawPosTrail = Projectile.oldPos[i] + Projectile.Size / 2f - Main.screenPosition;
				drawColorTrail *= 0.75f;

				spriteBatch.Draw(texture, drawPosTrail, null, drawColorTrail, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
			}

            spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition, sourceRectangle, Color.White, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition, sourceRectangle, Color.Cyan with { A = 0 }, Projectile.rotation, drawOrigin, Projectile.scale * 1.25f, SpriteEffects.None, 0);
            return false;
        }
	}
}
