using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.ID;
using System;

namespace MoreShortswords.Content.Projectiles
{
    public class SawBladeProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Saw Blade"); 
        }

        public override void SetDefaults()
        {          
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
            Projectile.ownerHitCheck = true;            
            Projectile.ArmorPenetration = 10;
            Projectile.aiStyle = -1;
            Projectile.width = 56;
            Projectile.height = 56;
            Projectile.hide = true;
        }

        public override void AI()
        {            
            if (Projectile.soundDelay <= 0)
            {
                SoundEngine.PlaySound(SoundID.Item22, Projectile.position);
                Projectile.soundDelay = 30;
            }

            Player player = Main.player[Projectile.owner];
                       
            Projectile.rotation += 0.4f * player.direction;
            // Projectile.position.X = Projectile.position.X + (player.width / 2 * player.direction);            
            Projectile.Center = player.MountedCenter + new Vector2(30f * player.direction, 0f);
            Projectile.position.Y = player.position.Y;
            Projectile.spriteDirection = player.direction;

            player.itemTime = player.itemAnimation = 2;        
            player.itemRotation = Projectile.rotation;
            player.heldProj = Projectile.whoAmI;

            if (Main.myPlayer == Projectile.owner && !player.controlUseItem)
            {
                Projectile.Kill();
            }      

            if (player.dead || !player.active)
            {
                Projectile.Kill();
            }

            SetVisualOffsets();
        }

        private void SetVisualOffsets()
        {
            int halfProjWidth = Projectile.width / 2;
            int halfProjHeight = Projectile.height / 2;

            DrawOriginOffsetX = 0;
            DrawOffsetX = -((56 / 2) - halfProjWidth);
            DrawOriginOffsetY = -((56 / 2) - halfProjHeight);
        }

    }
}
