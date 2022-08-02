using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using MoreShortswords.Content.Projectiles;

namespace MoreShortswords.Content.Weapons
{
    public class MagicBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Deity Spear");
            Tooltip.SetDefault("Press right click to throw it.");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 50;
            Item.height = 50;

            Item.useStyle = ItemUseStyleID.Rapier;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.UseSound = SoundID.Item1;

            Item.knockBack = 5.2f;

            Item.damage = 61;
            Item.DamageType = DamageClass.MeleeNoSpeed;

            Item.rare = ItemRarityID.Pink;
            Item.value = Item.sellPrice(0, 0, 35, 15);

            Item.crit = 8;  

            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.autoReuse = true;
        }

        public override bool AltFunctionUse(Player player)
        {                     
            return player.ownedProjectileCounts[ModContent.ProjectileType<MagicBladeProjectile2>()] < 1;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                Item.shoot = ModContent.ProjectileType<MagicBladeProjectile2>();
                Item.shootSpeed = 8f;
            }
            else
            {
                Item.shoot = ModContent.ProjectileType<MagicBladeProjectile>();
                Item.shootSpeed = 5f;
            }
            return player.ownedProjectileCounts[ModContent.ProjectileType<MagicBladeProjectile2>()] < 1 && player.ownedProjectileCounts[ModContent.ProjectileType<MagicBladeProjectile>()] < 1;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.CobaltBar, 8)
                .AddIngredient(ItemID.SoulofMight, 8)
                .AddTile(TileID.MythrilAnvil)
                .Register();
            CreateRecipe()
                .AddIngredient(ItemID.PalladiumBar, 8)
                .AddIngredient(ItemID.SoulofMight, 8)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}
