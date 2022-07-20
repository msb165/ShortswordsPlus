using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using MoreShortswords.Content.Projectiles;

namespace MoreShortswords.Content.Weapons
{
    public class FireyShortsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Molten Shortsword");
            Tooltip.SetDefault("\"Careful, it's hot!\"");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 42;
            Item.height = 42;

            Item.useStyle = ItemUseStyleID.Rapier;
            Item.useAnimation = 25;
            Item.useTime = 25;
            Item.UseSound = SoundID.Item1;

            Item.rare = ItemRarityID.Orange;
            Item.value = Item.sellPrice(0, 0, 34, 12);

            Item.damage = 29;
            Item.knockBack = 5f;

            Item.DamageType = DamageClass.MeleeNoSpeed;

            Item.shoot = ModContent.ProjectileType<FieryShortProjectile>();
            Item.shootSpeed = 2.1f;

            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.autoReuse = true;
        }        

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.HellstoneBar, 6)
                .AddTile(TileID.Anvils)
                .Register();
        }

    }
}
