using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using MoreShortswords.Content.Weapons;

namespace MoreShortswords.Content.Projectiles
{
    public class FrozenShortProjectile : ShortSwordProjectile
    {
        public override string Texture => ModContent.GetInstance<FrozenShort>().Texture;

        public override void SetDefaults()
        {
            base.SetDefaults();
            Projectile.width = 38;
            Projectile.height = 38;
            Projectile.ArmorPenetration = 2;
        }

        public override void AI()
        {
            base.AI();
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2 - MathHelper.PiOver4 * Projectile.spriteDirection;

            if (!Main.dedServ)
            {
                int TestDust = Dust.NewDust(new Vector2(Projectile.position.X + 0.25f, Projectile.position.Y), Projectile.width, Projectile.height, DustID.IceTorch, Projectile.velocity.X * 0.8f + (Projectile.spriteDirection * 3), Projectile.velocity.Y * 0.2f, 64, default, 1.1f);
                Main.dust[TestDust].velocity *= 0.25f;
                Main.dust[TestDust].noGravity = true;
            }

            SetVisualOffsets();
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Main.rand.NextBool(5) && !target.HasBuff(BuffID.Frostburn) && !target.immortal && !NPCID.Sets.CountsAsCritter[target.type])
            {
                target.AddBuff(BuffID.Frostburn, 300);
            }
        }

        private void SetVisualOffsets()
        {
            int halfProjWidth = Projectile.width / 2;
            int halfProjHeight = Projectile.height / 2;

            DrawOriginOffsetX = 0;
            DrawOffsetX = -((40 / 2) - halfProjWidth);
            DrawOriginOffsetY = -((40 / 2) - halfProjHeight);
        }
    }
}
