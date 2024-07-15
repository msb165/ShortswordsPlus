using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using MoreShortswords.Content.Weapons;
using Terraria.ModLoader;

namespace MoreShortswords.Content.Projectiles
{
    public class MoonlightProjectile : ShortSwordProjectile
    {
        public override string Texture => ModContent.GetInstance<Moonlight>().Texture;

        public override void SetDefaults()
        {
            base.SetDefaults();
            Projectile.Size = new(38);
        }     

        public override void AI()
        {
            base.AI();
            int TestDust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.DungeonWater, 0, 0, 128, default, 1.2f);
            Main.dust[TestDust].velocity *= 0.1f;
            Main.dust[TestDust].noGravity = true;
        }

        public override void SetVisualOffsets()
        {
            base.SetVisualOffsets();
        }      
    }
}
