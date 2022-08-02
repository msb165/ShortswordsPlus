using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace MoreShortswords.Content.Projectiles
{
    public class ChaosControlProjectile3 : ModProjectile
    {
        public override string Texture => $"Terraria/Images/Projectile_{ProjectileID.WeatherPainShot}";

        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 8;
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.ownerHitCheck = true;
            Projectile.tileCollide = false;
            Projectile.width = 33;
            Projectile.height = 31;
            Projectile.ArmorPenetration = 25;
        }

        public override void AI()
        {            
            Projectile.rotation = Projectile.velocity.X * 0.0125f;

            if (++Projectile.frameCounter > 4)
            {
                Projectile.frameCounter = 0;
                Projectile.frame++;
                if (Projectile.frame >= Main.projFrames[Projectile.type])
                {
                    Projectile.frame = 0;
                }
            }

            Projectile.alpha += 1;           

            if (Projectile.alpha >= 255)
            {
                Projectile.Kill(); 
            }

            if (Main.rand.NextBool(200))
            {
                Projectile.velocity = -Projectile.velocity;
            }
   
            Projectile.ai[0]--;  
            Projectile.velocity.Y = (float)Math.Sin(Projectile.ai[0] * 0.5) * (float)Math.PI / 1.5f;          

        }
    }
}
