using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using MoreShortswords.Content.Projectiles;
using Microsoft.Xna.Framework;

namespace MoreShortswords.Content.Weapons
{
    public class CactusShort : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Cactus Shortsword");
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;

            Item.useStyle = ItemUseStyleID.Rapier;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.UseSound = SoundID.Item1;

            Item.knockBack = 4.5f;

            Item.damage = 12;
            Item.DamageType = DamageClass.MeleeNoSpeed;

            Item.rare = ItemRarityID.White;
            Item.value = Item.sellPrice(0, 0, 1, 0);

            Item.shoot = ModContent.ProjectileType<CactusShortProjectile>();            
            Item.shootSpeed = 3f;

            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.autoReuse = true;
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            velocity = velocity.SafeNormalize(Vector2.Zero).RotatedBy(MathHelper.PiOver4 * (Main.rand.NextFloat() - 0.5f)) * (velocity.Length() - Main.rand.NextFloatDirection() * 0.7f);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Cactus, 5)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}
