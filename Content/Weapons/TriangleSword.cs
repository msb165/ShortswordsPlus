using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using MoreShortswords.Content.Projectiles;
using Microsoft.Xna.Framework;

namespace MoreShortswords.Content.Weapons
{
    public class TriangleSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Killer's Blade");
            // Tooltip.SetDefault("33% chance to inflict weakness and bleeding on an enemy.");
            Item.ResearchUnlockCount = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 50;
            Item.height = 50;

            Item.useStyle = ItemUseStyleID.Rapier;
            Item.useTime = 2;
            Item.useAnimation = 13;
            Item.UseSound = SoundID.Item1;

            Item.damage = 5;
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.ArmorPenetration = 10;

            Item.rare = ItemRarityID.Lime;
            Item.value = Item.sellPrice(0, 2, 0, 0);

            Item.shoot = ModContent.ProjectileType<TriangleSwordProjectile>();
            Item.shootSpeed = 7f;

            Item.knockBack = 5f;

            Item.autoReuse = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            velocity = velocity.SafeNormalize(Vector2.Zero).RotatedBy(MathHelper.PiOver4 * (Main.rand.NextFloat() - 0.5f)) * (velocity.Length() - Main.rand.NextFloatDirection() * 0.7f);
        }
    }
}
