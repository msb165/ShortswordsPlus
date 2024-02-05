using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using MoreShortswords.Content.Weapons;
using MoreShortswords.Content.Dusts;

namespace MoreShortswords.Content.Projectiles
{
    public class HybridShortProjectile : ShortSwordProjectile
    {
        public override string Texture => ModContent.GetInstance<Destroyer>().Texture;


        public override void SetDefaults()
        {
            base.SetDefaults();
            Projectile.Size = new(48);
        }

        public override void AI()
        {
            base.AI();
            Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), Projectile.velocity.X * 0.8f, Projectile.velocity.Y * 0.8f, 0, Color.MediumOrchid, 1.5f);
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2 - MathHelper.PiOver4 * Projectile.spriteDirection;
            SetVisualOffsets();            
        }

        public Player Owner => Main.player[Projectile.owner];
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Owner.GetModPlayer<MoreShortPlayer>().swordTimer == 0)
            {
                Owner.GetModPlayer<MoreShortPlayer>().swordTimer = 20;
            }
            else
            {
                return;
            }

            if (target.immortal || target.SpawnedFromStatue || NPCID.Sets.CountsAsCritter[target.type])
            {
                return;
            }        
            
            for (int i = 0; i < 2; i++)
            {
                Vector2 newV = Main.rand.NextVector2CircularEdge(800f, 800f);
                if (newV.Y < 0f)
                {
                    newV.Y *= -1f;
                }
                newV.Y += 100f;
                Vector2 Vvector = newV.SafeNormalize(Vector2.UnitY) * 6f;
                Projectile.NewProjectileDirect(target.GetSource_OnHit(target), target.position - Vvector * 20f, Vvector * 1.5f, ModContent.ProjectileType<HybridShortProjectile2>(), (int)(Projectile.damage * 0.75f), 4f, Owner.whoAmI);
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
