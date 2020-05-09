using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Consolaria.Projectiles
{
    public class TurkorFeather : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Turkor Feather");
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.HarpyFeather);
            aiType = ProjectileID.HarpyFeather;
            projectile.hostile = true;
            projectile.scale = 1.5f;
            projectile.penetrate = 1;
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