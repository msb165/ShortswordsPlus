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
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Heart Rod");
            // Tooltip.SetDefault("Has a chance to give health if a critical strike is dealt.");
        }

        public override void SetDefaults()
        {
            Item.width = Item.height = 48;
            Item.damage = 20;
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.crit = 2;

            Item.useStyle = ItemUseStyleID.Rapier;
            Item.useTime = 16;
            Item.useAnimation = 16;
            Item.UseSound = SoundID.Item1;

            Item.rare = ItemRarityID.Green;
            Item.shoot = ModContent.ProjectileType<HeartRodProjectile>();
            Item.shootSpeed = 2f;
            Item.knockBack = 4.5f;

            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.autoReuse = true;
            Item.ResearchUnlockCount = 1;
            Item.ArmorPenetration = 5;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            for (int i = -1; i < 1; i++)
            {
                Vector2 spinningPoint = Vector2.Normalize(velocity) * 4f;
                spinningPoint = spinningPoint.RotatedBy(MathHelper.ToRadians(15 * i));
                if (spinningPoint.HasNaNs())
                {
                    spinningPoint -= Vector2.UnitY;
                }
                Projectile.NewProjectile(source, position, spinningPoint, type, damage, knockback, player.whoAmI);
            }

            return false;
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
