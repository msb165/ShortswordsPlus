using MoreShortswords.Content.Weapons;
using Terraria.ModLoader;

namespace MoreShortswords.Content.Projectiles
{
    public class EnchantedDaggerProjectile : ShortSwordProjectile
    {
        public override string Texture => ModContent.GetInstance<EnchantedDagger>().Texture;
        public override void SetDefaults()
        {
            base.SetDefaults();
            Projectile.Size = new(32);
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
