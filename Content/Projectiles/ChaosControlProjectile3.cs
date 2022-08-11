using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MoreShortswords.Content.Projectiles
{
    public class ChaosControlProjectile3 : ModProjectile
    {
        public override string Texture => $"Terraria/Images/Projectile_{ProjectileID.WeatherPainShot}";

        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 8;
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 8;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
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

            if (Main.rand.NextBool(220))
            {
                Projectile.velocity = -Projectile.velocity;
            }
   
            Projectile.ai[0]--;
            Projectile.velocity.Y = (float)Math.Sin(MathHelper.Pi / 30f * (Projectile.ai[0] * 0.95)) * MathHelper.TwoPi * 1.25f;
        }
    }
}
