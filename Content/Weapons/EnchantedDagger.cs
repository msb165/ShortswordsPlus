using Microsoft.Xna.Framework;
using MoreShortswords.Content.Projectiles;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoreShortswords.Content.Weapons
{
    public class EnchantedDagger : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Spellbind");
        }
        public override void SetDefaults()
        {
            Item.width = Item.height = 32;
            Item.damage = 12;
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.value = Item.sellPrice(0, 0, 80, 0);
            Item.rare = ItemRarityID.Green;

            Item.useStyle = ItemUseStyleID.Rapier;
            Item.UseSound = SoundID.Item1;
            Item.useTime = 20;
            Item.useAnimation = 20;

            Item.shoot = ModContent.ProjectileType<EnchantedDaggerProjectile>();
            Item.shootSpeed = 3f;

            Item.crit = 5;
            Item.knockBack = 4f;

            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.ResearchUnlockCount = 1;
        }

        private int swingCounter = 0;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            swingCounter++;
            if (swingCounter == 3)
            {
                swingCounter = 0;
                Projectile.NewProjectile(source, position, velocity * 3f, ProjectileID.EnchantedBeam, (int)(damage * 1.15f), knockback, player.whoAmI);
            }
            return true;
        }
    }
}
