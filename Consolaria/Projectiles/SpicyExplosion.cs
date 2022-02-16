using Microsoft.Xna.Framework;
using Terraria;
using ReLogic.Localization.IME;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Consolaria.Projectiles
{
    public class SpicyExplosion : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spicy Explosion");
            DisplayName.AddTranslation(GameCulture.Spanish, "Explosión Picante");
        }

        public override void SetDefaults()
        {
            projectile.thrown = true;
            projectile.timeLeft = 420;
            projectile.width = 98;
            projectile.height = 98;
            projectile.friendly = true;
            Main.projFrames[projectile.type] = 7;
            projectile.tileCollide = false;
            projectile.penetrate = -1;
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
        
        public override void AI()
        {
            projectile.frameCounter++;
            if (projectile.frameCounter > 2)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame >= 7)
            { projectile.Kill(); }
        }

        public override void Kill(int timeLeft)
        {          
            Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 0);
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("HotSauce"), 600);           
        }
    } 
}