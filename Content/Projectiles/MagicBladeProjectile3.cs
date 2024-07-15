using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using MoreShortswords.Content.Weapons;

namespace MoreShortswords.Content.Projectiles
{
    public class MagicBladeProjectile3 : ModProjectile
    {
        public override string Texture => ModContent.GetInstance<MagicBlade>().Texture;

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Deity Spear's Blue Fire");            
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
            for (int i = 0; i < 7; i++)
            {
                Dust wallDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Clentaminator_Cyan, 0f, 0f, 255, default, 0.75f);
                wallDust.noGravity = true;
                Dust wallDust2 = wallDust;
                wallDust2.velocity *= 0.5f;       
                wallDust.velocity.Y -= 0.5f;
                wallDust.position.X += 6f;
                wallDust.position.Y -= 2f;
            }
        }
    }
}
