using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Drawing;
using MoreShortswords.Content.Weapons;
using Terraria.ModLoader;
using MoreShortswords.Content.Dusts;

namespace MoreShortswords.Content.Projectiles
{
    public class LadnerudProjectile : ShortSwordProjectile
    {
        public override string Texture => ModContent.GetInstance<Ladnerud>().Texture;

        public override void SetDefaults()
        {
            base.SetDefaults();
            Projectile.Size = new(48);    
        }

        public override void AI()
        {
            base.AI();
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2 - MathHelper.PiOver4 * Projectile.spriteDirection;

            if (Main.rand.NextBool(3))
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), Projectile.velocity.X * 0.8f, Projectile.velocity.Y * 0.8f, 0, Color.Gold, 1f);
            }

            SetVisualOffsets();
        }
        Player ProjOwner => Main.player[Projectile.owner];
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            ParticleOrchestrator.RequestParticleSpawn(true, ParticleOrchestraType.Keybrand, new ParticleOrchestraSettings
            {
                PositionInWorld = target.Center
            }, ProjOwner.whoAmI);     
            
            if (Main.player[Projectile.owner].ZoneHallow && Main.rand.NextBool(10) && target.defense > 12)
            {
                target.defense *= (int)(target.defense * 0.80f);
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
