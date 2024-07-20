using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using MoreShortswords.Content.Projectiles;

namespace MoreShortswords.Content.Weapons
{
    public class DayAbomination : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Rapier;
            Item.useAnimation = 22;
            Item.useTime = 22;
            Item.UseSound = SoundID.Item1;
            Item.damage = 40;
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.knockBack = 4.5f;
            Item.shoot = ModContent.ProjectileType<DayAbominationProjectile>();
            Item.shootSpeed = 5f;
            Item.rare = ItemRarityID.Orange;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.autoReuse = true;
           
        }         

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<ShortswordOfGrass>(), 1)
                .AddIngredient(ModContent.ItemType<Magma>(), 1)
                .AddIngredient(ModContent.ItemType<Moonlight>(), 1)
                .AddIngredient(ItemID.CopperShortsword, 1)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
