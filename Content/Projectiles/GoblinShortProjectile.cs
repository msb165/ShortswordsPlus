using Terraria;

namespace MoreShortswords.Content.Projectiles
{
    public class GoblinShortProjectile : ShortSwordProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Warrior's Shortsword");
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
            Projectile.ArmorPenetration = 3;
        }

        public override void AI()
        {
            base.AI();
        }

    }
}
