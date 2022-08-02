using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace MoreShortswords.Content.Projectiles
{ 

    public class ChaosControlProjectile2 : ModProjectile
    {
        public override string Texture => "MoreShortswords/Content/Projectiles/ChaosControlProjectile2";

        public override void SetDefaults()
        {            
            Projectile.ArmorPenetration = 20;
            Projectile.width = 40;
            Projectile.height = 40;
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
            Projectile.timeLeft = 300;
            Projectile.ownerHitCheck = true;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
        }

        public override void AI()
        {
            base.AI();
            //Main.NewText($"Projectile.alpha (ChaosProj2) = {Projectile.alpha}");
            //Main.NewText($"Projectile.timeLeft (ChaosProj2) = {Projectile.timeLeft}");
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2 - MathHelper.PiOver4 * Projectile.spriteDirection;

            if (Projectile.alpha < 0)
            {
                Projectile.alpha = 0;
            }

            Projectile.alpha += 10;
            if (Projectile.alpha >= 255)
            {
                Projectile.Kill();
            }
        }

    }
}
