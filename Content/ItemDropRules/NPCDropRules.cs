using Terraria;
using Terraria.ID;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;
using MoreShortswords.Content.Weapons;
using Terraria.GameContent.Creative;

namespace MoreShortswords.Content
{
    public class NPCDropRules : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            Conditions.NotExpert condition = new();
            if (npc.boss && System.Array.IndexOf(new int[] { NPCID.EaterofWorldsBody, NPCID.EaterofWorldsHead, NPCID.EaterofWorldsTail }, npc.type) > -1 || npc.boss && npc.type == NPCID.BrainofCthulhu)
            {
              npcLoot.Add(ItemDropRule.ByCondition(condition, ModContent.ItemType<MuramasaShortsword>()));               
            }
            switch (npc.type)
            {
                case NPCID.GoblinWarrior:
                case NPCID.GoblinThief:
                    npcLoot.Add(ItemDropRule.WithRerolls(ModContent.ItemType<GoblinShort>(), 1, 4));
                    break;
                case NPCID.MartianSaucer:
                    npcLoot.Add(ItemDropRule.WithRerolls(ModContent.ItemType<CosmicBlade>(), 1, 3));
                    break;
                case NPCID.ZombieElf:
                    npcLoot.Add(ItemDropRule.WithRerolls(ModContent.ItemType<TriangleSword>(), 1, 20));
                    break;
            }
        }
    }
}
