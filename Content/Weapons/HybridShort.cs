using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using MoreShortswords.Content.Projectiles;

namespace MoreShortswords.Content.Weapons
{
    public class HybridShort : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Destroyer");            
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.useTime = 17;
            Item.useAnimation = 17;
            Item.UseSound = SoundID.Item1;
            Item.useStyle = ItemUseStyleID.Rapier;

            Item.damage = 62;
            Item.DamageType = DamageClass.MeleeNoSpeed;

            Item.value = Item.sellPrice(0, 1, 12, 25);

            Item.shoot = ModContent.ProjectileType<HybridShortProjectile>();
            Item.shootSpeed = 5f;

            Item.rare = ItemRarityID.LightRed;

            Item.width = 48;
            Item.height = 48;

            Item.crit = 8;
            Item.knockBack = 7f;

            Item.autoReuse = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.AdamantiteBar, 8)
                .AddTile(TileID.MythrilAnvil)
                .Register();
            CreateRecipe()
                .AddIngredient(ItemID.TitaniumBar, 8)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}
