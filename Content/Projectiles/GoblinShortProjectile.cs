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
            Projectile.Size = new(14);        
        }
        public override void AI()
        {
            base.AI();
        }

        public override void SetVisualOffsets()
        {
            int halfProjWidth = Projectile.width / 2;
            int halfProjHeight = Projectile.height / 2;

            DrawOriginOffsetX = 0;
            DrawOffsetX = -((32 / 2) - halfProjWidth);
            DrawOriginOffsetY = -((32 / 2) - halfProjHeight);
        }
    }
}
