using MoreShortswords.Content.Weapons;
using Terraria;
using Terraria.ModLoader;

namespace MoreShortswords.Content.Projectiles
{
    public class GoblinShortProjectile : ShortSwordProjectile
    {
        public override string Texture => ModContent.GetInstance<GoblinShort>().Texture;

        public override void SetDefaults()
        {
            base.SetDefaults();
            Projectile.width = 14;
            Projectile.height = 14;            
        }
        public override void AI()
        {
            base.AI();
        }   
    }
}
