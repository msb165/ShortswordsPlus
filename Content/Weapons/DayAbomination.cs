using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using MoreShortswords.Content.Projectiles;

namespace MoreShortswords.Content.Weapons
{
    public class DayAbomination : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Daylight's Abomination");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Thrust;
            Item.useAnimation = 23;
            Item.useTime = 23;
            Item.UseSound = SoundID.Item71;

            Item.damage = 32;
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.knockBack = 4.2f;

            Item.shoot = ModContent.ProjectileType<DayAbominationProjectile>();
            Item.shootSpeed = 3.5f;

            Item.rare = ItemRarityID.Orange;
            Item.value = Item.sellPrice(0, 0, 60, 23);

            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.autoReuse = true;
        }


        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {            
            Projectile.NewProjectile(source, position, velocity * 3.7f, ModContent.ProjectileType<DayAbominationProjectile2>(), 6, 3.5f, player.whoAmI);            
            return true;
        }            

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<ShortswordOfGrass>(), 1)
                .AddIngredient(ModContent.ItemType<FireyShortsword>(), 1)
                .AddIngredient(ModContent.ItemType<MuramasaShortsword>(), 1)
                .AddIngredient(ItemID.CopperShortsword, 1)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
