using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using MoreShortswords.Content.Projectiles;

namespace MoreShortswords.Content.Weapons
{
    public class Ladnerud : ModItem
    {       
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ladnerud");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;            
        }

        public override void SetDefaults()
        {
            Item.width = 48;
            Item.height = 48;

            Item.useStyle = ItemUseStyleID.Rapier;
            Item.useTime = 19;
            Item.useAnimation = 19;
            Item.UseSound = SoundID.Item1;

            Item.knockBack = 4.7f;

            Item.damage = 57;
            Item.DamageType = DamageClass.MeleeNoSpeed;

            Item.rare = ItemRarityID.Pink;
            Item.value = Item.sellPrice(0, 0, 35, 15);

            Item.shoot = ModContent.ProjectileType<LadnerudProjectile>();
            Item.shootSpeed = 4.2f;

            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.HallowedBar, 6)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}
