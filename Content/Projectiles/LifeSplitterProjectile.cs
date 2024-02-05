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
            Projectile.Size = new(50);
            Projectile.ArmorPenetration = 15;
            Projectile.tileCollide = false;
        }

        public override void AI()
        {
            base.AI();
            Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), Projectile.velocity.X * 0.8f, Projectile.velocity.Y * 0.8f, 0, Color.Green, 1.25f);
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
                    Vector2 vector = new(target.Center.X + Main.rand.Next(-400, 400), target.Center.Y - Main.rand.Next(600, 800));
                    float targetPosX = target.Center.X + (Projectile.width / 2) - vector.X;
                    float targetPosY = target.Center.Y + (Projectile.height / 2) - vector.Y;
                    targetPosX += Main.rand.Next(-100, 101);
                    float num18 = (float)Math.Sqrt(targetPosX * targetPosX + targetPosY * targetPosY);
                    num18 = 25f / num18;
                    targetPosX *= num18;
                    targetPosY *= num18;                    
                    Projectile.NewProjectile(target.GetSource_OnHit(target), vector, new Vector2(targetPosX, targetPosY), ModContent.ProjectileType<LifeSplitterProjectile2>(), (int)(damageDone * 0.75f), 5f, Owner.whoAmI, 0f, 0f);
                }
            }

        }
    }
}
