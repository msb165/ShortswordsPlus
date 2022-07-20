using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace MoreShortswords.Content.Projectiles
{
    public class MuraShortProjectile : ShortSwordProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Moonlight");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Projectile.ArmorPenetration = 4;            
        }     

        public override void AI()
        {
            base.AI();
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2 - MathHelper.PiOver4 * Projectile.spriteDirection;

            if (!Main.dedServ)
            {
                int TestDust = Dust.NewDust(new Vector2(Projectile.position.X+0.25f, Projectile.position.Y), Projectile.width, Projectile.height, DustID.DungeonWater, Projectile.velocity.X * 0.8f + (Projectile.spriteDirection * 3), Projectile.velocity.Y * 0.2f, 128, default, 1.2f);
                Main.dust[TestDust].velocity *= 0.1f;
                Main.dust[TestDust].noGravity = true;
            }

            SetVisualOffsets();            
        }

        private void SetVisualOffsets()
        {
            const int halfSprWidth = 38 / 2;
            const int halfSprHeight = 42 / 2;

            int halfProjWidth = Projectile.width / 2;
            int halfProjHeight = Projectile.height / 2;

            DrawOriginOffsetX = 0;
            DrawOffsetX = -(halfSprWidth - halfProjWidth);
            DrawOriginOffsetY = -(halfSprHeight - halfProjHeight);
        }      

    }
}
