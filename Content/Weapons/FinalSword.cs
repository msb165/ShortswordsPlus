using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using MoreShortswords.Content.Projectiles;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace MoreShortswords.Content.Weapons
{
    public class FinalSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Apogee");
            // Tooltip.SetDefault("\"Say goodbye to death.\"");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 100;
            Item.height = 100;

            Item.useStyle = ItemUseStyleID.Rapier;
            Item.useAnimation = 12;
            Item.useTime = Item.useAnimation / 2;           
            Item.UseSound = SoundID.Item1;

            Item.damage = 100;
            Item.ArmorPenetration = 20;
            Item.knockBack = 6f;

            Item.rare = ItemRarityID.Red;
            Item.value = Item.sellPrice(0, 8, 0, 0);

            Item.DamageType = DamageClass.MeleeNoSpeed;

            Item.shoot = ModContent.ProjectileType<FinalSwordProjectile>();
            Item.shootSpeed = 7f;

            Item.crit = 8;

            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.autoReuse = true;
        }


        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<NaturesBless>(), 1)
                .AddIngredient(ModContent.ItemType<DayAbomination>(), 1)
                .AddIngredient(ModContent.ItemType<CosmicBlade>(), 1)
                .AddIngredient(ModContent.ItemType<SkyBlade>(), 1)
                .AddIngredient(ModContent.ItemType<EnchantedDagger>(), 1)
                .AddIngredient(ItemID.PlatinumShortsword, 1)                
                .AddIngredient(ItemID.LunarBar, 30)
                .AddTile(TileID.LunarCraftingStation)
                .Register();            
        }
    }
}
