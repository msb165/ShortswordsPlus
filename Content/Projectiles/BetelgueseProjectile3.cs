using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;


namespace MoreShortswords.Content.Projectiles
{
    public class BetelgueseProjectile3 : ModProjectile
    {
        public override string Texture => $"Terraria/Images/Projectile_{ProjectileID.SuperStar}";

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 8;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Projectile.width = 22;
            Projectile.height = 24;
            Projectile.penetrate = -1;
            Projectile.ArmorPenetration = 200;
            Projectile.friendly = true;
            Projectile.ownerHitCheck = true;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 200;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 20;
        }

        public override void AI()
        {
            base.AI();

            if (!Main.dedServ)
            {
                if (Main.rand.NextBool(8))
                {
                    Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Enchanted_Pink, Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f, 150, default, 1.2f);
                }
                if (Main.rand.NextBool(20))
                {
                    Gore.NewGore(Projectile.GetSource_FromThis(), Projectile.position, new Vector2(Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f), Main.rand.Next(16, 18));
                }
            }
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = (Texture2D)ModContent.Request<Texture2D>(Texture);

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
            origin.X = Projectile.spriteDirection == -1 ? sourceRectangle.Width - offsetX : offsetX;

            Color[] arrColors = { Color.Gold, Color.HotPink, Color.Orange };

            for (int i = 0; i < Projectile.oldPos.Length; i++)
            {
                float num = 8 - i;
                Color drawColor2 = Projectile.GetAlpha(arrColors[Main.rand.Next(0, arrColors.Length)]) * ((Projectile.oldPos.Length - i) / (float)Projectile.oldPos.Length);
                drawColor2 *= num / (ProjectileID.Sets.TrailCacheLength[Projectile.type] * 1.5f);
                Main.EntitySpriteDraw(texture, Projectile.oldPos[i] - Main.screenPosition + origin + new Vector2(0f, Projectile.gfxOffY), null, drawColor2, Projectile.velocity.ToRotation() + MathHelper.PiOver2, origin, Projectile.scale, spriteEffects, 0);
            }

            Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), sourceRectangle, arrColors[Main.rand.Next(0, arrColors.Length)], Projectile.velocity.ToRotation() + MathHelper.PiOver2, origin, Projectile.scale, spriteEffects, 0);
            return false;
        }


        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Player player = new();


            if (Main.player[Projectile.owner].ownedProjectileCounts[ProjectileID.SuperStarSlash] < 14 && target.type != NPCID.TargetDummy)
            {
                for (int numOfSlashes = 0; numOfSlashes < 4; numOfSlashes++)
                {
                    Vector2 newV = Main.rand.NextVector2CircularEdge(200f, 300f);
                    if (newV.Y < 0f)
                    {
                        newV.Y *= -1f;
                    }
                    newV.Y += 100f;
                    Vector2 Vvector = newV.SafeNormalize(Vector2.UnitY) * 6f;
                    Projectile.NewProjectile(target.GetSource_OnHit(target), target.position - Vvector * 20f, Vvector, ProjectileID.SuperStarSlash, Projectile.damage, 0f, Projectile.owner, target.position.Y);
                }
            }

            if (Main.player[Projectile.owner].ownedProjectileCounts[ModContent.ProjectileType<BetelgueseProjectile2>()] < 24 && target.type != NPCID.TargetDummy)
            { 
                for (int numOfStars = 0; numOfStars < 4; numOfStars++)
                {
                    Vector2 vector = new(target.Center.X + 400, Projectile.position.Y - Main.rand.Next(500, 800));
                    float num16 = target.Center.X + (Projectile.width / 2) - vector.X;
                    float num17 = Projectile.position.Y + (Projectile.height / 2) - vector.Y;
                    num16 += Main.rand.Next(-100, 101);
                    float num18 = (float)Math.Sqrt(num16 * num16 + num17 * num17);
                    num18 = 25f / num18;
                    num16 *= num18;
                    num17 *= num18;

                    Projectile.NewProjectile(target.GetSource_OnHit(target), vector, new Vector2(num16, num17), ModContent.ProjectileType<BetelgueseProjectile2>(), Projectile.damage, 4.5f, player.whoAmI, 0f, Projectile.position.Y);
                }
            }
        }

    }
}
