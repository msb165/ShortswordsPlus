using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace MoreShortswords.Content.Projectiles
{
    public class FinalSwordProjectile2 : ModProjectile
    {
     
        public string[] myStringArray = 
            {
            "MoreShortswords/Content/Projectiles/FinalSwordProjectile2", 
            "MoreShortswords/Content/Projectiles/NaturesBlessProjectile",
            "MoreShortswords/Content/Projectiles/DayAbominationProjectile",
            "MoreShortswords/Content/Projectiles/CosmicBladeProjectile",
            "MoreShortswords/Content/Projectiles/SkyBladeProjectile",
            $"Terraria/Images/Projectile_{ProjectileID.PlatinumShortswordStab}"
        };        
        
        public override string Texture => myStringArray[Main.rand.Next(0, myStringArray.Length)];

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = (Texture2D)ModContent.Request<Texture2D>(Texture);
            
            int frameHeight = texture.Height / Main.projFrames[Projectile.type];
            int startY = frameHeight * Projectile.frame;

            Rectangle sourceRectangle = new Rectangle(0, startY, texture.Width, frameHeight);
            Vector2 origin = sourceRectangle.Size() / 2f;


            SpriteEffects spriteEffects = SpriteEffects.None;
            if (Projectile.direction == -1)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }

            float offsetX = 20f;
            origin.X = (float)(Projectile.spriteDirection == -1 ? sourceRectangle.Width - offsetX : offsetX);

            Color drawColor = Projectile.GetAlpha(lightColor);

            Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), sourceRectangle, drawColor, Projectile.rotation, origin, Projectile.scale, spriteEffects, 0);

            return false;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Apogee");
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
                float num60 = 15f;
                float num61 = 3f;
                Vector2 vector6 = new Vector2(Projectile.position.X + Projectile.width * 0.5f, Projectile.position.Y + Projectile.height * 0.5f);
                float num62 = Main.player[Projectile.owner].position.X + (Main.player[Projectile.owner].width / 2) - vector6.X;
                float num63 = Main.player[Projectile.owner].position.Y + (Main.player[Projectile.owner].height / 2) - vector6.Y;
                float num64 = (float)Math.Sqrt(num62 * num62 + num63 * num63);
                if (num64 > 3000f)
                {
                    Projectile.Kill();
                }
                num64 = num60 / num64;
                num62 *= num64;
                num63 *= num64;

                if (Projectile.velocity.X < num62)
                {
                    Projectile.velocity.X += num61;
                    if (Projectile.velocity.X < 0f && num62 > 0f)
                    {
                        Projectile.velocity.X += num61;
                    }
                }
                else if (Projectile.velocity.X > num62)
                {
                    Projectile.velocity.X -= num61;
                    if (Projectile.velocity.X > 0f && num62 < 0f)
                    {
                        Projectile.velocity.X -= num61;
                    }
                }
                if (Projectile.velocity.Y < num63)
                {
                    Projectile.velocity.Y += num61;
                    if (Projectile.velocity.Y < 0f && num63 > 0f)
                    {
                        Projectile.velocity.Y += num61;
                    }
                }
                else if (Projectile.velocity.Y > num63)
                {
                    Projectile.velocity.Y -= num61;
                    if (Projectile.velocity.Y > 0f && num63 < 0f)
                    {
                        Projectile.velocity.Y -= num61;
                    }
                }

                if (Main.myPlayer == Projectile.owner)
                {
                    Rectangle rectangle = new ((int)Projectile.position.X, (int)Projectile.position.Y, Projectile.width, Projectile.height);
                    Rectangle value = new ((int)Main.player[Projectile.owner].position.X, (int)Main.player[Projectile.owner].position.Y, Main.player[Projectile.owner].width, Main.player[Projectile.owner].height);
                    if (rectangle.Intersects(value))
                    {
                        Projectile.Kill();
                    }
                }
            }

            Lighting.AddLight(Projectile.position, 0.25f, 0.25f, 0.25f);
            Projectile.rotation += 0.4f * Projectile.direction;
        }
    }
}
