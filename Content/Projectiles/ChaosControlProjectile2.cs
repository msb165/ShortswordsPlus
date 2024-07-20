using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using static Humanizer.In;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace MoreShortswords.Content.Projectiles
{ 

    public class ChaosControlProjectile2 : ModProjectile
    {
        public override string Texture => "MoreShortswords/Content/Projectiles/ChaosControlProjectile2";

        public override void SetDefaults()
        {            
            Projectile.ArmorPenetration = 20;
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
            Projectile.timeLeft = 300;
            //Projectile.ownerHitCheck = true;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 20;
            Projectile.aiStyle = -1;
            Projectile.penetrate = -1;
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

            if (target.type != NPCID.TargetDummy && !target.immortal && !target.SpawnedFromStatue && !NPCID.Sets.CountsAsCritter[target.type])
            {
                Vector2 newV = Main.rand.NextVector2CircularEdge(200f, 200f);
                if (newV.Y < 0f)
                {
                    newV.Y *= -1f;
                }
                newV.Y += 100f;
                Vector2 Vvector = newV.SafeNormalize(Vector2.UnitY) * 6f;
                Projectile starproj = Projectile.NewProjectileDirect(target.GetSource_OnHit(target), target.Center - Vvector * 20f, Vvector, ProjectileID.SuperStarSlash, Projectile.damage / 2, 0f, Projectile.owner, 0f, target.Center.Y);
                starproj.DamageType = DamageClass.MeleeNoSpeed;
            }
        }

        public override Color? GetAlpha(Color lightColor) => Color.White with { A = 0 } * Projectile.Opacity;

        public override void AI()
        {
            if (Projectile.ai[0] == 0f)
            {
                Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2 - MathHelper.PiOver4;
                Projectile.ai[0] = 1f;
            }

            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2 - MathHelper.PiOver4;
            
            if (Projectile.alpha < 0)
            {
                Projectile.alpha = 0;
            }

            Projectile.alpha += 10;
            if (Projectile.alpha >= 255)
            {
                Projectile.Kill();
            }
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = TextureAssets.Projectile[Type].Value;
            Color drawColor = Projectile.GetAlpha(lightColor);
            Vector2 drawOrigin = new(texture.Width, 0f);
            float rotation = Projectile.rotation;

            Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, null, drawColor, rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            return false;
        }
    }
}
