using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MoreShortswords.Content.Weapons;

namespace MoreShortswords.Content.Projectiles
{
    public class NaturesBlessProjectile : ShortSwordProjectile
    {
        public override string Texture => ModContent.GetInstance<NaturesBless>().Texture;

        public override void SetDefaults()
        {
            base.SetDefaults();
            Projectile.Size = new(64);
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 17;
        }

        public override void AI()
        {
            base.AI();  

            Dust TestDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.GrassBlades, Projectile.velocity.X * 0.8f, Projectile.velocity.Y * 0.8f, 128, default, 1.4f);
            TestDust.velocity *= 0.4f;
            TestDust.noGravity = true;
        }

        Player Owner => Main.player[Projectile.owner];
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {           
            if (!Owner.dryadWard && Main.rand.NextBool(2))
            {
                Owner.AddBuff(BuffID.DryadsWard, 900);
            }

            if (Main.rand.NextBool(3))
            {
                target.AddBuff(BuffID.DryadsWardDebuff, 600);
                target.AddBuff(BuffID.Venom, 600);
            }

            if (Owner.GetModPlayer<MoreShortPlayer>().swordTimer == 0)
            {
                Owner.GetModPlayer<MoreShortPlayer>().swordTimer = 20;
            }
            else
            {
                return;
            }

            if (!target.immortal && !target.SpawnedFromStatue && !NPCID.Sets.CountsAsCritter[target.type])
            {           
                Projectile.NewProjectile(target.GetSource_OnHit(target), Projectile.Center, Projectile.velocity, ModContent.ProjectileType<NatureThornBase>(), Projectile.damage, 0f, Owner.whoAmI);
            }            
        }
    }
}
