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
			Item.ResearchUnlockCount = 1;
		}
		public override void SetDefaults()
		{
			Item.width = 56;
			Item.height = 56;
			Item.useStyle = ItemUseStyleID.Rapier;
			Item.useAnimation = 12;
			Item.useTime = 12;
			Item.UseSound = SoundID.Item1;
			Item.damage = 90;
			Item.knockBack = 3f;		
			Item.rare = ItemRarityID.LightRed;
			Item.value = Item.sellPrice(0, 1, 25, 15);
			Item.DamageType = DamageClass.MeleeNoSpeed;
			Item.shoot = ModContent.ProjectileType<SkyBladeProjectile>();
			Item.shootSpeed = 6f;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.autoReuse = true;

		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.SoulofLight, 15)
				.AddIngredient(ItemID.LightShard, 1)
				.AddIngredient(ItemID.Feather, 15)
				.AddIngredient(ItemID.SpectreBar, 15)
				.AddTile(TileID.LunarCraftingStation)
				.Register();
		}
	}
}
