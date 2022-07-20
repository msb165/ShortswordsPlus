using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace MoreShortswords.Content.Projectiles
{
    public class FieryShortProjectile : ShortSwordProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Molten Shortsword Projectile");            
        }
        public override void SetDefaults()
        {
            base.SetDefaults();   
            Projectile.ArmorPenetration = 2;
        }

        public override void AI()
        {
            base.AI();
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2 - MathHelper.PiOver4 * Projectile.spriteDirection;

            if (!Main.dedServ)
            {
                int fireDust = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Torch, Projectile.velocity.X * 0.2f + (Projectile.spriteDirection * 3), Projectile.velocity.Y * 0.2f, 128, default, 1.2f);
                Main.dust[fireDust].velocity.X *= 2f;
                Main.dust[fireDust].velocity.Y *= 2f;
                Main.dust[fireDust].noGravity = true;
            }

            SetVisualOffsets();
        }

        public override void OnHitNPC(NPC target, int damage, float knockBack, bool crit)
        {
            if (Main.rand.NextBool(3))
            {
                target.AddBuff(BuffID.OnFire, 120, false);
            }    
       
        }

        private void SetVisualOffsets()
        {           
           
            int halfProjWidth = Projectile.width / 2;
            int halfProjHeight = Projectile.height / 2;

            DrawOriginOffsetX = 0;
            DrawOffsetX = -((42 / 2) - halfProjWidth);
            DrawOriginOffsetY = -((42 / 2) - halfProjHeight);
        }
    }
}
