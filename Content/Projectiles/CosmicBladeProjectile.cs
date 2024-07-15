using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Drawing;
using MoreShortswords.Content.Weapons;
using Terraria.ModLoader;

namespace MoreShortswords.Content.Projectiles
{
    public class CosmicBladeProjectile : ShortSwordProjectile
    {
        public override string Texture => ModContent.GetInstance<CosmicBlade>().Texture;

        public override void SetDefaults()
        {
            base.SetDefaults();
            Projectile.Size = new(56);
            Projectile.ArmorPenetration = 25;
            Projectile.tileCollide = false;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 17;
        }
        public override void AI()
        {
            int PinkDust = Dust.NewDust(Projectile.Center, Projectile.width, Projectile.height, DustID.Enchanted_Pink, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 128, Color.HotPink, 1.2f);
            Main.dust[PinkDust].velocity.X *= 0.2f;
            Main.dust[PinkDust].velocity.Y -= 1f;
            Main.dust[PinkDust].noGravity = true;

            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2 - MathHelper.PiOver4 * Projectile.spriteDirection;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (!target.HasBuff(BuffID.Weak) && !target.HasBuff(BuffID.Confused))
            {
                target.AddBuff(BuffID.Confused, Main.rand.Next(200, 300));
                target.AddBuff(BuffID.Weak, Main.rand.Next(300, 400));
            }

            ParticleOrchestrator.RequestParticleSpawn(true, ParticleOrchestraType.StellarTune, new ParticleOrchestraSettings
            {
                PositionInWorld = target.Center
            });
        }
        public override void SetVisualOffsets()
        {
            int halfProjWidth = Projectile.width / 2;
            int halfProjHeight = Projectile.height / 2;

            DrawOriginOffsetX = 0;
            DrawOffsetX = -((Projectile.width / 2) - halfProjWidth);
            DrawOriginOffsetY = -((Projectile.height / 2) - halfProjHeight);
        }
    }
}
