using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using MoreShortswords.Content.Projectiles;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace MoreShortswords.Content.Weapons
{
    public class ChaosControl : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chaos Control");
            Tooltip.SetDefault("Press right click to throw a tornado.");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 50;
            Item.height = 50;

            Item.useStyle = ItemUseStyleID.Rapier;
            Item.UseSound = SoundID.Item1;

            Item.knockBack = 4.5f;

            Item.damage = 67;
            Item.DamageType = DamageClass.MeleeNoSpeed;

            Item.rare = ItemRarityID.Pink;
            Item.value = Item.sellPrice(0, 1, 55, 15);

            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.autoReuse = true;
        }

        public override bool AltFunctionUse(Player player)
        {
            return player.ownedProjectileCounts[ModContent.ProjectileType<ChaosControlProjectile3>()] < 6;
        }

        public override bool CanUseItem(Player player)
        {
            if(player.altFunctionUse == 2)
            {
                Item.shoot = ModContent.ProjectileType<ChaosControlProjectile3>();
                Item.shootSpeed = 7.0f;
                Item.useTime = 17;
                Item.useAnimation = 17;
            }
            else
            {
                Item.shoot = ModContent.ProjectileType<ChaosControlProjectile>();
                Item.shootSpeed = 5.4f;
                Item.useTime = 19;
                Item.useAnimation = 19;
            }
            return player.ownedProjectileCounts[ModContent.ProjectileType<ChaosControlProjectile3>()] < 6;
        }


        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.altFunctionUse != 2)
            { 
                Projectile.NewProjectile(source, position, velocity * 2f, ModContent.ProjectileType<ChaosControlProjectile2>(), 22, 4f, player.whoAmI);
            }
            
            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.HallowedBar, 8)
                .AddIngredient(ItemID.Cloud, 12)
                .AddIngredient(ItemID.SoulofFright, 8)
                .AddIngredient(ItemID.SoulofMight, 8)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}
