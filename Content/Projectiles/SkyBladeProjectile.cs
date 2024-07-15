using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using System;
using MoreShortswords.Content.Weapons;

namespace MoreShortswords.Content.Projectiles
{
    public class SkyBladeProjectile : ShortSwordProjectile
    {
        public override string Texture => ModContent.GetInstance<SkyBlade>().Texture;

        public override void SetDefaults()
        {
            base.SetDefaults();
            Projectile.ArmorPenetration = 25;
            Projectile.Size = new(56);
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 17;
        }

        public override void AI()
        {             
            base.AI();
        }

        public Player Owner => Main.player[Projectile.owner];

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

            if (!target.HasBuff(BuffID.Weak))
            {
                target.AddBuff(BuffID.Weak, 400);
            }

            if (!target.immortal && !target.SpawnedFromStatue && !NPCID.Sets.CountsAsCritter[target.type])
            {
                for (int numOfProjs = 0; numOfProjs < 3; numOfProjs++)
                {
                    int direction = Main.rand.Next(-1, 2) * 1;
                    Vector2 screenPos = Main.screenPosition;
                    if (direction < 0)
                    {
                        screenPos.X += Main.screenWidth;
                    }
                    screenPos.Y += Main.rand.Next(Main.screenHeight);
                    Vector2 targetPosScreen = target.Center - screenPos;
                    targetPosScreen.X += Main.rand.Next(-5, 6);
                    targetPosScreen.Y += Main.rand.Next(-5, 6);
                    targetPosScreen.Normalize();
                    targetPosScreen *= 15f;

                    Projectile.NewProjectile(Projectile.GetSource_OnHit(target), screenPos, targetPosScreen, ModContent.ProjectileType<SkyBladeProjectile2>(), Projectile.damage / 2, 4f, Owner.whoAmI);
                }
            }             
        }

        public override void SetVisualOffsets()
        {
            base.SetVisualOffsets();
        }
    }
}
