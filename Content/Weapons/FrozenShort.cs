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
            DisplayName.SetDefault("Frozen Shortsword");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
		public override void SetDefaults()
		{
			Item.width = 40;
			Item.height = 40;

			Item.useStyle = ItemUseStyleID.Rapier;
			Item.useAnimation = 20;
			Item.useTime = 20;

			Item.UseSound = SoundID.Item1;

			Item.damage = 12;
			Item.knockBack = 4.7f;			

			Item.rare = ItemRarityID.White;
			Item.value = Item.sellPrice(0, 0, 80, 15);

			Item.DamageType = DamageClass.MeleeNoSpeed;

			Item.shoot = ModContent.ProjectileType<FrozenShortProjectile>();
			Item.shootSpeed = 3f;

			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.autoReuse = true;

		}

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
			if (player.ownedProjectileCounts[ProjectileID.NorthPoleSnowflake] < 2)
			{ 
				int IceProjectile = Projectile.NewProjectile(source, position, velocity * 1.25f, ProjectileID.NorthPoleSnowflake, 2, 3.4f, player.whoAmI);
				Main.projectile[IceProjectile].timeLeft = 150;
				Main.projectile[IceProjectile].CritChance = 0;
			}			
			return true;
        }

        public override void AddRecipes()
        {
			CreateRecipe()
				.AddIngredient(ItemID.IceBlock, 8)
				.AddIngredient(ItemID.SnowBlock, 8)
				.AddTile(TileID.Anvils)
				.Register();
        }
    }
}
