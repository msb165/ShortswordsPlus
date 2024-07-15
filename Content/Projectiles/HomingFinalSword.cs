using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using MoreShortswords.Content.Dusts;
using Terraria.ID;
using Terraria.Audio;

namespace MoreShortswords.Content.Projectiles
{
    internal class HomingFinalSword : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Type] = 30;
            ProjectileID.Sets.TrailingMode[Type] = 2;
            ProjectileID.Sets.CultistIsResistantTo[Type] = true;
        }
        public override void SetDefaults()
        {
            Projectile.Size = new(12);
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.friendly = true;
            Projectile.aiStyle = -1;
            Projectile.extraUpdates = 1;
            Projectile.timeLeft = 50;
        }

        public override void AI()
        {
            float detectRadiusMax = 350f;
            float projSpeed = 7.5f;

            for (int i = 0; i < 3; i++)
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, 10, 10, DustID.Phantasmal, 0f, 0f, 0, default, 1f);
                dust.noGravity = true;
                dust.velocity *= 0.2f;
                dust.velocity += Projectile.velocity * 0.2f;
            }

            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver4;
            NPC closestNPC = FindClosestNPC(detectRadiusMax);
            if (closestNPC is null)
            {
                return;
            }

            Projectile.velocity = Vector2.Lerp(Projectile.velocity, (closestNPC.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * projSpeed, 0.1f);            
        }

        public NPC FindClosestNPC(float maxDistance)
        {
            NPC closestNPC = null;

            float sqrMaxDistance = maxDistance * maxDistance;
            for (int j = 0; j < Main.maxNPCs; j++)
            {
                NPC target = Main.npc[j];

                if (target.CanBeChasedBy(this))
                {
                    float sqrDistanceToTarget = Vector2.DistanceSquared(target.Center, Projectile.Center);
                    if (sqrDistanceToTarget < sqrMaxDistance)
                    {
                        sqrMaxDistance = sqrDistanceToTarget;
                        closestNPC = target;
                    }
                }

            }
            return closestNPC;
        }

        public override void OnKill(int timeLeft)
        {
            Projectile.position = Projectile.Center;
            Projectile.width = Projectile.height = 144;
            Projectile.position -= Projectile.Size / 2;
            SoundEngine.PlaySound(SoundID.NPCHit3, Projectile.position);
            for (int i = 0; i < 30; i++)
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Phantasmal, 0f, 0f, 0, default, 2f);
                dust.noGravity = true;
                dust.velocity *= 4f;
            }
            Projectile.Damage();
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = TextureAssets.Projectile[Type].Value;
            Vector2 drawOrigin = Vector2.UnitX * texture.Width;
            Color drawColor = Color.White with { A = 127 };
            Color drawColor2 = drawColor;

            for (int i = 0; i < Projectile.oldPos.Length; i++)
            {
                drawColor2 *= 0.90f;
                Main.EntitySpriteDraw(texture, (Projectile.oldPos[i] - Main.screenPosition) + Projectile.Size / 2 + new Vector2(0f, Projectile.gfxOffY), null, drawColor2, Projectile.oldRot[i], drawOrigin, Projectile.scale - i / (float)Projectile.oldPos.Length, SpriteEffects.None, 0);
            }

            Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, drawColor, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            return false;
        }
    }
}
