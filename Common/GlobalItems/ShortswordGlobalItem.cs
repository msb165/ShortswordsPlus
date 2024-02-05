using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace MoreShortswords.Common.GlobalItems
{
    internal class ShortswordGlobalItem : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return entity.useStyle is ItemUseStyleID.Rapier or ItemUseStyleID.Thrust;
        }

        public override void SetDefaults(Item item)
        {
            item.autoReuse = true;
        }

        public override void ModifyWeaponDamage(Item item, Player player, ref StatModifier damage)
        {
            if (item.type is ItemID.PlatinumShortsword or ItemID.GoldShortsword or ItemID.Gladius)
            {
                damage *= 1.1f;
            }
        }
    }
}
