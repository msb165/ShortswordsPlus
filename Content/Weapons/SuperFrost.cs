using Microsoft.Xna.Framework;
using MoreShortswords.Content.Projectiles;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoreShortswords.Content.Weapons
{
    public class SuperFrost : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 42;
            Item.height = 42;
            Item.useStyle = ItemUseStyleID.Rapier;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.UseSound = SoundID.Item1;
            Item.damage = 47;
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.knockBack = 4f;
            Item.rare = ItemRarityID.Pink;
            Item.value = Item.sellPrice(0, 0, 75, 0);
            Item.shoot = ModContent.ProjectileType<SuperFrostProjectile>();
            Item.shootSpeed = 3f;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.autoReuse = true;
        }

        private int shootCounter;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            shootCounter++;
            if (shootCounter > 2)
            {
                shootCounter = 0;
                Projectile.NewProjectileDirect(source, position, velocity * 4f, ModContent.ProjectileType<FrozenBolt>(), damage / 2, 4f, player.whoAmI);
            }
            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.FrostCore, 1)
                .AddIngredient(ModContent.ItemType<FrozenShort>(), 1)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}
