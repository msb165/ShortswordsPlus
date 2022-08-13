using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MoreShortswords.Content.Projectiles
{
    public class LadnerudProjectile2 : LadnerudProjectile
    {
        public override string Texture => "MoreShortswords/Content/Projectiles/LadnerudProjectile";

        public override void SetDefaults()
        {
            Projectile.ownerHitCheck = true;
            Projectile.tileCollide = false;
            Projectile.friendly = true;
            Projectile.penetrate = 1;
            int multiplier = (int)(0.1f + Main.player[Projectile.owner].velocity.Length() / 7f * 0.9f);
            Projectile.damage = 57 * multiplier;
        }

        public override void AI()
        {

            Player player = Main.player[Projectile.owner];

            player.itemTime = player.itemAnimation = player.itemAnimationMax;
            player.itemRotation = Projectile.rotation;
            player.heldProj = Projectile.whoAmI;

            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2 - MathHelper.PiOver4 * Projectile.spriteDirection;

            if (Main.myPlayer == Projectile.owner && player.altFunctionUse != 2 && !player.noItems && !player.CCed)
            {
                Projectile.Kill();
            }

            if (player.dead || !player.active)
            {
                Projectile.Kill();
            }
            SetVisualOffsets();
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
