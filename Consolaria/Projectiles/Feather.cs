using Terraria;
using Terraria.ID;
using ReLogic.Localization.IME;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Consolaria.Projectiles
{
    public class Feather : ModProjectile
    {   
         public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Feather");
            DisplayName.AddTranslation(GameCulture.Spanish, "Pluma");
        }   

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.HarpyFeather);
            aiType = ProjectileID.HarpyFeather;
            projectile.hostile = false;
            projectile.friendly = true;
            projectile.scale = 1.1f;
            projectile.penetrate = 3;
        }
        
        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 5; k++)
            {
                int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 1, projectile.oldVelocity.X * 0.1f, projectile.oldVelocity.Y * 0.1f);
            }
            Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 0);
        }             
    }
}