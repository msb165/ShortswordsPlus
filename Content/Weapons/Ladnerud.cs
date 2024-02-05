using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using MoreShortswords.Content.Projectiles;
using Microsoft.Xna.Framework;

namespace MoreShortswords.Content.Weapons
{
    public class Ladnerud : ModItem
    {       
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Hallowed Shiv");
            // Tooltip.SetDefault("15% more damage if standing in a hallowed biome");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;            
        }

        public override void SetDefaults()
        {
            Item.width = 48;
            Item.height = 48;

            Item.useStyle = ItemUseStyleID.Rapier;
            Item.useTime = 18;
            Item.useAnimation = 18;
            Item.UseSound = SoundID.Item1;

            Item.knockBack = 5.2f;
            Item.damage = 70;

            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.ArmorPenetration = 15;

            Item.rare = ItemRarityID.Pink;
            Item.value = Item.sellPrice(0, 1, 40, 0);

            Item.shoot = ModContent.ProjectileType<LadnerudProjectile>();
            Item.shootSpeed = 5f;

            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.autoReuse = true;            
        }

        public override void ModifyWeaponDamage(Player player, ref StatModifier damage)
        {
            if (player.ZoneHallow)
            {
                damage *= 1.15f;
            }
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            velocity = velocity.SafeNormalize(Vector2.Zero).RotatedBy(MathHelper.PiOver4 * (Main.rand.NextFloat() - 0.5f)) * (velocity.Length() - Main.rand.NextFloatDirection() * 0.8f);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.HallowedBar, 7)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}
