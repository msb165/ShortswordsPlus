using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System;

namespace MoreShortswords.Content.Projectiles
{
    public class StarFragmentProjectile : ShortSwordProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star Fragment");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Projectile.ArmorPenetration = 5;
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
            DrawOffsetX = -((40 / 2) - halfProjWidth);
            DrawOriginOffsetY = -((40 / 2) - halfProjHeight);
        }


        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Weak, 60);

            
            if (Main.rand.NextBool(2) && target.type != NPCID.TargetDummy)
            {
                for (int numOfStars = 0; numOfStars < 3; numOfStars++)
                {
                    Vector2 vector = new Vector2(target.position.X + 400, Projectile.position.Y - Main.rand.Next(500, 800));
                    float num16 = Projectile.position.X + (Projectile.width / 2) - vector.X;
                    float num17 = Projectile.position.Y + (Projectile.height / 2) - vector.Y;
                    num16 += Main.rand.Next(-100, 101);
                    float num18 = (float)Math.Sqrt(num16 * num16 + num17 * num17);
                    num18 = 25f / num18;
                    num16 *= num18;
                    num17 *= num18;
                    Player player = new();
                    
                    Projectile.NewProjectile(target.GetSource_OnHit(target), vector, new Vector2(num16, num17), ProjectileID.StarCloakStar, 10, 4f, player.whoAmI, 0f, Projectile.position.Y);

                }
            }
            

        }
    }
}
