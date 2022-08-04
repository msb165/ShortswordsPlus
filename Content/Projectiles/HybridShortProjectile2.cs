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
            Projectile.width = 48;
            Projectile.height = 48;
            Projectile.alpha = 0;
        }

        public override void AI()
        {
            base.AI();
        }
    }
}
