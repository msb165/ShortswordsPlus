using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoreShortswords.Content.Projectiles
{
    public class HybridShortProjectile2 : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.SwordBeam);
            Projectile.width = 40;
            Projectile.height = 40;
            Projectile.alpha = 0;
        }

        public override void AI()
        {
            base.AI();
        }
    }
}
