using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using MoreShortswords.Content.Projectiles;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace MoreShortswords.Content.Weapons
{
    public class Betelguese : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Betelguese");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 98;
            Item.height = 98;

            Item.useStyle = ItemUseStyleID.Rapier;
            Item.useTime = 14;
            Item.useAnimation = 14;
            Item.UseSound = SoundID.Item1;

            Item.damage = 90;
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.ArmorPenetration = 20;

            Item.rare = ItemRarityID.Red;
            Item.value = Item.sellPrice(0, 8, 0, 0);

            Item.shoot = ModContent.ProjectileType<BetelgueseProjectile>();
            Item.shootSpeed = 8f;

            Item.crit = 15;

            Item.knockBack = 5.5f;

            Item.autoReuse = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectile(source, position, velocity * 2f, ModContent.ProjectileType<BetelgueseProjectile3>(), damage / 2, 5f, player.whoAmI);
            return true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<TrueStarFragment>(), 1)
                .AddIngredient(ItemID.FragmentSolar, 15)
                .AddIngredient(ItemID.LunarBar, 30)
                .AddIngredient(ItemID.FallenStar, 40)
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }
    }
}
