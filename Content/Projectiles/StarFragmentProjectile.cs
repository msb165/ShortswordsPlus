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

            if (Main.rand.NextBool(8))
            {
                Gore.NewGore(Projectile.GetSource_FromAI(), Projectile.Center, Projectile.velocity * 0.25f, Utils.SelectRandom(Main.rand, 16, 17, 17, 17), 0.6f);
            }
        }

        public override void SetVisualOffsets()
        {         
            base.SetVisualOffsets();
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
                for (int numOfStars = 0; numOfStars < 1; numOfStars++)
                {
                    Vector2 targetPos = new(target.Center.X + Main.rand.Next(-400, 401), target.Center.Y - 600f);
                    Vector2 projTargetDist = target.Center - targetPos;                    
                    projTargetDist.Normalize();
                    projTargetDist *= 25f;                 
                    
                    Projectile starproj = Projectile.NewProjectileDirect(target.GetSource_OnHit(target), targetPos, projTargetDist, ProjectileID.Starfury, Projectile.damage / 2, 4f, Owner.whoAmI, 0f, Projectile.position.Y);
                    starproj.extraUpdates = 1;
                }
            } 
        }
    }
}
