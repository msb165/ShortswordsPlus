using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System;


namespace MoreShortswords.Content.Projectiles
{
    public class NaturesBlessProjectile : ShortSwordProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nature's Bless");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Projectile.ArmorPenetration = 40;
        }

        public override void AI()
        {
            base.AI();

            if (!Main.dedServ)
            {
                int TestDust = Dust.NewDust(new Vector2(Projectile.position.X + 0.25f, Projectile.position.Y), Projectile.width, Projectile.height, DustID.GrassBlades, Projectile.velocity.X * 0.8f + (Projectile.spriteDirection * 3), Projectile.velocity.Y * 0.2f, 128, default, 1.4f);
                Main.dust[TestDust].velocity *= 0.4f;
                Main.dust[TestDust].noGravity = true;
            }

            SetVisualOffsets();
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Player player = new();
            Player projOwner = Main.player[Projectile.owner];

            if (!projOwner.dryadWard)
            {
                projOwner.AddBuff(BuffID.DryadsWard, 900);
            }


            if (Main.rand.NextBool(3))
            {
                target.AddBuff(BuffID.Weak, 600);
                target.AddBuff(BuffID.Slow, 900);
                target.AddBuff(BuffID.DryadsWardDebuff, 600);
                target.AddBuff(BuffID.Venom, 900);
            }

       
            if (projOwner.ownedProjectileCounts[ProjectileID.VilethornBase] < 6)
            {           
                int thornProj = Projectile.NewProjectile(target.GetSource_OnHit(target), projOwner.Center, Projectile.velocity*4.5f, ProjectileID.VilethornBase, 65, 4f, player.whoAmI);
                Main.projectile[thornProj].ArmorPenetration = 80;
                Main.projectile[thornProj].penetrate = 1;
            }
            
        }

        private void SetVisualOffsets()
        {
            int halfProjWidth = Projectile.width / 2;
            int halfProjHeight = Projectile.height / 2;

            DrawOriginOffsetX = 0;
            DrawOffsetX = -((64 / 2) - halfProjWidth);
            DrawOriginOffsetY = -((64 / 2) - halfProjHeight);
        }
    }
}
