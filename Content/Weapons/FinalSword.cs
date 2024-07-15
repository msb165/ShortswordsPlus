using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using MoreShortswords.Content.Projectiles;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace MoreShortswords.Content.Weapons
{
    public class FinalSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 100;
            Item.height = 100;
            Item.useStyle = ItemUseStyleID.Rapier;
            Item.useAnimation = 6;
            Item.useTime = 6;           
            Item.UseSound = SoundID.Item1;
            Item.damage = 150;
            Item.ArmorPenetration = 20;
            Item.knockBack = 6f;
            Item.rare = ItemRarityID.Red;
            Item.value = Item.sellPrice(0, 8, 0, 0);
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.shoot = ModContent.ProjectileType<FinalSwordProjectile>();
            Item.shootSpeed = 7.5f;
            Item.crit = 12;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.autoReuse = true;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            for (int i = -1; i <= 1; i++)
            {
                float j = i == 0 ? 0 : 1;

                Vector2 spinningPoint = velocity.RotatedBy(MathHelper.ToRadians(15f * i));
                Projectile.NewProjectile(source, position, spinningPoint, type, damage, knockback, player.whoAmI, 0f, j);   
            }

            Vector2 speed = velocity.RotatedByRandom(MathHelper.ToRadians(15f)) * Main.rand.NextFloat(0.75f, 1.1f);
            if (Main.rand.NextBool(4))
            {
                Projectile.NewProjectile(source, position, speed, ModContent.ProjectileType<HomingFinalSword>(), damage / 4, knockback, player.whoAmI);
            }

            return false;
        }


        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<NaturesBless>(), 1)
                .AddIngredient(ModContent.ItemType<DayAbomination>(), 1)
                .AddIngredient(ModContent.ItemType<CosmicBlade>(), 1)
                .AddIngredient(ModContent.ItemType<SkyBlade>(), 1)
                .AddIngredient(ModContent.ItemType<EnchantedDagger>(), 1)
                .AddIngredient(ItemID.PlatinumShortsword, 1)                
                .AddIngredient(ItemID.LunarBar, 30)
                .AddTile(TileID.LunarCraftingStation)
                .Register();            
        }
    }
}
