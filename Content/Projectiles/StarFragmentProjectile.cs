using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System;
using Terraria.ModLoader;
using MoreShortswords.Content.Weapons;
using MoreShortswords.Content.Dusts;

namespace MoreShortswords.Content.Projectiles
{
    public class StarFragmentProjectile : ShortSwordProjectile
    {
        public override string Texture => ModContent.GetInstance<StarFragment>().Texture;

        public override void SetDefaults()
        {
            base.SetDefaults();
            Projectile.Size = new(40);
            Projectile.ArmorPenetration = 6;
        }

        public override void AI()
        {
            base.AI();
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2 - MathHelper.PiOver4 * Projectile.spriteDirection;

            if (Main.rand.NextBool(8))
            {
                Gore.NewGore(Projectile.GetSource_FromAI(), Projectile.Center, Projectile.velocity * 0.25f, Utils.SelectRandom(Main.rand, 16, 17, 17, 17), 0.6f);
            }
            SetVisualOffsets();
        }

        private void SetVisualOffsets()
        {            
            int halfProjWidth = Projectile.width / 2;
            int halfProjHeight = Projectile.height / 2;

            DrawOriginOffsetX = 0;
            DrawOffsetX = -((40 / 2) - halfProjWidth);
            DrawOriginOffsetY = -((40 / 2) - halfProjHeight);
        }

        public Player Owner => Main.player[Projectile.owner];

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (!target.HasBuff(BuffID.Weak))
            {
                target.AddBuff(BuffID.Weak, 200);
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
                for (int numOfStars = 0; numOfStars < 3; numOfStars++)
                {
                    Vector2 vector = new(target.Center.X + 400, target.Center.Y - Main.rand.Next(500, 800));
                    Vector2 projTargetDist = Projectile.Center - vector;
                    projTargetDist.X += Main.rand.Next(-100, 101);

                    float projTargetDistLength = projTargetDist.Length();
                    projTargetDistLength = 25f / projTargetDistLength;
                    projTargetDist.X *= projTargetDistLength;
                    projTargetDist.Y *= projTargetDistLength;                   
                    
                    Projectile starproj = Projectile.NewProjectileDirect(target.GetSource_OnHit(target), vector, projTargetDist, ProjectileID.StarCloakStar, 10, 4f, Owner.whoAmI, 0f, Projectile.position.Y);
                    starproj.DamageType = DamageClass.MeleeNoSpeed;
                    starproj.extraUpdates = 1;
                }
            } 
        }
    }
}
