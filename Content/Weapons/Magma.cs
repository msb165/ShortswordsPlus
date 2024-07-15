using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using MoreShortswords.Content.Projectiles;

namespace MoreShortswords.Content.Weapons
{
    [LegacyName(new string[] { "FieryShort" })]
    public class Magma : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 48;
            Item.height = 48;
            Item.useStyle = ItemUseStyleID.Rapier;
            Item.useAnimation = 26;
            Item.useTime = 26;
            Item.UseSound = SoundID.Item1;
            Item.rare = ItemRarityID.Orange;
            Item.value = Item.sellPrice(0, 0, 60, 0);
            Item.damage = 30;
            Item.knockBack = 5f;
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.shoot = ModContent.ProjectileType<FieryShortProjectile>();
            Item.shootSpeed = 3.5f;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.autoReuse = true;
        }        

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.HellstoneBar, 8)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
