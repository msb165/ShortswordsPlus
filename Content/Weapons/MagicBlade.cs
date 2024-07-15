using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using MoreShortswords.Content.Projectiles;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace MoreShortswords.Content.Weapons
{
    public class MagicBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Deity Spear");
            // Tooltip.SetDefault("Press right click to throw it.\n You can throw 2 at the same time.");
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 50;
            Item.height = 50;
            Item.useStyle = ItemUseStyleID.Rapier;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.UseSound = SoundID.Item1;
            Item.knockBack = 5.2f;
            Item.damage = 40;
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.shoot = ModContent.ProjectileType<MagicBladeProjectile>();
            Item.shootSpeed = 4.2f;
            Item.rare = ItemRarityID.Pink;
            Item.value = Item.sellPrice(0, 1, 80, 0);
            Item.ArmorPenetration = 10;
            Item.crit = 4;  
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.autoReuse = true;
        }

        public override bool CanUseItem(Player player) => player.ownedProjectileCounts[ModContent.ProjectileType<MagicBladeProjectile2>()] < 1;

        private int shootCounter;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            shootCounter++;
            if (shootCounter == 3)
            {
                shootCounter = 0;
                Projectile.NewProjectile(source, position, velocity * 1.25f, ModContent.ProjectileType<MagicBladeProjectile2>(), (int)(damage * 1.5f), knockback, player.whoAmI);
            }
            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.CobaltBar, 7)
                .AddIngredient(ItemID.EnchantedBoomerang, 1)
                .AddTile(TileID.MythrilAnvil)
                .Register();
            CreateRecipe()
                .AddIngredient(ItemID.PalladiumBar, 7)
                .AddIngredient(ItemID.EnchantedBoomerang, 1)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}
