using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace MoreShortswords.Content.Accessories
{
    public class StrangeSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Strange Sword");
            Item.ResearchUnlockCount = 1;
            // Tooltip.SetDefault("So strange...\n10% more damage and 5% more attack speed if using a shortsword or spear");
        }
        public override void SetDefaults()
        {
            Item.width = 44;
            Item.height = 44;
            Item.accessory = true;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.buyPrice(0, 0, 50, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.HeldItem.useStyle == ItemUseStyleID.Rapier || player.HeldItem.useStyle == 15)
            {
                player.GetDamage(DamageClass.MeleeNoSpeed) *= 1.1f;
                player.GetAttackSpeed(DamageClass.MeleeNoSpeed) *= 1.1f;
                player.GetCritChance(DamageClass.MeleeNoSpeed) *= 1.15f;
            }
        }
    }
}
