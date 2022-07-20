using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using MoreShortswords.Content.Projectiles;

namespace MoreShortswords.Content.Weapons
{
    public class TriangleSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Killer's Blade");
            Tooltip.SetDefault("33% chance to inflict weakness and bleeding on an enemy.");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 50;
            Item.height = 50;

            Item.useStyle = ItemUseStyleID.Rapier;
            Item.useTime = 13;
            Item.useAnimation = 13;
            Item.UseSound = SoundID.Item1;

            Item.damage = 96;
            Item.DamageType = DamageClass.MeleeNoSpeed;

            Item.rare = ItemRarityID.Lime;
            Item.value = Item.sellPrice(0, 0, 90, 25);

            Item.shoot = ModContent.ProjectileType<TriangleSwordProjectile>();
            Item.shootSpeed = 6.5f;

            Item.knockBack = 5f;

            Item.autoReuse = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;
        }
    }
}
