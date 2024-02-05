using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using MoreShortswords.Content.Weapons;
using Terraria.ModLoader;

namespace MoreShortswords.Content.Projectiles
{
    public class NaturesBlessProjectile : ShortSwordProjectile
    {
        public override string Texture => ModContent.GetInstance<NaturesBless>().Texture;


        public override void SetDefaults()
        {
            base.SetDefaults();
            Projectile.usesLocalNPCImmunity = true;
        }

        public override void AI()
        {
            base.AI();

            int TestDust = Dust.NewDust(new Vector2(Projectile.position.X + 0.25f, Projectile.position.Y), Projectile.width, Projectile.height, DustID.GrassBlades, Projectile.velocity.X * 0.8f + (Projectile.spriteDirection * 3), Projectile.velocity.Y * 0.2f, 128, default, 1.4f);
            Main.dust[TestDust].velocity *= 0.4f;
            Main.dust[TestDust].noGravity = true;

            SetVisualOffsets();
        }

        Player Owner => Main.player[Projectile.owner];
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {           
            if (!Owner.dryadWard && Main.rand.NextBool(2))
            {
                Owner.AddBuff(BuffID.DryadsWard, 900);
            }

            if (Main.rand.NextBool(3) && !target.HasBuff(BuffID.DryadsWardDebuff) && !target.HasBuff(BuffID.Venom))
            {
                target.AddBuff(BuffID.DryadsWardDebuff, 600);
                target.AddBuff(BuffID.Venom, 600);
            }

            if (Owner.GetModPlayer<MoreShortPlayer>().swordTimer == 0)
            {
                Owner.GetModPlayer<MoreShortPlayer>().swordTimer = 20;
            }
            else
            {
                return;
            }

            if (!target.immortal && !target.SpawnedFromStatue && !NPCID.Sets.CountsAsCritter[target.type])
            {           
                Projectile.NewProjectile(target.GetSource_OnHit(target), Projectile.Center, Projectile.velocity * 2.25f, ProjectileID.VilethornBase, Projectile.damage, 0f, Owner.whoAmI);
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
