using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace MoreShortswords.Content.Projectiles
{
    public class MagicBladeProjectile2 : ModProjectile
    {
        public override string Texture => "MoreShortswords/Content/Projectiles/MagicBladeProjectile";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Deity Spear");
        }

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.EnchantedBoomerang);
            Projectile.width = 40;
            Projectile.height = 40;
            Projectile.ArmorPenetration = 15;
            Projectile.penetrate = 2;
        }

        public override void AI()
        {
            base.AI();
            Projectile.rotation += 0.25f * Projectile.direction;
       
            int boomDust = Dust.NewDust(Projectile.oldPosition, Projectile.width, Projectile.height, DustID.Clentaminator_Cyan, Projectile.velocity.X * 0.25f, Projectile.velocity.Y * 0.25f, 150, default, 0.50f);
            Main.dust[boomDust].noGravity = true;            

            Player player = new()
            {
                heldProj = Projectile.whoAmI,
                itemRotation = Projectile.rotation
            }; 

            if (player.dead || player.CCed || player.noItems)
            {
                Projectile.Kill();
            }

            SetVisualOffsets();
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Player player = new();

            if (!target.HasBuff(BuffID.Confused))
            {
                target.AddBuff(BuffID.Confused, 300);
            }

            if (Main.player[Projectile.owner].ownedProjectileCounts[ModContent.ProjectileType<MagicBladeProjectile3>()] < 4 && target.type != NPCID.TargetDummy)
            {
                Projectile.NewProjectile(target.GetSource_OnHit(target), Projectile.position, new Vector2(Projectile.velocity.X * -player.direction, -Projectile.velocity.Y), ModContent.ProjectileType<MagicBladeProjectile3>(), 25, 5.7f, player.whoAmI);
            }
            
        }

        private void SetVisualOffsets()
        {
            int halfProjWidth = Projectile.width / 2;
            int halfProjHeight = Projectile.height / 2;

            DrawOriginOffsetX = 0;
            DrawOffsetX = -((50 / 2) - halfProjWidth);
            DrawOriginOffsetY = -((50 / 2) - halfProjHeight);
        }


    }
}
