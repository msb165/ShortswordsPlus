using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System;
using Terraria.Audio;
using MoreShortswords.Content.Weapons;
using Microsoft.Xna.Framework.Graphics;

namespace MoreShortswords.Content.Projectiles
{
    public class FinalSwordProjectile : ShortSwordProjectile
    {
        public string[] textureArray = ["MoreShortswords/Content/Weapons/FinalSword", "MoreShortswords/Content/Projectiles/FinalSwordShadow"];

        public override string Texture => ModContent.GetInstance<FinalSword>().Texture;
        public override void SetDefaults()
        {
            base.SetDefaults();
			Projectile.Size = new(80);
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 15;
        }

        public override void AI()
        {
            base.AI();
        }

        public override void SetVisualOffsets()
        {
            base.SetVisualOffsets();
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.Weak, 900);
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = (Texture2D)ModContent.Request<Texture2D>(textureArray[(int)Projectile.ai[1]]);

            SpriteEffects spriteEffects = SpriteEffects.None;

            if (Projectile.spriteDirection == -1)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }

            Main.spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, Color.White, Projectile.rotation, texture.Size() / 2f, Projectile.scale, spriteEffects, 0);
            return false;
        }
    }
}
