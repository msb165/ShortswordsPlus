﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using MoreShortswords.Content.Projectiles;

namespace MoreShortswords.Content.Weapons
{
	public class CosmicBlade : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cosmic Blade");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 56;
			Item.height = 56;

			Item.useStyle = ItemUseStyleID.Rapier;
			Item.useAnimation = 10;
			Item.useTime = 10;

			Item.UseSound = SoundID.Item1;

			Item.damage = 104;
			Item.knockBack = 7f;

			Item.rare = ItemRarityID.Yellow;
			Item.value = Item.sellPrice(0, 1, 35, 15);

			Item.DamageType = DamageClass.MeleeNoSpeed;

			Item.crit = 10;

			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.autoReuse = true;
		}

        public override bool CanUseItem(Player player)
        {
			if (player.altFunctionUse == 2)
            {
				Item.shoot = ModContent.ProjectileType<CosmicBladeProjectile2>();
				Item.shootSpeed = 16f;
			}
            else
            {
				Item.shoot = ModContent.ProjectileType<CosmicBladeProjectile>();
				Item.shootSpeed = 8f;
			}
			return true;			
        }

        public override bool AltFunctionUse(Player player)
        {
			return player.ownedProjectileCounts[ModContent.ProjectileType<CosmicBladeProjectile2>()] < 8;
		}

    }
}
