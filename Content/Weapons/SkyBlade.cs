using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using MoreShortswords.Content.Projectiles;

namespace MoreShortswords.Content.Weapons
{
	public class SkyBlade : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sky Blade");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults()
		{
			Item.width = 48;
			Item.height = 48;

			Item.useStyle = ItemUseStyleID.Rapier;
			Item.useAnimation = 12;
			Item.useTime = 12;

			Item.UseSound = SoundID.Item1;

			Item.damage = 92;
			Item.knockBack = 7f;			

			Item.rare = ItemRarityID.LightRed;
			Item.value = Item.sellPrice(0, 1, 25, 15);

			Item.DamageType = DamageClass.MeleeNoSpeed;

			Item.shoot = ModContent.ProjectileType<SkyBladeProjectile>();
			Item.shootSpeed = 6.2f;

			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.autoReuse = true;

		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.BrokenHeroSword, 1)
				.AddIngredient(ItemID.SoulofLight, 5)
				.AddIngredient(ItemID.SpectreBar, 5)
				.AddIngredient(ItemID.Cloud, 5)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}
	}
}
