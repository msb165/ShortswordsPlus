using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using MoreShortswords.Content.Weapons;
using Terraria.ModLoader;
using static Humanizer.In;
using MoreShortswords.Content.Dusts;

namespace MoreShortswords.Content.Projectiles
{
    public class FieryShortProjectile : ShortSwordProjectile
    {
        public override string Texture => ModContent.GetInstance<Magma>().Texture;

        public override void SetDefaults()
        {
            base.SetDefaults();
            Projectile.Size = new(48);
            Projectile.ArmorPenetration = 4;
        }

        public override void AI()
        {
            base.AI();
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2 - MathHelper.PiOver4 * Projectile.spriteDirection;

            Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 0, Color.Orange, 1.25f);

            SetVisualOffsets();
        }

        public Player Owner => Main.player[Projectile.owner];

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Main.rand.NextBool(3) && !target.HasBuff(BuffID.OnFire))
            {
                target.AddBuff(BuffID.OnFire, 300, false);
            }

            if (Owner.GetModPlayer<MoreShortPlayer>().swordTimer == 0)
            {
                Owner.GetModPlayer<MoreShortPlayer>().swordTimer = 20;
            }
            else
            {
                return;
            }

            if (!target.immortal && !target.SpawnedFromStatue && !NPCID.Sets.CountsAsCritter[target.type])
            {
                Projectile.NewProjectile(target.GetSource_OnHit(target), target.Center, Vector2.Zero, ProjectileID.SolarWhipSwordExplosion, Projectile.damage / 3, 0f, Projectile.owner, 0f, 0.85f);
            } 
        }

        public override Color? GetAlpha(Color lightColor) => Color.White;


        private void SetVisualOffsets()
        {           
           
            int halfProjWidth = Projectile.width / 2;
            int halfProjHeight = Projectile.height / 2;

            DrawOriginOffsetX = 0;
            DrawOffsetX = -((42 / 2) - halfProjWidth);
            DrawOriginOffsetY = -((42 / 2) - halfProjHeight);
        }
    }
}
