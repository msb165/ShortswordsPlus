using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader.Config;
using Terraria.ModLoader;
using MoreShortswords.Content.Weapons;

namespace MoreShortswords.Content.Projectiles
{
    public class BetelgueseProjectile : ShortSwordProjectile
    {
        public override string Texture => ModContent.GetInstance<Betelguese>().Texture; 
        public override void SetDefaults()
        {
            base.SetDefaults();
            Projectile.Size = new(98);
            Projectile.ArmorPenetration = 50;
            Projectile.usesIDStaticNPCImmunity = true;
            Projectile.idStaticNPCHitCooldown = 20;
        }

        public override void AI()
        {
            base.AI();

            Dust StarDust = Dust.NewDustDirect(Projectile.position, 49, 49, DustID.GoldFlame, Projectile.velocity.X, Projectile.velocity.Y, 128, default, 2f);
            StarDust.position = Projectile.Center + Projectile.velocity;
            StarDust.velocity *= 0.25f;
            StarDust.noGravity = true;

            if (Main.rand.NextBool(4))
            {
                Gore.NewGore(null, Projectile.Center, Projectile.velocity * 0.25f, Utils.SelectRandom(Main.rand, 16, 17, 17, 17), 0.6f);
            }
        }

        public override void SetVisualOffsets()
        {
            base.SetVisualOffsets();
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (!target.immortal && !target.SpawnedFromStatue && !NPCID.Sets.CountsAsCritter[target.type])
            {
                for (int numOfSlashes = 0; numOfSlashes < 4; numOfSlashes++)
                {
                    Projectile.ai[1] = 1f;
                    Vector2 newV = Main.rand.NextVector2CircularEdge(800f, 800f);
                    if (newV.Y < 0f)
                    {
                        newV.Y *= -1f;
                    }
                    newV.Y += 100f;
                    Vector2 Vvector = newV.SafeNormalize(Vector2.UnitY) * 6f;
                    Projectile.NewProjectile(target.GetSource_OnHit(target), target.position - Vvector * 20f, Vvector * 2f, ModContent.ProjectileType<UltraStarProj>(), (int)(damageDone * 1.5f), 0f, Projectile.owner, 0f, 1f);
                }
            }
        }
    }
}
