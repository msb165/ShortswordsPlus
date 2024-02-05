using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using MoreShortswords.Content.Weapons;
using Terraria.ModLoader;

namespace MoreShortswords.Content.Projectiles
{
    public class CactusShortProjectile : ShortSwordProjectile
    {
        public override string Texture => ModContent.GetInstance<CactusShort>().Texture;

        public override void SetDefaults()
        {
            base.SetDefaults();            
            Projectile.ArmorPenetration = 2;
            Projectile.width = 24;
            Projectile.height = 24;
        }

        public override void AI()
        {
            base.AI();            
            SetVisualOffsets();
        }

        private void SetVisualOffsets()
        {
            int halfProjWidth = Projectile.width / 2;
            int halfProjHeight = Projectile.height / 2;

            DrawOriginOffsetX = 0;
            DrawOffsetX = -((32 / 2) - halfProjWidth);
            DrawOriginOffsetY = -((32 / 2) - halfProjHeight);
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (!target.HasBuff(BuffID.Poisoned))
            {
                target.AddBuff(BuffID.Poisoned, 300);
            }
        }
    }
}
