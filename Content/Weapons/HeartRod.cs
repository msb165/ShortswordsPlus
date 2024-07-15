using Microsoft.Xna.Framework;
using MoreShortswords.Content.Projectiles;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoreShortswords.Content.Weapons
{
    public class HeartRod : ModItem
    {

        public override void SetDefaults()
        {
            Item.Size = new(48);
            Item.damage = 20;
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.crit = 2;

            Item.useStyle = ItemUseStyleID.Rapier;
            Item.useTime = 16;
            Item.useAnimation = 16;
            Item.UseSound = SoundID.Item1;

            Item.rare = ItemRarityID.Green;
            Item.shoot = ModContent.ProjectileType<HeartRodProjectile>();
            Item.shootSpeed = 5f;
            Item.knockBack = 4.5f;

            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.autoReuse = true;
            Item.ResearchUnlockCount = 1;
            Item.ArmorPenetration = 5;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.LifeFruit, 2)
                .AddIngredient(ItemID.ChlorophyteBar, 7)
                .AddIngredient(ItemID.Vine, 4)
                .AddIngredient(ItemID.JungleSpores, 6)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}
