using Microsoft.Xna.Framework;
using MoreShortswords.Content.Weapons;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoreShortswords.Content.Projectiles
{
    public class ChaosControlProjectile : ShortSwordProjectile
    {
        public override string Texture => ModContent.GetInstance<ChaosControl>().Texture;
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Chaos Control");
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
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.Confused, 300);
            target.AddBuff(BuffID.Weak, 200);

        }


        public override void SetVisualOffsets()
        {
            int halfProjWidth = Projectile.width / 2;
            int halfProjHeight = Projectile.height / 2;

            DrawOriginOffsetX = 0;
            DrawOffsetX = -((45 / 2) - halfProjWidth);
            DrawOriginOffsetY = -((45 / 2) - halfProjHeight);
        }
    }
}
