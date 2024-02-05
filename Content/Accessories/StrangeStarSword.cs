using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace MoreShortswords.Content.Accessories
{
    public class StrangeStarSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Strange Star Sword");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            // Tooltip.SetDefault("So strange...\n20% more damage and 20% more attack speed if a shortsword or spear is equipped\nCauses stars to fall after taking damage.");
        }
        public override void SetDefaults()
        {
            Item.width = 44;
            Item.height = 44;
            Item.accessory = true;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.buyPrice(0, 3, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.starCloakItem = Item;            
            if (player.HeldItem.useStyle == ItemUseStyleID.Rapier || player.HeldItem.useStyle == 15)
            {                
                player.GetDamage(DamageClass.MeleeNoSpeed) *= 1.20f;
                player.GetAttackSpeed(DamageClass.MeleeNoSpeed) *= 1.2f;
                player.GetCritChance(DamageClass.MeleeNoSpeed) *= 1.25f;                
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<StrangeSword>()
                .AddIngredient(ItemID.StarCloak)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }
    }
}
