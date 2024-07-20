using Microsoft.Xna.Framework;
using Mono.Cecil;
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
            if (Projectile.ai[1] == 0f)
            {
                Projectile.ai[1] = 1f;
                Projectile proj = Projectile.NewProjectileDirect(Projectile.GetSource_FromAI(), Projectile.Center + Vector2.Normalize(Projectile.velocity) * 45f, Projectile.velocity * 3f, ModContent.ProjectileType<ChaosControlProjectile2>(), Projectile.damage, Projectile.knockBack, Projectile.owner);
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.Confused, 300);
            target.AddBuff(BuffID.Weak, 200);

        }


        public override void SetVisualOffsets()
        {
            base.SetVisualOffsets();
        }
    }
}
