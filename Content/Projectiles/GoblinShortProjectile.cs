using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

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
            Projectile.ArmorPenetration = 1;
        }

        public override void AI()
        {
            base.AI();
        }

    }
}
