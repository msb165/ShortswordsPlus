using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Drawing;

namespace MoreShortswords.Content.Projectiles
{
    public class LadnerudProjectile : ShortSwordProjectile
    {
        public override string Texture => "MoreShortswords/Content/Projectiles/LadnerudProjectile";
        

        public override void SetDefaults()
        {
            base.SetDefaults();
            Projectile.ArmorPenetration = 15;
            Projectile.width = 48;
            Projectile.height = 48;
        }

        public override void AI()
        {
            base.AI();
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2 - MathHelper.PiOver4 * Projectile.spriteDirection;

            if (!Main.dedServ)
            {
                int TestDust = Dust.NewDust(new Vector2(Projectile.position.X + 0.3f, Projectile.position.Y), Projectile.width, Projectile.height, DustID.HallowedWeapons, Projectile.velocity.X * 0.8f + (Projectile.spriteDirection * 3), Projectile.velocity.Y * 0.2f, 128, default, 1.5f);
                Main.dust[TestDust].velocity *= 0.25f;
                Main.dust[TestDust].noGravity = true;
            }

            SetVisualOffsets();
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Player projOwner = Main.player[Projectile.owner];  

            ParticleOrchestrator.RequestParticleSpawn(false, ParticleOrchestraType.Keybrand, new ParticleOrchestraSettings
            {
                PositionInWorld = target.Center
            }, projOwner.whoAmI);     
            
            if (Main.player[Projectile.owner].ZoneHallow && Main.rand.NextBool(10) && target.defense > 12)
            {
                target.defense -= (int)(target.defense * 0.20f);
            }

            if (!projOwner.HasBuff(BuffID.SwordWhipPlayerBuff))
            {
                projOwner.AddBuff(BuffID.SwordWhipPlayerBuff, 800);
                
            }                     

            if (Main.rand.NextBool(4) && !target.HasBuff(BuffID.SwordWhipNPCDebuff))
            {
                target.AddBuff(BuffID.SwordWhipNPCDebuff, 800);
            }            
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
