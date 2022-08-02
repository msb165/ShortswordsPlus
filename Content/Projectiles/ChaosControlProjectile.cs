using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace MoreShortswords.Content.Projectiles
{
    public class ChaosControlProjectile : ShortSwordProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chaos Control");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Projectile.ArmorPenetration = 20;
            Projectile.width = 45;
            Projectile.height = 45;
        }

        public override void AI()
        {
            base.AI();
            SetVisualOffsets();
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (!target.HasBuff(BuffID.Confused) && !target.HasBuff(BuffID.Weak))
            {
                target.AddBuff(BuffID.Confused, 300);
                target.AddBuff(BuffID.Weak, 200);
            }
        }


        private void SetVisualOffsets()
        {
            int halfProjWidth = Projectile.width / 2;
            int halfProjHeight = Projectile.height / 2;

            DrawOriginOffsetX = 0;
            DrawOffsetX = -((50 / 2) - halfProjWidth);
            DrawOriginOffsetY = -((50 / 2) - halfProjHeight);
        }

    }
}
