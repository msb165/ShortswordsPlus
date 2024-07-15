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
            Projectile.Size = new(40);
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 20;
        }

        public override void AI()
        {
            base.AI();
            Projectile.alpha += 64;
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

        public override void SetVisualOffsets()
        {
            base.SetVisualOffsets();
        }
    }
}
