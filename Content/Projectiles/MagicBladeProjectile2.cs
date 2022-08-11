using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MoreShortswords.Content.Projectiles
{
    public class MagicBladeProjectile2 : ModProjectile
    {
        public override string Texture => "MoreShortswords/Content/Projectiles/MagicBladeProjectile";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Deity Spear");
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 8;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.EnchantedBoomerang);
            Projectile.width = 40;
            Projectile.height = 40;
            Projectile.ArmorPenetration = 15;
            Projectile.penetrate = 2;
        }

        public override void AI()
        {
            base.AI();
            Projectile.rotation += 0.25f * Projectile.direction;
       
            int boomDust = Dust.NewDust(Projectile.oldPosition, Projectile.width, Projectile.height, DustID.Clentaminator_Cyan, Projectile.velocity.X * 0.25f, Projectile.velocity.Y * 0.25f, 150, default, 0.50f);
            Main.dust[boomDust].noGravity = true;            

            Player player = new()
            {
                heldProj = Projectile.whoAmI,
                itemRotation = Projectile.rotation
            }; 

            if (player.dead || player.CCed || player.noItems)
            {
                Projectile.Kill();
            }

            SetVisualOffsets();
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = (Texture2D)ModContent.Request<Texture2D>(Texture);

            Color drawColor = Projectile.GetAlpha(lightColor);

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
            Vector2 drawOrigin = new (texture.Width / 2, texture.Height / 2);

            for (int i = 0; i < Projectile.oldPos.Length; i++)
            {
                float num = 8 - i; 
                Color drawColor2 = Projectile.GetAlpha(lightColor) * ((Projectile.oldPos.Length - i) / (float)Projectile.oldPos.Length);
                drawColor2 *= num / (ProjectileID.Sets.TrailCacheLength[Projectile.type] * 1.5f);
                Main.EntitySpriteDraw(texture, (Projectile.oldPos[i] - Main.screenPosition) + drawOrigin + new Vector2(0f, Projectile.gfxOffY), null, drawColor2, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }

            Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), sourceRectangle, drawColor, Projectile.rotation, origin, Projectile.scale, spriteEffects, 0);
            return false;
        }


        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Player player = new();

            if (!target.HasBuff(BuffID.Confused))
            {
                target.AddBuff(BuffID.Confused, 300);
            }

            if (Main.player[Projectile.owner].ownedProjectileCounts[ModContent.ProjectileType<MagicBladeProjectile3>()] < 4 && target.type != NPCID.TargetDummy)
            {
                Projectile.NewProjectile(target.GetSource_OnHit(target), Projectile.position, new Vector2(Projectile.velocity.X * -player.direction, -Projectile.velocity.Y), ModContent.ProjectileType<MagicBladeProjectile3>(), 25, 5.7f, player.whoAmI);
            }
            
        }

        private void SetVisualOffsets()
        {
            int halfProjWidth = Projectile.width / 2;
            int halfProjHeight = Projectile.height / 2;

            DrawOriginOffsetX = 0;
            DrawOffsetX = -((50 / 2) - halfProjWidth);
            DrawOriginOffsetY = -((50 / 2) - halfProjHeight);
        }


    }
}
