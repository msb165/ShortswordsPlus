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
            // DisplayName.SetDefault("Saw Blade");
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 56;
            Item.height = 56;
            Item.damage = 12;
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.shoot = ModContent.ProjectileType<SawBladeProjectile>();
            Item.value = Item.sellPrice(0, 1, 50, 0);
            Item.rare = ItemRarityID.Blue;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.knockBack = 4.0f;
            Item.channel = true;
            Item.autoReuse = true;
            Item.noUseGraphic = true;
            Item.noMelee = true;
        }

        public override bool CanUseItem(Player player) => player.ownedProjectileCounts[Item.shoot] <= 1;

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.PlatinumBar, 10)
                .AddIngredient(ItemID.SilverBar, 10)
                .AddIngredient(ItemID.HellstoneBar, 13)
                .AddTile(TileID.Hellforge)
                .Register();
        }
    }
}
