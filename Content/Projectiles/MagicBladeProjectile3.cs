using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;


namespace MoreShortswords.Content.Projectiles
{
    public class MagicBladeProjectile3 : ModProjectile
    {
        public override string Texture => "MoreShortswords/Content/Projectiles/MagicBladeProjectile";

        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Deity Spear");           
        }

        public override void SetDefaults()
        {            
            Projectile.width = 16;
            Projectile.height = 200;
            Projectile.penetrate = -1;
            Projectile.friendly = true;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 300;
            Projectile.ArmorPenetration = 30;
            Projectile.alpha = 255;
        }

        public override void AI()
        {           
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2 - MathHelper.PiOver4 * Projectile.spriteDirection;

            float num747 = Projectile.width * Projectile.height * 0.0045f;
            for (int num748 = 0; num748 < num747 / 2; num748++)
            {
                int wallDust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Clentaminator_Cyan, 0f, 0f, 255, default, 0.8f);
                Main.dust[wallDust].noGravity = true;
                Dust dust2 = Main.dust[wallDust];
                dust2.velocity *= 0.5f;       
                Main.dust[wallDust].velocity.Y -= 0.5f;
                Main.dust[wallDust].position.X += 6f;
                Main.dust[wallDust].position.Y -= 2f;
            }

        }

    }
}
