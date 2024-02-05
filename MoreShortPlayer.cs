using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;

namespace MoreShortswords
{
    internal class MoreShortPlayer : ModPlayer
    {
        public int swordTimer;

        public override void PostUpdate()
        {
            if (swordTimer > 0)
            {
                swordTimer--;
            }
        }
    }
}
