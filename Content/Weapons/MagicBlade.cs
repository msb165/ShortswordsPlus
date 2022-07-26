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
            DisplayName.SetDefault("Deity Spear");
            Tooltip.SetDefault("Press right click to throw it.");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
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

            Item.damage = 59;
            Item.DamageType = DamageClass.MeleeNoSpeed;

            Item.rare = ItemRarityID.Pink;
            Item.value = Item.sellPrice(0, 0, 35, 15);

            Item.crit = 8;
                        
            Item.shootSpeed = 4.7f;            

            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.autoReuse = true;
        }

        public override bool AltFunctionUse(Player player)
        {                     
            return player.ownedProjectileCounts[ModContent.ProjectileType<MagicBladeProjectile2>()] < 1;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                Item.shoot = ModContent.ProjectileType<MagicBladeProjectile2>();
            }
            else
            {
                Item.shoot = ModContent.ProjectileType<MagicBladeProjectile>();
            }
            return player.ownedProjectileCounts[ModContent.ProjectileType<MagicBladeProjectile2>()] < 1 && player.ownedProjectileCounts[ModContent.ProjectileType<MagicBladeProjectile>()] < 1;
        }



        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.CobaltBar, 8)
                .AddIngredient(ItemID.SoulofMight, 8)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}
