using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace MoreShortswords.Content.Buffs
{
    public class ProjectileSicknessDebuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Test\n Does Nothing");
            Main.debuff[Type] = true;           
            Main.pvpBuff[Type] = false;            
            Main.buffNoTimeDisplay[Type] = true;
            
        }
    }    
}
