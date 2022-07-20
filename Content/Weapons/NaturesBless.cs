using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using MoreShortswords.Content.Projectiles;

namespace MoreShortswords.Content.Weapons
{
    public class NaturesBless : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nature's Bless");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 64;
            Item.height = 64;

            Item.useStyle = ItemUseStyleID.Rapier;
            Item.useAnimation = 9;
            Item.useTime = 9;

            Item.UseSound = SoundID.Item1;

            Item.damage = 107;
            Item.knockBack = 7f;

            Item.rare = ItemRarityID.Red;
            Item.value = Item.sellPrice(0, 1, 55, 15);

            Item.DamageType = DamageClass.MeleeNoSpeed;

            Item.shoot = ModContent.ProjectileType<NaturesBlessProjectile>();
            Item.shootSpeed = 8.6f;

            Item.crit = 12;

            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.FragmentVortex, 4)
                .AddIngredient(ItemID.GrassSeeds, 8)
                .AddIngredient(ItemID.ChlorophyteBar, 6)
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }
    }
}
