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
            DisplayName.SetDefault("Apogee");
            Tooltip.SetDefault("\"Say goodbye to death.\"");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 100;
            Item.height = 100;

            Item.useStyle = ItemUseStyleID.Rapier;
            Item.useAnimation = 12;
            Item.useTime = Item.useAnimation / 2;            

            Item.UseSound = SoundID.Item1;

            Item.damage = 120;
            Item.knockBack = 6.7f;

            Item.rare = ItemRarityID.Red;
            Item.value = Item.sellPrice(0, 3, 50, 50);

            Item.DamageType = DamageClass.MeleeNoSpeed;

            Item.shoot = ModContent.ProjectileType<FinalSwordProjectile>();
            Item.shootSpeed = 15f;

            Item.crit = 14;

            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.autoReuse = true;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.ownedProjectileCounts[ModContent.ProjectileType<FinalSwordProjectile2>()] < 6)
            {
                Projectile.NewProjectile(source, new Vector2(position.X, position.Y), velocity * 1.25f, ModContent.ProjectileType<FinalSwordProjectile2>(), (int)(Item.damage * 1.25f), 4f, player.whoAmI);                
            }
            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<NaturesBless>(), 1)
                .AddIngredient(ModContent.ItemType<DayAbomination>(), 1)
                .AddIngredient(ModContent.ItemType<CosmicBlade>(), 1)
                .AddIngredient(ModContent.ItemType<SkyBlade>(), 1)
                .AddIngredient(ItemID.PlatinumShortsword, 1)                
                .AddIngredient(ItemID.LunarBar, 10)
                .AddTile(TileID.LunarCraftingStation)
                .Register();            
        }
    }
}
