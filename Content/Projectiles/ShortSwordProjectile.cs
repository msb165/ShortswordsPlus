using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;


namespace MoreShortswords.Content.Projectiles
{
    public class ShortSwordProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.ownerHitCheck = true;
            Projectile.ignoreWater = true;
            Projectile.extraUpdates = 1;            
            Projectile.aiStyle = ProjAIStyleID.ShortSword;
        }

        public override void AI()
        {
            base.AI();
            Projectile.scale = Utils.GetLerpValue(0f, 1f, Projectile.ai[0] * 0.1f, true);
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2 - MathHelper.PiOver4 * Projectile.spriteDirection;
            SetVisualOffsets();
        }

        public virtual void SetVisualOffsets()
        {
            int halfProjWidth = Projectile.width / 2;
            int halfProjHeight = Projectile.height / 2;

            DrawOriginOffsetX = 0;
            DrawOffsetX = -((halfProjWidth) - halfProjWidth);
            DrawOriginOffsetY = -((halfProjHeight) - halfProjHeight);
        }
    }
}
