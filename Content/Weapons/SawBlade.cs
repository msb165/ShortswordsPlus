using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using MoreShortswords.Content.Projectiles;


namespace MoreShortswords.Content.Weapons
{
    public class SawBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Saw Blade");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 56;
            Item.height = 56;

            Item.damage = 10;
            Item.DamageType = DamageClass.MeleeNoSpeed;

            Item.useStyle = ItemUseStyleID.Shoot;

            Item.value = Item.sellPrice(0, 0, 15, 9);
            Item.rare = ItemRarityID.Blue;         

            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.knockBack = 4.0f;

            Item.channel = true;
            Item.autoReuse = true;
            Item.noUseGraphic = true;
            Item.noMelee = true;

            Item.shoot = ModContent.ProjectileType<SawBladeProjectile>();
        }

        public override bool CanUseItem(Player player)
        {
           return player.ownedProjectileCounts[Item.shoot] <= 1;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.PlatinumBar, 6)
                .AddIngredient(ItemID.SilverBar, 6)
                .AddIngredient(ItemID.HellstoneBar, 6)
                .AddTile(TileID.Hellforge)
                .Register();
        }
    }
}
