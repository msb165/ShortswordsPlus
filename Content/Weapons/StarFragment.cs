using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using MoreShortswords.Content.Projectiles;

namespace MoreShortswords.Content.Weapons
{
    public class StarFragment : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star Blade");            
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;

            Item.useStyle = ItemUseStyleID.Rapier;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.UseSound = SoundID.Item1;

            Item.damage = 55;
            Item.DamageType = DamageClass.MeleeNoSpeed;

            Item.rare = ItemRarityID.LightRed;
            Item.value = Item.sellPrice(0, 0, 80, 15);

            Item.shoot = ModContent.ProjectileType<StarFragmentProjectile>();
            Item.shootSpeed = 4f;

            Item.knockBack = 4.7f;

            Item.autoReuse = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;
        }

       
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.FallenStar, 5)
                .AddIngredient(ItemID.SoulofLight, 4)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
