using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MoreShortswords.Content.Weapons;
using Terraria.GameContent.ItemDropRules;

namespace MoreShortswords.Content.ItemDropRules
{
    public class BossBagDrop : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.BrainOfCthulhuBossBag || item.type == ItemID.EaterOfWorldsBossBag;
        }

        public override void ModifyItemLoot(Item item, ItemLoot itemLoot)
        {
            if (item.type == ItemID.BrainOfCthulhuBossBag || item.type == ItemID.EaterOfWorldsBossBag)
            {
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Moonlight>(), 1, 1, 1));
            }
        }
    }
}
