﻿using Microsoft.Xna.Framework;
using MoreShortswords.Content.Weapons;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoreShortswords.Content.Projectiles
{
    public class HeartRodProjectile : ShortSwordProjectile
    {
        public override string Texture => ModContent.GetInstance<HeartRod>().Texture;
        public override void SetDefaults()
        {
            base.SetDefaults();
            Projectile.Size = new(48);            
        }

        public override void AI()
        {
            base.AI(); 

            if (Main.rand.NextBool(8))
            {
                Gore FlyingHeartGore = Gore.NewGoreDirect(Projectile.GetSource_FromAI(), Projectile.Center, Projectile.velocity * 0.8f, 331, 1f);
                FlyingHeartGore.sticky = false;
            }
            SetVisualOffsets();
        }
        private void SetVisualOffsets()
        {
            int halfProjWidth = Projectile.width / 2;
            int halfProjHeight = Projectile.height / 2;

            DrawOriginOffsetX = 0;
            DrawOffsetX = -((48 / 2) - halfProjWidth);
            DrawOriginOffsetY = -((48 / 2) - halfProjHeight);
        }

        Player Owner => Main.player[Projectile.owner];
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Owner.GetModPlayer<MoreShortPlayer>().swordTimer == 0)
            {
                Owner.GetModPlayer<MoreShortPlayer>().swordTimer = 40;
            }
            else
            {
                return;
            }

            if (hit.Crit && Main.rand.NextBool(4) && !NPCID.Sets.CountsAsCritter[target.type] && !target.immortal)
            {
                float newDamage = Main.rand.Next(1, 4);
                if ((int)newDamage != 0 && !(Owner.lifeSteal <= 0f))
                {
                    Owner.lifeSteal -= newDamage;
                    int playerOwner = Projectile.owner;
                    Projectile.NewProjectile(Projectile.GetSource_OnHit(target), target.Center.X, target.Center.Y, 0f, 0f, ProjectileID.VampireHeal, 0, 0f, Projectile.owner, playerOwner, newDamage);
                }
            }
        }
    }
}
