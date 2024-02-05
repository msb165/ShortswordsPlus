using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader.Config;
using MoreShortswords.Content.Weapons;
using Terraria.ModLoader;

namespace MoreShortswords.Content.Projectiles
{
    public class ShortGrassProjectile : ShortSwordProjectile
    {
        public override string Texture => ModContent.GetInstance<ShortswordOfGrass>().Texture;

        public override void SetDefaults()
        {            
            base.SetDefaults();                   
        }

        public override void AI()
        {
            base.AI();
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2 - MathHelper.PiOver4 * Projectile.spriteDirection;
            SetVisualOffsets();
        }


        private void SetVisualOffsets()
        {            
            int halfProjWidth = Projectile.width / 2;
            int halfProjHeight = Projectile.height / 2;

            DrawOriginOffsetX = 0;
            DrawOffsetX = -((36 / 2) - halfProjWidth);
            DrawOriginOffsetY = -((38 / 2) - halfProjHeight);
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (!target.HasBuff(BuffID.Poisoned))
            {
                target.AddBuff(BuffID.Poisoned, Main.rand.Next(300, 501));
            }
        }        
    }
}
