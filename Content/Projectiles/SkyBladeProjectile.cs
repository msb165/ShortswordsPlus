using Terraria;
using Terraria.ModLoader;
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
            Projectile.ArmorPenetration = 20;
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
            target.AddBuff(BuffID.Weak, 100);
            Player player = new();
            Player projOwner = Main.player[Projectile.owner];
            if (projOwner.ownedProjectileCounts[ProjectileID.SkyFracture] < 2 && target.type != NPCID.TargetDummy)
            {
                for (int numOfProjs = 0; numOfProjs < 2; numOfProjs++)
                {                    
                    int Newproj = Projectile.NewProjectile(target.GetSource_OnHit(target), new Vector2(target.position.X + (Projectile.direction * 200), Projectile.position.Y + Main.rand.Next(-10, 11)), new Vector2((Projectile.velocity.X * 1.45f) * -player.direction, Projectile.velocity.Y), ProjectileID.SkyFracture, 45, 6f, player.whoAmI);
                    Main.projectile[Newproj].tileCollide = false;
                    Main.projectile[Newproj].timeLeft = 100;
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
