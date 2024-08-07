﻿using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using MoreShortswords.Content.Weapons;

namespace MoreShortswords.Content.Projectiles
{
    public class TrueStarFragmentProjectile : ShortSwordProjectile
    {
        public override string Texture => ModContent.GetInstance<TrueStarFragment>().Texture;
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("True Star Fragment");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Projectile.Size = new(54);
        }
        public override void AI()
        {
            base.AI();
            if (Main.rand.NextBool(4))
            {
                Gore.NewGore(Projectile.GetSource_FromAI(), Projectile.position, Projectile.velocity * 0.2f, Utils.SelectRandom(Main.rand, 16, 17, 17, 17), 0.6f);
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
                target.AddBuff(BuffID.Weak, 400);
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
                for (int i = 0; i < 6; i++)
                {
                    Vector2 offsetPosition = new(target.position.X + Main.rand.Next(-400, 400), target.position.Y - Main.rand.Next(500, 800));
                    Vector2 spawnVelocity = Vector2.Normalize(target.Center - offsetPosition) * 20f;

                    Projectile.NewProjectileDirect(target.GetSource_FromAI(), offsetPosition, spawnVelocity, ModContent.ProjectileType<TrueStarFragmentProjectile2>(), Projectile.damage, 5f, Owner.whoAmI, 0f, 0f);
                }
            }
        }
    }
}
