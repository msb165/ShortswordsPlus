using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using MoreShortswords.Content.Projectiles;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace MoreShortswords.Content.Weapons
{
    public class ShortswordOfGrass : ModItem
    {
        private int swingCounter;
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Grassy Shiv");
            // Tooltip.SetDefault("20% chance of inflicting poison on an enemy.");
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 36;
            Item.height = 38;

            Item.useStyle = ItemUseStyleID.Rapier;
            Item.useTime = 23;
            Item.useAnimation = 23;
            Item.UseSound = SoundID.Item1;
            Item.ArmorPenetration = 5;

            Item.knockBack = 3.5f;            

            Item.damage = 16;
            Item.DamageType = DamageClass.MeleeNoSpeed;

            Item.rare = ItemRarityID.Orange;
            Item.value = Item.sellPrice(0, 0, 50, 0);

            Item.shoot = ModContent.ProjectileType<ShortGrassProjectile>();
            Item.shootSpeed = 3.3f;

            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.autoReuse = true;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            swingCounter++;
            if (swingCounter == 2)
            {
                Projectile stingerProj = Projectile.NewProjectileDirect(source, position, velocity * 2f, ProjectileID.Stinger, damage / 2, 3f, player.whoAmI);
                stingerProj.timeLeft = 90;
                stingerProj.hostile = false;
                stingerProj.friendly = true;
                swingCounter = 0;
            }
            return true;
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            velocity = velocity.RotatedByRandom(MathHelper.ToRadians(25));
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.JungleSpores, 6)
                .AddIngredient(ItemID.Stinger, 6)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
