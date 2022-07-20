using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MoreShortswords.Content.Projectiles
{
    public class HybridShortProjectile : ShortSwordProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Destroyer Shortsword");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();        
            Projectile.ArmorPenetration = 10;
        }

        public override void AI()
        {
            base.AI();
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2 - MathHelper.PiOver4 * Projectile.spriteDirection;
            SetVisualOffsets();
            
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Player player = new();           
            if (player.ownedProjectileCounts[ModContent.ProjectileType<HybridShortProjectile2>()] < 4)
            {
                Projectile.NewProjectile(target.GetSource_OnHit(target), new Vector2(target.Center.X, target.Center.Y - target.height*8f), new Vector2(0f, 15f), ModContent.ProjectileType<HybridShortProjectile2>(), 25, 5f, player.whoAmI);              
               
            }                  
            

        }

        private void SetVisualOffsets()
        {
            const int halfSprWidth = 48 / 2;
            const int halfSprHeight = 48 / 2;

            int halfProjWidth = Projectile.width / 2;
            int halfProjHeight = Projectile.height / 2;

            DrawOriginOffsetX = 0;
            DrawOffsetX = -(halfSprWidth - halfProjWidth);
            DrawOriginOffsetY = -(halfSprHeight - halfProjHeight);
        }

    }
}
