using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Drawing;

namespace MoreShortswords.Content.Projectiles
{
    public class CosmicBladeProjectile : ShortSwordProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cosmic Blade");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Projectile.ArmorPenetration = 25;
            Projectile.tileCollide = false;            
        }

        public override void AI()
        {
            base.AI();          

            if (!Main.dedServ)
            {
                int PinkDust = Dust.NewDust(Projectile.Center, Projectile.width, Projectile.height, DustID.Enchanted_Pink, Projectile.velocity.X * 0.8f + (Projectile.spriteDirection * 3), Projectile.velocity.Y * 0.2f, 128, Color.HotPink, 1.2f);
                Main.dust[PinkDust].velocity.X *= 0.2f;
                Main.dust[PinkDust].velocity.Y -= 1f;
                Main.dust[PinkDust].noGravity = true;
            }

            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2 - MathHelper.PiOver4 * Projectile.spriteDirection;
            SetVisualOffsets();
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (!target.HasBuff(BuffID.Weak) && !target.HasBuff(BuffID.Confused))
            {
                target.AddBuff(BuffID.Confused, Main.rand.Next(120, 240));
                target.AddBuff(BuffID.Weak, Main.rand.Next(240, 400));
            }

            ParticleOrchestrator.RequestParticleSpawn(false, ParticleOrchestraType.StellarTune, new ParticleOrchestraSettings
            {
                PositionInWorld = target.Center
            });
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
