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
            DisplayName.SetDefault("True Star Fragment");            
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 54;
            Item.height = 54;

            Item.useStyle = ItemUseStyleID.Rapier;
            Item.useTime = 16;
            Item.useAnimation = 16;
            Item.UseSound = SoundID.Item1;

            Item.damage = 72;
            Item.DamageType = DamageClass.MeleeNoSpeed;

            Item.rare = ItemRarityID.Yellow;
            Item.value = Item.sellPrice(0, 1, 80, 15);

            Item.shoot = ModContent.ProjectileType<TrueStarFragmentProjectile>();
            Item.shootSpeed = 7.5f;

            Item.knockBack = 5f;

            Item.autoReuse = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.ownedProjectileCounts[ModContent.ProjectileType<TrueStarFragmentProjectile2>()] < 12)
            {
                for (int numOfStars = 0; numOfStars < 4; numOfStars++)
                {
                    Vector2 vector = new(position.X + 400, position.Y - Main.rand.Next(500, 800));
                    float num16 = position.X + (Item.width / 2) - vector.X;
                    float num17 = position.Y + (Item.height / 2) - vector.Y;
                    num16 += Main.rand.Next(-100, 101);
                    float num18 = (float)Math.Sqrt(num16 * num16 + num17 * num17);
                    num18 = 25f / num18;
                    num16 *= num18;
                    num17 *= num18;

                    Projectile.NewProjectile(source, vector, new Vector2(num16, num17), ModContent.ProjectileType<TrueStarFragmentProjectile2>(), 35, 4.5f, player.whoAmI, 0f, position.Y);
                }
            }

            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<StarFragment>(), 1)
                .AddIngredient(ItemID.SoulofFright, 12)
                .AddIngredient(ItemID.SoulofSight, 12)
                .AddIngredient(ItemID.SoulofMight, 12)
                .AddIngredient(ItemID.ChlorophyteBar, 8)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}
