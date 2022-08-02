using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;


namespace MoreShortswords.Content.Projectiles
{
    public class DayAbominationProjectile : ModProjectile
    {
        protected virtual float HoldoutRangeMin => 40f;
        protected virtual float HoldoutRangeMax => 80f;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Daylight's Abomination");
        }

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.Spear);            
        }

        public override bool PreAI()
        {           
            base.PreAI();

            Player player = Main.player[Projectile.owner];
            int duration = player.itemAnimationMax;
            player.heldProj = Projectile.whoAmI;
                      
            Projectile.velocity = Vector2.Normalize(Projectile.velocity);

            float halfDuration = duration / 2, progress;

            if (Projectile.timeLeft > duration)
            {
                Projectile.timeLeft = duration;
            }

            progress = Projectile.timeLeft < halfDuration ? Projectile.timeLeft / halfDuration : (duration - Projectile.timeLeft) / halfDuration;

            Projectile.Center = player.MountedCenter + Vector2.SmoothStep(Projectile.velocity * HoldoutRangeMin, Projectile.velocity * HoldoutRangeMax, progress);
            Projectile.rotation = Projectile.rotation * Projectile.spriteDirection + MathHelper.ToRadians(90f);
           
            return false;
        }


        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.NextBool(3)) 
            {
                target.AddBuff(BuffID.Bleeding, 500);
            }
        }
    }
}
