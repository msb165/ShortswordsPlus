using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using MoreShortswords.Effects;
using MoreShortswords.Content.Weapons;

namespace MoreShortswords.Content.Projectiles
{
    public class FinalSwordProjectile2 : ModProjectile
    {       
        public string[] swordTextureArray = 
        {
           "MoreShortswords/Content/Weapons/NaturesBless",
           "MoreShortswords/Content/Weapons/DayAbomination",
           "MoreShortswords/Content/Weapons/SkyBlade",
           "MoreShortswords/Content/Weapons/CosmicBlade",
           $"Terraria/Images/Projectile_{ProjectileID.PlatinumShortswordStab}"            
        };
        
        public override void SetStaticDefaults()
        {            
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 20;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }
        public override void SetDefaults()
        {
            Projectile.friendly = true;
			Projectile.extraUpdates = 2;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 15;
            Projectile.ArmorPenetration = 120;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 600;
            Projectile.ArmorPenetration = 150;
        }

        public Player Owner => Main.player[Projectile.owner];        
        public override void AI()
        {


            if (Projectile.ai[0] == 0f)
            {
                Projectile.ai[1] += 1f;
                if (Projectile.ai[1] >= 30f)
                {
                    Projectile.ai[0] = 1f;
                    Projectile.ai[1] = 0f;
                    Projectile.netUpdate = true;
                }
            }
            else
            { 
                float acceleration = 3f;
                Vector2 playerProjDistance = Owner.Center - Projectile.Center;
                float num64 = playerProjDistance.Length();
                if (num64 > 3000f)
                {
                    Projectile.Kill();
                }
                num64 = 15f / num64;
                playerProjDistance.X *= num64;
                playerProjDistance.Y *= num64;

                if (Projectile.velocity.X < playerProjDistance.X)
                {
                    Projectile.velocity.X += acceleration;
                    if (Projectile.velocity.X < 0f && playerProjDistance.X > 0f)
                    {
                        Projectile.velocity.X += acceleration;
                    }
                }
                else if (Projectile.velocity.X > playerProjDistance.X)
                {
                    Projectile.velocity.X -= acceleration;
                    if (Projectile.velocity.X > 0f && playerProjDistance.X < 0f)
                    {
                        Projectile.velocity.X -= acceleration;
                    }
                }
                if (Projectile.velocity.Y < playerProjDistance.Y)
                {
                    Projectile.velocity.Y += acceleration;
                    if (Projectile.velocity.Y < 0f && playerProjDistance.Y > 0f)
                    {
                        Projectile.velocity.Y += acceleration;
                    }
                }
                else if (Projectile.velocity.Y > playerProjDistance.Y)
                {
                    Projectile.velocity.Y -= acceleration;
                    if (Projectile.velocity.Y > 0f && playerProjDistance.Y < 0f)
                    {
                        Projectile.velocity.Y -= acceleration;
                    }
                }

                if (Main.myPlayer == Projectile.owner)
                {
                    if (Projectile.Hitbox.Intersects(Owner.Hitbox))
                    {
                        Projectile.Kill();
                    }
                }
            }

            Lighting.AddLight(Projectile.position, 0.25f, 0.25f, 0.25f);
            Projectile.rotation += 0.4f * Projectile.direction;
        }

        private bool _initialized = false;
        public override bool PreDraw(ref Color lightColor)
        {
            string textureString = "MoreShortswords/Content/Projectiles/FinalSwordProjectile2";
            if (!_initialized)
            {
                textureString = swordTextureArray[Main.rand.Next(0, swordTextureArray.Length)];
                _initialized = true;
            }

            Texture2D texture = (Texture2D)ModContent.Request<Texture2D>(textureString);


            int frameHeight = texture.Height / Main.projFrames[Projectile.type];
            int startY = frameHeight * Projectile.frame;

            Rectangle sourceRectangle = new(0, startY, texture.Width, frameHeight);
            Vector2 origin = sourceRectangle.Size() / 2f;

            SpriteEffects spriteEffects = SpriteEffects.None;
            if (Projectile.direction == -1)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }

            float offsetX = 20f;
            origin.X = (Projectile.spriteDirection == -1 ? sourceRectangle.Width - offsetX : offsetX);

            Color drawColor = Projectile.GetAlpha(lightColor);

            Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), sourceRectangle, drawColor, Projectile.rotation, origin, Projectile.scale, spriteEffects, 0);
            return false;
        }
    }
}
