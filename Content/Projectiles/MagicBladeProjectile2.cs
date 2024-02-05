using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using MoreShortswords.Content.Weapons;

namespace MoreShortswords.Content.Projectiles
{
    public class MagicBladeProjectile2 : ModProjectile
    {
        public override string Texture => ModContent.GetInstance<MagicBlade>().Texture;

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailingMode[Projectile.type] = 3;
        }

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.EnchantedBoomerang);
            Projectile.Size = new(30);
            Projectile.penetrate = -1;
            Projectile.usesIDStaticNPCImmunity = true;
            Projectile.idStaticNPCHitCooldown = 10;
        }

        Player Owner => Main.player[Projectile.owner];

        public override void AI()
        {
            base.AI();
            Projectile.rotation += 0.25f * Projectile.direction;
       
            int boomDust = Dust.NewDust(Projectile.oldPosition, Projectile.width, Projectile.height, DustID.Clentaminator_Cyan, Projectile.velocity.X * 0.25f, Projectile.velocity.Y * 0.25f, 150, default, 0.50f);
            Main.dust[boomDust].noGravity = true;            

            if (Owner.dead || Owner.CCed || Owner.noItems)
            {
                Projectile.Kill();
            }

            SetVisualOffsets();
        }    


        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (!target.HasBuff(BuffID.Confused))
            {
                target.AddBuff(BuffID.Confused, 300);
            }

            if (Owner.ownedProjectileCounts[ModContent.ProjectileType<MagicBladeProjectile3>()] < 4 && !target.immortal && !target.SpawnedFromStatue && !NPCID.Sets.CountsAsCritter[target.type])
            {
                Projectile.NewProjectile(target.GetSource_OnHit(target), Projectile.position, new Vector2(Projectile.velocity.X * -Owner.direction, -Projectile.velocity.Y), ModContent.ProjectileType<MagicBladeProjectile3>(), 30, 6f, Owner.whoAmI);
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
        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = TextureAssets.Projectile[Type].Value;
            Texture2D glowSphere = (Texture2D)ModContent.Request<Texture2D>("MoreShortswords/Assets/GlowSphere");

            Color drawColorGlow = Color.Cyan with { A = 0 };
            Color drawColor = Color.White;
            Color drawColorTrail = drawColorGlow;

            Vector2 drawOrigin = texture.Size() / 2f;

            for (int i = 0; i < Projectile.oldPos.Length; i++)
            {
                Vector2 drawPosTrail = Projectile.oldPos[i] - Main.screenPosition + Vector2.One * 15 + new Vector2(0f, Projectile.gfxOffY);
                drawColorTrail *= 0.75f;

                Main.EntitySpriteDraw(texture, drawPosTrail, texture.Frame(), drawColorTrail, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }

            Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), texture.Frame(), drawColor, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            Main.EntitySpriteDraw(glowSphere, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, drawColorGlow, Projectile.rotation, glowSphere.Size() / 2f, Projectile.scale, SpriteEffects.None, 0);
            return false;
        }
    }
}
