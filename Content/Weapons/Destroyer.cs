using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using MoreShortswords.Content.Projectiles;

namespace MoreShortswords.Content.Weapons
{
    [LegacyName (["HybridShort"])]
    public class Destroyer : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 48;			
            Item.height = 48;			
            Item.useTime = 17;
            Item.useAnimation = 17;
            Item.UseSound = SoundID.Item1;
            Item.useStyle = ItemUseStyleID.Rapier;
            Item.damage = 64;
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.value = Item.sellPrice(0, 2, 30, 0);
            Item.shoot = ModContent.ProjectileType<HybridShortProjectile>();
            Item.shootSpeed = 5f;
            Item.rare = ItemRarityID.LightRed;
            Item.crit = 8;
            Item.knockBack = 5f;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.AdamantiteBar, 10)
                .AddTile(TileID.MythrilAnvil)
                .Register();
            CreateRecipe()
                .AddIngredient(ItemID.TitaniumBar, 10)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}
