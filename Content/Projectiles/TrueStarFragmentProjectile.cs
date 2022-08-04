using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace MoreShortswords.Content.Projectiles
{
    public class TrueStarFragmentProjectile : ShortSwordProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Star Fragment");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Projectile.ArmorPenetration = 20;
        }

        public override void AI()
        {
            base.AI();
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2 - MathHelper.PiOver4 * Projectile.spriteDirection;  

            if (!Main.dedServ)
            {
                int StarDust = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Enchanted_Gold, Projectile.velocity.X * 0.8f + (Projectile.spriteDirection * 3), Projectile.velocity.Y * 0.2f, 128, default, 1.2f);
                Main.dust[StarDust].velocity *= 0.2f;
                Main.dust[StarDust].rotation *= MathHelper.ToRadians(15f);                
                Main.dust[StarDust].noGravity = true;
                if (Main.rand.NextBool(4))
                {
                    Gore.NewGore(null, Projectile.position, Projectile.velocity * 0.2f, Utils.SelectRandom<int>(Main.rand, 16, 17, 17, 17), 0.6f);
                }
            }
            SetVisualOffsets();
        }

        private void SetVisualOffsets()
        {
            
            int halfProjWidth = Projectile.width / 2;
            int halfProjHeight = Projectile.height / 2;

            DrawOriginOffsetX = 0;
            DrawOffsetX = -((54 / 2) - halfProjWidth);
            DrawOriginOffsetY = -((54 / 2) - halfProjHeight);
        }


        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

            if (!target.HasBuff(BuffID.Weak))
            {
                target.AddBuff(BuffID.Weak, 200);
            }           
            
        }
    }
}
