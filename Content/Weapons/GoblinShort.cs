using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using MoreShortswords.Content.Projectiles;

namespace MoreShortswords.Content.Weapons
{
    public class GoblinShort : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Warrior's Shortsword");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;

            Item.useStyle = ItemUseStyleID.Rapier;
            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.UseSound = SoundID.Item1;

            Item.knockBack = 5.2f;

            Item.damage = 12;
            Item.DamageType = DamageClass.MeleeNoSpeed;

            Item.crit = 5;

            Item.rare = ItemRarityID.White;
            Item.value = Item.sellPrice(0, 0, 6, 17);

            Item.shoot = ModContent.ProjectileType<GoblinShortProjectile>();
            Item.shootSpeed = 3.1f;

            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.autoReuse = true;
        }
    }
}
