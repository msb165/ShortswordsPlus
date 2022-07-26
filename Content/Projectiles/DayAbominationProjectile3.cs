using Microsoft.Xna.Framework;
using Terraria.Audio;
using Terraria.ID;
using Terraria;
namespace MoreShortswords.Content.Projectiles
{
    public class DayAbominationProjectile3 : DayAbominationProjectile2
    {
        public override string Texture => "MoreShortswords/Content/Projectiles/DayAbominationProjectile2";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Daylight's Abomination");
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.Transparent;
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
        }

        public override void AI()
        {
            base.AI();           
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
        }

    }
}
