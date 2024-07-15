using MoreShortswords.Content.Weapons;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoreShortswords.Content.Projectiles
{
    public class MagicBladeProjectile : ShortSwordProjectile
    {
        public override string Texture => ModContent.GetInstance<MagicBlade>().Texture;
        public override void SetDefaults()
        {
            base.SetDefaults();
            Projectile.Size = new(50);
            Projectile.ArmorPenetration = 15;
        }

        public override void AI()
        {
            base.AI();            
        }

        public override void SetVisualOffsets()
        {
            base.SetVisualOffsets();
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {            
            if (!target.HasBuff(BuffID.Bleeding))
            {
                target.AddBuff(BuffID.Bleeding, 300);
            }

            if (!target.immortal && !target.SpawnedFromStatue && !NPCID.Sets.CountsAsCritter[target.type]) 
            {
                Projectile.NewProjectile(target.GetSource_OnHit(target), Projectile.Center, Projectile.velocity*2f, ProjectileID.ThunderSpearShot, Projectile.damage / 2, 6f, Projectile.owner);
            }
        }
    }
}
