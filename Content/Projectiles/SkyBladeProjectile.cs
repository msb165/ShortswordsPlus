﻿using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;


namespace MoreShortswords.Content.Projectiles
{
    public class SkyBladeProjectile : ShortSwordProjectile
    {     

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sky Blade");
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
            Projectile.ArmorPenetration = 25;
            Projectile.width = 56;
            Projectile.height = 56;
        }

        public override void AI()
        {            
            base.AI();
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2 - MathHelper.PiOver4 * Projectile.spriteDirection;
            Projectile.tileCollide = false;
            SetVisualOffsets();
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (!target.HasBuff(BuffID.Weak))
            {
                target.AddBuff(BuffID.Weak, 100);
            }
            
            Player player = new();
            
            if (Main.player[Projectile.owner].ownedProjectileCounts[ProjectileID.SkyFracture] < 6 && target.type != NPCID.TargetDummy)
            {
                for (int numOfProjs = 0; numOfProjs < 3; numOfProjs++)
                {
                    
                    int Newproj = Projectile.NewProjectile(target.GetSource_OnHit(target), new Vector2(target.position.X + (Projectile.direction * 200), Projectile.position.Y + Main.rand.Next(-40, 41)), new Vector2(Projectile.velocity.X * 2f * -player.direction, Projectile.velocity.Y), ProjectileID.SkyFracture, 45, 6f, player.whoAmI);
                    Main.projectile[Newproj].velocity = Main.projectile[Newproj].velocity.RotatedByRandom(MathHelper.ToRadians(15f));
                    Main.projectile[Newproj].tileCollide = false;
                    Main.projectile[Newproj].timeLeft = 120;
                }
            }            
        }

        private void SetVisualOffsets()
        {
            int halfProjWidth = Projectile.width / 2;
            int halfProjHeight = Projectile.height / 2;

            DrawOriginOffsetX = 0;
            DrawOffsetX = -((48 / 2) - halfProjWidth);
            DrawOriginOffsetY = -((48 / 2) - halfProjHeight);
        }
    }
}
