﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MoreShortswords.Content.Dusts;
using Terraria.Audio;

namespace MoreShortswords.Content.Projectiles
{
    public class UltraStarProj : ModProjectile
    {
        public override string Texture => $"Terraria/Images/Projectile_{ProjectileID.SuperStar}";

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 20;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 3;
        }

        public override void SetDefaults()
        {            
            Projectile.width = 22;
            Projectile.height = 24;
            Projectile.penetrate = -1;
            Projectile.friendly = true;
            Projectile.ownerHitCheck = true;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 30;
            Projectile.aiStyle = -1;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 18;
        }

        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            if (Main.rand.NextBool(8))
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f, 0, Color.Gold, 1.25f);
            }
            if (Main.rand.NextBool(20))
            {
                Gore.NewGore(Projectile.GetSource_FromThis(), Projectile.position, Projectile.velocity * 0.25f, Main.rand.Next(16, 18));
            }
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

            if (target.immortal || target.SpawnedFromStatue || NPCID.Sets.CountsAsCritter[target.type])
            {
                return;
            }         
        }
        public override Color? GetAlpha(Color lightColor) => new Color(0, 161, 232, 43);

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = (Texture2D)ModContent.Request<Texture2D>(Texture);
            Texture2D glowTexture = (Texture2D)ModContent.Request<Texture2D>("MoreShortswords/Assets/GlowSphere");
            float glowScale = Projectile.scale * 0.5f;
            SpriteBatch spriteBatch = Main.spriteBatch;

            Color drawColorGlow = Color.Gold with { A = 0 };
            Color drawColor = Color.White with { A = 0 };

            Vector2 drawOrigin = texture.Size() / 2f;
            Vector2 drawGlowOrigin = glowTexture.Size() / 2f;

            for (int i = 0; i < Projectile.oldPos.Length; i++)
            {
                Vector2 drawPos = Projectile.oldPos[i] - Main.screenPosition + Projectile.Size / 2f + new Vector2(0f, Projectile.gfxOffY);
                drawColorGlow *= 0.5f;
                drawColor *= 0.75f;
                glowScale = MathHelper.Clamp(glowScale - i / (float)Projectile.oldPos.Length, 0f, 1f);

                spriteBatch.Draw(glowTexture, drawPos, null, drawColorGlow, Projectile.rotation, drawGlowOrigin, glowScale, SpriteEffects.None, 0);
                spriteBatch.Draw(texture, drawPos, null, drawColor, Projectile.rotation, drawOrigin, Projectile.scale - i / (float)Projectile.oldPos.Length, SpriteEffects.None, 0);
            }

            spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, Color.White with { A = 0 }, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            return false;
        }

        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.NPCHit3, Projectile.position);
            for (int i = 0; i < 10; i++)
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), 0f, 0f, 0, Color.Gold, 1f);
                dust.velocity *= 4f;
            }
        }
    }
}
