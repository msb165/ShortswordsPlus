using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using MoreShortswords.Content.Projectiles;
using Microsoft.Xna.Framework;

namespace MoreShortswords.Content.Weapons
{
	public class CosmicBlade : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Cosmic Blade");
            // Tooltip.SetDefault("Press right click to throw it.");
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

			Item.crit = 8;

			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.autoReuse = true;
			ItemID.Sets.ItemsThatAllowRepeatedRightClick[Type] = true;
		}

        public override bool CanUseItem(Player player)
        {
			if (player.altFunctionUse == 2)
            {
				Item.shoot = ModContent.ProjectileType<CosmicBladeProjectile2>();
                Item.damage = 52;
                Item.shootSpeed = 10f;
			}
            else
            {
				Item.shoot = ModContent.ProjectileType<CosmicBladeProjectile>();
                Item.damage = 104;
                Item.shootSpeed = 8.2f;
			}
			return true;			
        }

        public override bool? UseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                Item.useAnimation = 20;
                Item.useTime = 20;
            }
            else
            {
                Item.useAnimation = 10;
                Item.useTime = 10;
            }
            return true;
        }

        public override void ModifyWeaponCrit(Player player, ref float crit)
        {
			if (player.ZoneNormalSpace)
			{
				crit += 4;				
			}
		}
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            velocity = velocity.SafeNormalize(Vector2.Zero).RotatedBy(MathHelper.PiOver4 * (Main.rand.NextFloat() - 0.5f)) * (velocity.Length() - Main.rand.NextFloatDirection() * 0.8f);
        }

        public override void ModifyWeaponDamage(Player player, ref StatModifier damage)
        {
            if (player.ZoneNormalSpace)
			{
				damage += 4;
			}
        }

        public override bool AltFunctionUse(Player player)
        {
			return player.ownedProjectileCounts[ModContent.ProjectileType<CosmicBladeProjectile2>()] < 8;
		}

    }
}
