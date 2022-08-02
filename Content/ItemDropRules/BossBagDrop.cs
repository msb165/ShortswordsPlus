using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MoreShortswords.Content.Weapons;

namespace MoreShortswords.Content.ItemDropRules
{
    public class BossBagDrop : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.BrainOfCthulhuBossBag || item.type == ItemID.EaterOfWorldsBossBag;
        }

        public override void OpenVanillaBag(string context, Player player, int arg)
        {
            var entitySource = player.GetSource_OpenItem(arg, context);
            if (context == "bossBag" && arg == ItemID.BrainOfCthulhuBossBag || arg == ItemID.EaterOfWorldsBossBag)
            {
                player.QuickSpawnItem(entitySource, ModContent.ItemType<MuramasaShortsword>(), 1); ;
            }            
        }

    }
}
