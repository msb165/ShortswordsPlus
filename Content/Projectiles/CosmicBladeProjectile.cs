using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace MoreShortswords.Content.Projectiles
{
    public class CosmicBladeProjectile : ShortSwordProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cosmic Blade");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Projectile.ArmorPenetration = 25;
            Projectile.tileCollide = false;            
        }

        public override void AI()
        {
            base.AI();

            if (!Main.dedServ)
            {
                int PinkDust = Dust.NewDust(Projectile.Center, Projectile.width, Projectile.height, DustID.Enchanted_Pink, Projectile.velocity.X * 0.8f + (Projectile.spriteDirection * 3), Projectile.velocity.Y * 0.2f, 128, Color.HotPink, 1.2f);
                Main.dust[PinkDust].velocity.X *= 0.2f;
                Main.dust[PinkDust].velocity.Y -= 1f;
                Main.dust[PinkDust].noGravity = true;
            }

            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2 - MathHelper.PiOver4 * Projectile.spriteDirection;
            SetVisualOffsets();
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Confused, 120);
            target.AddBuff(BuffID.Weak, 240);


            Player player = new();
            Player projOwn = Main.player[Projectile.owner];
            
            if (projOwn.ownedProjectileCounts[ModContent.ProjectileType<CosmicBladeProjectile2>()] < 3 && target.type != NPCID.TargetDummy)
            {
                int NewProj = Projectile.NewProjectile(target.GetSource_OnHit(target), new Vector2(target.Center.X, target.Center.Y), Projectile.velocity * 2f, ModContent.ProjectileType<CosmicBladeProjectile2>(), 50, 8f, player.whoAmI);                    
                Main.projectile[NewProj].timeLeft = 200;                                           
            }
        }

        private void SetVisualOffsets()
        {
            int halfProjWidth = Projectile.width / 2;
            int halfProjHeight = Projectile.height / 2;

            DrawOriginOffsetX = 0;
            DrawOffsetX = -((56 / 2) - halfProjWidth);
            DrawOriginOffsetY = -((56 / 2) - halfProjHeight);
        }
    }
}
