using Terraria;
using Terraria.ID;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;
using MoreShortswords.Content.Weapons;
using MoreShortswords.Content.Accessories;

namespace MoreShortswords.Content
{
    public class NPCDropRules : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            Conditions.NotExpert condition = new();

            if (npc.boss && System.Array.IndexOf(new int[] { NPCID.EaterofWorldsBody, NPCID.EaterofWorldsHead, NPCID.EaterofWorldsTail }, npc.type) > -1 || npc.boss && npc.type == NPCID.BrainofCthulhu)
            {
                npcLoot.Add(ItemDropRule.ByCondition(condition, ModContent.ItemType<Moonlight>()));
            }

            switch(npc.type)
            {
                case NPCID.GoblinWarrior:
                case NPCID.GoblinThief:
                    npcLoot.Add(ItemDropRule.WithRerolls(ModContent.ItemType<GoblinShort>(), 1, 8, 1));
                    break;
                case NPCID.MartianSaucerCore:
                    npcLoot.Add(ItemDropRule.WithRerolls(ModContent.ItemType<CosmicBlade>(), 1, 3, 1));
                    break;
                case NPCID.Psycho:
                    npcLoot.Add(ItemDropRule.WithRerolls(ModContent.ItemType<TriangleSword>(), 1, 20, 1));
                    break;
                case NPCID.Mimic:
                    npcLoot.Add(ItemDropRule.WithRerolls(ModContent.ItemType<StrangeSword>(), 1, 5, 1));
                    break;
                case NPCID.Harpy:
                    npcLoot.Add(ItemDropRule.WithRerolls(ModContent.ItemType<EnchantedDagger>(), 1, 4, 1));
                    break;                  
            }
        }
    }
}
