using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using MoreShortswords.Content.Projectiles;

namespace MoreShortswords.Content.Weapons
{
    public class CactusShort : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cactus Shortsword");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;

            Item.useStyle = ItemUseStyleID.Rapier;
            Item.useTime = 26;
            Item.useAnimation = 26;
            Item.UseSound = SoundID.Item1;

            Item.knockBack = 4.5f;

            Item.damage = 10;
            Item.DamageType = DamageClass.MeleeNoSpeed;

            Item.rare = ItemRarityID.White;
            Item.value = Item.sellPrice(0, 0, 5, 15);

            Item.shoot = ModContent.ProjectileType<CactusShortProjectile>();
            Item.shootSpeed = 3.0f;

            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Cactus, 5)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}
