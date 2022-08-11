using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace MoreShortswords.Content.Projectiles
{
    public class LifeSplitterProjectile : ShortSwordProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Life Splitter");            
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
            Projectile.ArmorPenetration = 15;
            Projectile.tileCollide = false;
        }

        public override void AI()
        {
            base.AI();
            if (!Main.dedServ)
            {
                int TestDust = Dust.NewDust(new Vector2(Projectile.position.X + 0.25f, Projectile.position.Y), Projectile.width, Projectile.height, DustID.GemEmerald, Projectile.velocity.X * 0.8f + (Projectile.spriteDirection * 3), Projectile.velocity.Y * 0.2f, 128, default, 1.4f);
                Main.dust[TestDust].velocity *= 1.2f;
                Main.dust[TestDust].noGravity = true;
            }
            SetVisualOffsets();
        }

        private void SetVisualOffsets()
        {           

            int halfProjWidth = Projectile.width / 2;
            int halfProjHeight = Projectile.height / 2;

            DrawOriginOffsetX = 0;
            DrawOffsetX = -((48 / 2) - halfProjWidth);
            DrawOriginOffsetY = -((48 / 2) - halfProjHeight);
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

            if (!target.HasBuff(BuffID.CursedInferno))
            {
                target.AddBuff(BuffID.CursedInferno, 120);
            }

            if (Main.rand.NextBool(4)) 
            {
                target.AddBuff(BuffID.Weak, 120);
            }

            Player player = new();

            if (Main.rand.NextBool(2) && player.ownedProjectileCounts[ModContent.ProjectileType<LifeSplitterProjectile2>()] < 8 && target.type != NPCID.TargetDummy) 
            {
                for (int projsToSpawn = 0; projsToSpawn < 4; projsToSpawn++)
                {
                    Vector2 vector = new (target.Center.X + Main.rand.Next(-400, 400), target.Center.Y - Main.rand.Next(600, 800));
                    float num16 = target.Center.X + (Projectile.width / 2) - vector.X;
                    float num17 = target.Center.Y + (Projectile.height / 2) - vector.Y;
                    num16 += Main.rand.Next(-100, 101);
                    float num18 = (float)Math.Sqrt(num16 * num16 + num17 * num17);
                    num18 = 25f / num18;
                    num16 *= num18;
                    num17 *= num18;                    
                    Projectile.NewProjectile(target.GetSource_OnHit(target), vector, new Vector2(num16, num17), ModContent.ProjectileType<LifeSplitterProjectile2>(), 32, 5f, player.whoAmI, 0f, 0f);
                }
            }

        }
    }
}
