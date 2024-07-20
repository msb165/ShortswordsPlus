using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using MoreShortswords.Content.Projectiles;

namespace MoreShortswords.Content.Weapons
{
	public class CosmicBlade : ModItem
	{
		public override void SetStaticDefaults()
		{
            Item.ResearchUnlockCount = 1;
		}

		public override void SetDefaults()
		{
			Item.Size = new(56);
			Item.useStyle = ItemUseStyleID.Rapier;
			Item.useAnimation = 10;
			Item.useTime = 10;
			Item.UseSound = SoundID.Item1;
			Item.damage = 105;
			Item.knockBack = 7f;
			Item.rare = ItemRarityID.Yellow;
			Item.value = Item.sellPrice(0, 1, 35, 15);
			Item.DamageType = DamageClass.MeleeNoSpeed;
			Item.crit = 8;
			Item.shoot = ModContent.ProjectileType<CosmicBladeProjectile>();
			Item.shootSpeed = 6f;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.autoReuse = true;
		}

		private int shootCounter;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            shootCounter++;
            if (shootCounter == 3)
            {
                shootCounter = 0;
                Projectile.NewProjectile(source, position, velocity * 2f, ModContent.ProjectileType<CosmicBladeThrown>(), (int)(damage * 1.25f), knockback, player.whoAmI);
				return false;
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

        public override void ModifyWeaponDamage(Player player, ref StatModifier damage)
        {
            if (player.ZoneNormalSpace)
			{
				damage += 4;
			}
        }
    }
}
