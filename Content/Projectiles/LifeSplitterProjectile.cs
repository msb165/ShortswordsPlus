using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using MoreShortswords.Content.Dusts;
using MoreShortswords.Content.Weapons;

namespace MoreShortswords.Content.Projectiles
{
    public class LifeSplitterProjectile : ShortSwordProjectile
    {
        public override string Texture => ModContent.GetInstance<LifeSplitter>().Texture;
        public override void SetDefaults()
        {
            base.SetDefaults();
            Projectile.Size = new(48);
            Projectile.ArmorPenetration = 15;
            Projectile.tileCollide = false;
        }

        public override void AI()
        {
            base.AI();
        }

        Player Owner => Main.player[Projectile.owner];

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Owner.GetModPlayer<MoreShortPlayer>().swordTimer == 0)
            {
                Owner.GetModPlayer<MoreShortPlayer>().swordTimer = 20;
            }
            else
            {
                return;
            }

            if (!target.HasBuff(BuffID.CursedInferno))
            {
                target.AddBuff(BuffID.CursedInferno, 300);
            }

            if (Main.rand.NextBool(2)) 
            {
                target.AddBuff(BuffID.Weak, 300);
            }

            if (!target.immortal && !target.SpawnedFromStatue && !NPCID.Sets.CountsAsCritter[target.type]) 
            {
                for (int projsToSpawn = 0; projsToSpawn < 3; projsToSpawn++)
                {
                    Vector2 vector = new(target.Center.X + Main.rand.Next(-400, 400), target.Center.Y - 500f);
                    Vector2 targetPos = target.Center + (Projectile.Size / 2) - vector;
                    targetPos.X += Main.rand.Next(-100, 101);
                    targetPos.Normalize();
                    targetPos *= 12f;            
                    Projectile.NewProjectile(target.GetSource_OnHit(target), vector, targetPos, ModContent.ProjectileType<LifeSplitterProjectile2>(), (int)(damageDone * 0.75f), 5f, Owner.whoAmI, 0f, 0f);
                }
            }
        }
    }
}
