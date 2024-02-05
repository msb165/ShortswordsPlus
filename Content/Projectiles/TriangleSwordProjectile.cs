using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using MoreShortswords.Content.Weapons;
using Terraria.ModLoader;

namespace MoreShortswords.Content.Projectiles
{
    public class TriangleSwordProjectile : ShortSwordProjectile
    {
        public override string Texture => ModContent.GetInstance<TriangleSword>().Texture;
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Killer's Rapier");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();           
            Projectile.width = 40;
            Projectile.height = 50;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 20;
        }

        public override void AI()
        {
            base.AI();
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2 - MathHelper.PiOver4 * Projectile.spriteDirection;
            Projectile.alpha += 50;
            SetVisualOffsets();
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Main.rand.NextBool(3) && !target.HasBuff(BuffID.Weak) && !target.HasBuff(BuffID.Bleeding))
            {
                target.AddBuff(BuffID.Weak, 300);
                target.AddBuff(BuffID.Bleeding, 600);
            }
            if (Main.rand.NextBool(10) && !target.HasBuff(BuffID.Ichor) && target.boss)
            {
                target.AddBuff(BuffID.Ichor, 300);
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
