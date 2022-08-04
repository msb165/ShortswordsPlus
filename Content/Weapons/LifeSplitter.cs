using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using MoreShortswords.Content.Projectiles;

namespace MoreShortswords.Content.Weapons
{
    public class LifeSplitter : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Life Splitter");
            Tooltip.SetDefault("25% chance to inflict weakness on an enemy.");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.UseSound = SoundID.Item1;
            Item.useStyle = ItemUseStyleID.Rapier;

            Item.damage = 84;
            Item.DamageType = DamageClass.MeleeNoSpeed;

            Item.value = Item.sellPrice(0, 1, 13, 25);

            Item.shoot = ModContent.ProjectileType<LifeSplitterProjectile>();
            Item.shootSpeed = 6.2f;

            Item.rare = ItemRarityID.Lime;

            Item.width = 50;
            Item.height = 50;

            Item.crit = 8;
            Item.knockBack = 7f;

            Item.autoReuse = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.ChlorophyteBar, 8)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}
