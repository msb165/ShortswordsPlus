using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using MoreShortswords.Content.Projectiles;

namespace MoreShortswords.Content.Weapons
{
    public class NaturesBless : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 64;
            Item.height = 64;
            Item.useStyle = ItemUseStyleID.Rapier;
            Item.useAnimation = 10;
            Item.useTime = 10;
            Item.UseSound = SoundID.Item1;
            Item.damage = 100;
            Item.knockBack = 4f;
            Item.rare = ItemRarityID.Yellow;
            Item.value = Item.sellPrice(0, 2, 25, 0);
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.shoot = ModContent.ProjectileType<NaturesBlessProjectile>();
            Item.shootSpeed = 6f;
            Item.crit = 8;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.autoReuse = true;
            Item.ArmorPenetration = 12;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.SunStone, 1)
                .AddIngredient(ItemID.GrassSeeds, 20)
                .AddIngredient(ItemID.ChlorophyteBar, 15)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}
