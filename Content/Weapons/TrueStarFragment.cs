using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using MoreShortswords.Content.Projectiles;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using System;

namespace MoreShortswords.Content.Weapons
{
    public class TrueStarFragment : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.Size = new(54);
            Item.useStyle = ItemUseStyleID.Rapier;
            Item.useTime = 16;
            Item.useAnimation = 16;
            Item.UseSound = SoundID.Item1;
            Item.damage = 85;
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.rare = ItemRarityID.Yellow;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.shoot = ModContent.ProjectileType<TrueStarFragmentProjectile>();
            Item.shootSpeed = 5f;
            Item.knockBack = 0f;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<StarFragment>(), 1)
                .AddIngredient(ItemID.ChlorophyteBar, 12)
                .AddIngredient(ItemID.BrokenHeroSword, 1)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}
