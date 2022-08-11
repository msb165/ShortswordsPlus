using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace MoreShortswords.Content.Projectiles
{
    public class BetelgueseProjectile : ShortSwordProjectile
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            Projectile.width = 98;
            Projectile.height = 98;
            Projectile.ArmorPenetration = 200;
        }

        public override void AI()
        {
            base.AI();

            if (!Main.dedServ)
            {
                int StarDust = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Enchanted_Gold, Projectile.velocity.X * 0.8f + (Projectile.spriteDirection * 3), Projectile.velocity.Y * 0.2f, 128, default, 1.2f);
                Main.dust[StarDust].velocity *= 0.25f;
                Main.dust[StarDust].rotation *= MathHelper.ToRadians(30f);
                Main.dust[StarDust].noGravity = true;
                if (Main.rand.NextBool(4))
                {
                    Gore.NewGore(null, Projectile.position, Projectile.velocity * 0.25f, Utils.SelectRandom<int>(Main.rand, 16, 17, 17, 17), 0.6f);
                }
            }

            SetVisualOffsets();
        }

        private void SetVisualOffsets()
        {
            int halfProjWidth = Projectile.width / 2;
            int halfProjHeight = Projectile.height / 2;

            DrawOriginOffsetX = 0;
            DrawOffsetX = -((98 / 2) - halfProjWidth);
            DrawOriginOffsetY = -((98 / 2) - halfProjHeight);
        }     
    }
}
