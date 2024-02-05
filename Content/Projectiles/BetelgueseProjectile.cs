using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader.Config;
using Terraria.ModLoader;
using MoreShortswords.Content.Weapons;

namespace MoreShortswords.Content.Projectiles
{
    public class BetelgueseProjectile : ShortSwordProjectile
    {
        public override string Texture => ModContent.GetInstance<Betelguese>().Texture; 
        public override void SetDefaults()
        {
            base.SetDefaults();
            Projectile.width = 98;
            Projectile.height = 98;
            Projectile.ArmorPenetration = 50;
            Projectile.usesIDStaticNPCImmunity = true;
            Projectile.idStaticNPCHitCooldown = 20;
        }

        public override void AI()
        {
            base.AI();

            int StarDust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Enchanted_Gold, Projectile.velocity.X * 0.8f + (Projectile.spriteDirection * 3), Projectile.velocity.Y * 0.2f, 128, default, 1.2f);
            Main.dust[StarDust].velocity *= 0.25f;
            Main.dust[StarDust].rotation *= MathHelper.ToRadians(30f);
            Main.dust[StarDust].noGravity = true;
            if (Main.rand.NextBool(4))
            {
                Gore.NewGore(null, Projectile.position, Projectile.velocity * 0.25f, Utils.SelectRandom(Main.rand, 16, 17, 17, 17), 0.6f);
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
