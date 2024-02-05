using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System;
using Terraria.Audio;
using MoreShortswords.Content.Weapons;

namespace MoreShortswords.Content.Projectiles
{
    internal class FinalSwordProjectile : ShortSwordProjectile
    {
        public override string Texture => ModContent.GetInstance<FinalSword>().Texture;


        public override void SetDefaults()
        {
            base.SetDefaults();
            Projectile.ArmorPenetration = 150;
        }

        public override void AI()
        {
            base.AI();
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2 - MathHelper.PiOver4 * Projectile.spriteDirection;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 16;            
            SetVisualOffsets();
        }

        private void SetVisualOffsets()
        {
            int halfProjWidth = Projectile.width / 2;
            int halfProjHeight = Projectile.height / 2;

            DrawOriginOffsetX = 0;
            DrawOffsetX = -((100 / 2) - halfProjWidth);
            DrawOriginOffsetY = -((100 / 2) - halfProjHeight);
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.Weak, 900);
        }

    }
}
