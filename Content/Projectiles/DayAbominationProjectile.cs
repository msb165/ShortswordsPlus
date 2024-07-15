using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using MoreShortswords.Content.Weapons;

namespace MoreShortswords.Content.Projectiles
{
    public class DayAbominationProjectile : ShortSwordProjectile
    {
        public override string Texture => ModContent.GetInstance<DayAbomination>().Texture;

        public override void SetDefaults()
        {
            base.SetDefaults();
            Projectile.Size = new(52);
            Projectile.friendly = true;
        }

        public override void AI()
        {
            base.AI();            
        }

        public override void SetVisualOffsets()
        {
            int halfProjWidth = Projectile.width / 2;
            int halfProjHeight = Projectile.height / 2;

            DrawOriginOffsetX = 0;
            DrawOffsetX = -((Projectile.width / 2) - halfProjWidth);
            DrawOriginOffsetY = -((Projectile.height / 2) - halfProjHeight);
        }

        public Player Owner => Main.player[Projectile.owner];

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Main.rand.NextBool(3)) 
            {
                target.AddBuff(BuffID.Bleeding, 500);
            }

            if (Owner.GetModPlayer<MoreShortPlayer>().swordTimer == 0)
            {
                Owner.GetModPlayer<MoreShortPlayer>().swordTimer = 20;
            }
            else
            {
                return;
            }

            Vector2 newV = Main.rand.NextVector2CircularEdge(400f, 400f);
            if (newV.Y < 0f)
            {
                newV.Y *= -1f;
            }
            newV.Y += 100f;
            Vector2 Vvector = newV.SafeNormalize(Vector2.UnitY) * 8f;

            Projectile.NewProjectile(target.GetSource_OnHit(target), target.Center - Vvector * 20f, Vvector, ModContent.ProjectileType<DayAbominationProjectile2>(), (int)(damageDone * 0.75), 0f, Owner.whoAmI, 0f, 0f);
        }
    }
}
