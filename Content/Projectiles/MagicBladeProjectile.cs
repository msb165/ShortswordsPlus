using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace MoreShortswords.Content.Projectiles
{
    public class MagicBladeProjectile : ShortSwordProjectile
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            Projectile.width = 50;
            Projectile.height = 50;
            Projectile.ArmorPenetration = 10;
        }

        public override void AI()
        {
            base.AI();
            SetVisualOffsets();
        }

        private void SetVisualOffsets()
        {
            int halfProjWidth = Projectile.width / 2;
            int halfProjHeight = Projectile.height / 2;

            DrawOriginOffsetX = 0;
            DrawOffsetX = -((50 / 2) - halfProjWidth);
            DrawOriginOffsetY = -((50 / 2) - halfProjHeight);
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Player player = new();
            if (target.type != NPCID.TargetDummy) {
                Projectile.NewProjectile(target.GetSource_OnHit(target), Projectile.Center, Projectile.velocity*2f, ProjectileID.ThunderSpearShot, Projectile.damage / 2, 4.5f, player.whoAmI);
            }
        }     


    }
}
