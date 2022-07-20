using MoreShortswords.Content.Projectiles;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace MoreShortswords.Content.Weapons
{
    public class MuramasaShortsword : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Moonlight");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{			
			Item.width = 32;
			Item.height = 32;

			Item.useStyle = ItemUseStyleID.Rapier;
			Item.useAnimation = 21;
			Item.useTime = 21;

			Item.UseSound = SoundID.Item1;

			Item.damage = 15;
			Item.knockBack = 2.5f;			

			Item.rare = ItemRarityID.Orange;
			Item.value = Item.sellPrice(0, 1, 75, 0);

			Item.DamageType = DamageClass.MeleeNoSpeed;

			Item.shoot = ModContent.ProjectileType<MuraShortProjectile>();
			Item.shootSpeed = 2.1f;

			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.autoReuse = true;
			
		}

    }
}
