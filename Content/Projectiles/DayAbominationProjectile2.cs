using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using System;
namespace MoreShortswords.Content.Projectiles
{
    public class DayAbominationProjectile2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Daylight's Abomination");
        }
        public override void SetDefaults()
        {       
            Projectile.penetrate = 2;
            Projectile.friendly = true;
            Projectile.width = 10;
            Projectile.height = 10;
            Projectile.timeLeft = 40;
            Projectile.Opacity = 0.6f;
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.Transparent;
        }

        public override void AI()
        {
            int fireDust = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Pixie, Projectile.velocity.X, Projectile.velocity.Y, 255, default, 1.2f);
            Main.dust[fireDust].noGravity = true;
            Dust secFireDust = Main.dust[fireDust];
            secFireDust.velocity *= 0.3f;            

            Projectile.rotation = Projectile.velocity.ToRotation();

            if (Projectile.timeLeft == 0)
            {
                Kill(Projectile.timeLeft);
            }

            if (Projectile.ai[1] == 0f)
            {
                Projectile.ai[1] = 1f;
                SoundEngine.PlaySound(SoundID.Item8, Projectile.position);
            }
        }

        public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.NPCHit3, Projectile.position);
            for (int numOfParticles = 0; numOfParticles < 16; numOfParticles++) 
            { 
                int dustExplode = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Pixie, Projectile.oldVelocity.X, Projectile.oldVelocity.Y, 255, default, 1.2f);
                Main.dust[dustExplode].noGravity = true;
                Dust dustExplodeAlt = Main.dust[dustExplode];
                dustExplodeAlt.scale *= 1.25f;
                dustExplodeAlt.velocity *= 0.5f;
                Projectile.rotation = Projectile.velocity.ToRotation();
            }
            Player player = new();                     

            for (int j = 0; j < 2; j++)
            {
                Vector2 newVelocity = Vector2.Normalize(Projectile.velocity) * 14f;
                float[] value = {0f, 3f, -3f};
                // newVelocity = newVelocity.RotatedBy(Projectile.rotation * MathHelper.PiOver2 - MathHelper.PiOver4);
                newVelocity = newVelocity.RotatedBy(value[j] * MathHelper.PiOver2 - MathHelper.PiOver4);
                Projectile.NewProjectile(Projectile.GetSource_Death(), new Vector2(Projectile.position.X + (10f * Projectile.direction), Projectile.position.Y + 10f), newVelocity, ModContent.ProjectileType<DayAbominationProjectile3>(), Projectile.damage / 2, 4f, player.whoAmI);
                 
            }          
            
        }

    }
}
