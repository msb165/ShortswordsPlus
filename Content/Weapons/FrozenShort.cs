using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using MoreShortswords.Content.Projectiles;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace MoreShortswords.Content.Weapons
{
    public class FrozenShort : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Frozen Shortsword");
			// Tooltip.SetDefault("\"Careful, it's cold!\"\n50% chance of inflicting frostburn.");
			Item.ResearchUnlockCount = 1;
        }
		public override void SetDefaults()
		{
			Item.width = 40;
			Item.height = 40;
			Item.useStyle = ItemUseStyleID.Rapier;
			Item.useAnimation = 30;
			Item.useTime = 30;
			Item.UseSound = SoundID.Item1;
			Item.damage = 13;
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.knockBack = 4f;		
			Item.rare = ItemRarityID.White;
			Item.value = Item.sellPrice(0, 0, 22, 0);
			Item.shoot = ModContent.ProjectileType<FrozenShortProjectile>();
			Item.shootSpeed = 3f;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.autoReuse = true;

		}

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
			if (player.ownedProjectileCounts[ProjectileID.NorthPoleSnowflake] < 4)
			{ 
				Projectile IceProjectile = Projectile.NewProjectileDirect(source, position, velocity.RotatedByRandom(MathHelper.ToRadians(10f)), ProjectileID.NorthPoleSnowflake, 2, 5f, player.whoAmI);
                IceProjectile.timeLeft = 150;
                IceProjectile.CritChance = 3;				
			}			
			return true;
        }

        public override void AddRecipes()
        {
			CreateRecipe()
				.AddIngredient(ItemID.IceBlock, 20)
				.AddIngredient(ItemID.SnowBlock, 20)
				.AddRecipeGroup(RecipeGroupID.IronBar, 15)
				.AddTile(TileID.Anvils)
				.Register();
        }
    }
}
