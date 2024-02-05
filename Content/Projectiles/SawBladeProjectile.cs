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
        public override void SetDefaults()
        {          
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
            Projectile.ownerHitCheck = true;            
            Projectile.ArmorPenetration = 10;
            Projectile.aiStyle = -1;
            Projectile.width = 52;
            Projectile.height = 52;
            Projectile.hide = true;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 29;
        }

        Player Owner => Main.player[Projectile.owner];

        public override void AI()
        {           
            Projectile.rotation += 0.4f * Owner.direction;           
            Projectile.Center = Owner.MountedCenter + new Vector2(32f * Owner.direction, 0f);

            Projectile.position.Y = Owner.position.Y;
            Projectile.spriteDirection = Owner.direction; 

            if (Projectile.soundDelay <= 0)
            {
                SoundEngine.PlaySound(SoundID.Item22, Projectile.position);
                Projectile.soundDelay = 30;
            }

            if (!Owner.controlUseItem && !Owner.noItems && !Owner.CCed || Owner.dead || !Owner.active) 
            {
                Projectile.Kill();
            }     
 

            SetPlayerValues();
            SetVisualOffsets();
        }

        private void SetPlayerValues()
        {
            Owner.itemTime = Owner.itemAnimation = 2;
            Owner.itemRotation = Projectile.rotation;
            Owner.heldProj = Projectile.whoAmI;
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
