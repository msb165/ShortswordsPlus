using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using MoreShortswords.Content.Projectiles;
using Microsoft.Xna.Framework;

namespace MoreShortswords.Content.Weapons
{
    public class Ladnerud : ModItem
    {       
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;            
        }

        public override void SetDefaults()
        {
            Item.Size = new(48);
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
            Item.shootSpeed = 4f;
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
            velocity = velocity.RotatedByRandom(MathHelper.ToRadians(5f));
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
