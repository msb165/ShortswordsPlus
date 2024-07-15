using MoreShortswords.Content.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace MoreShortswords.Content.Projectiles
{
    public class SuperFrostProjectile : ShortSwordProjectile
    {
        public override string Texture => ModContent.GetInstance<SuperFrost>().Texture;
        public override void SetDefaults()
        {
            base.SetDefaults();
            Projectile.Size = new(42);
        }

        public override void AI()
        {
            base.AI();
        }

        public override void SetVisualOffsets()
        {
            base.SetVisualOffsets();
        }
    }
}
