using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using MoreShortswords.Content.Projectiles;

namespace MoreShortswords.Content.Weapons
{
    public class ShortswordOfGrass : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shortsword of Grass");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 36;
            Item.height = 38;

            Item.useStyle = ItemUseStyleID.Rapier;
            Item.useTime = 24;
            Item.useAnimation = 24;
            Item.UseSound = SoundID.Item1;

            Item.knockBack = 3.5f;            

            Item.damage = 16;
            Item.DamageType = DamageClass.MeleeNoSpeed;

            Item.rare = ItemRarityID.Orange;
            Item.value = Item.sellPrice(0, 0, 40, 15);

            Item.shoot = ModContent.ProjectileType<ShortGrassProjectile>();
            Item.shootSpeed = 3.0f;

            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.JungleSpores, 6)
                .AddIngredient(ItemID.Stinger, 5)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
