using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoreShortswords.Content.Projectiles
{
    public class FrozenBolt : ModProjectile
    {
        public override string Texture => $"Terraria/Images/Projectile_{ProjectileID.FrostBoltSword}";
        public override void SetDefaults()
        {
            Projectile.Size = new(6);
            Projectile.aiStyle = -1;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = 2;
            Projectile.alpha = 255;
            Projectile.friendly = true;
            Projectile.tileCollide = true;
            Projectile.coldDamage = true;
        }

        public override void AI()
        {
            Projectile.velocity.Y += 0.4f;
            for (int i = 0; i < 3; i++) 
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, 10, 10, DustID.IceTorch, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 0, default, 2f);
                dust.position = Projectile.Center;
                dust.scale *= 1.25f;
                dust.noGravity = true;
                dust.velocity *= 0.5f;
                Dust dust2 = Dust.NewDustDirect(Projectile.position, 10, 10, DustID.SpectreStaff, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 0, Color.SkyBlue, 2f);
                dust2.position = Projectile.Center;
                dust2.scale *= 1.25f;
                dust2.noGravity = true;
                dust2.velocity *= 0.5f;
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.Frostburn2, 600);
        }

        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item27, Projectile.position);
            for (int i = 0; i < 30; i++)
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, 10, 10, DustID.IceTorch, 0, 0, 0, default, 1.5f);
                dust.scale *= 1.25f;
                dust.noGravity = true;
                dust.velocity *= 8f;
            }
        }
    }
}
