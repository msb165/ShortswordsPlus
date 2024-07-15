using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using MoreShortswords.Content.Projectiles;
using Microsoft.Xna.Framework;

namespace MoreShortswords.Content.Weapons
{
    public class GoblinShort : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Warrior's Shortsword");
            Item.ResearchUnlockCount = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 32;
            Item.useStyle = ItemUseStyleID.Rapier;
            Item.useTime = 7;
            Item.useAnimation = 21;
            Item.reuseDelay = 14;
            Item.UseSound = SoundID.Item1;
            Item.knockBack = 5f;
            Item.ArmorPenetration = 5;
            Item.damage = 11;
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.crit = 6;
            Item.rare = ItemRarityID.White;
            Item.value = Item.sellPrice(0, 0, 8, 0);
            Item.shoot = ModContent.ProjectileType<GoblinShortProjectile>();
            Item.shootSpeed = 3f;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.autoReuse = true;
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            velocity = velocity.RotatedByRandom(MathHelper.ToRadians(30f));
        }
    }
}
