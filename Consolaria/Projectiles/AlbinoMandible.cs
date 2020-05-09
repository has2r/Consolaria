using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Consolaria.Projectiles
{
    public class AlbinoMandible : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Albino Mandible");
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.IceBoomerang);
            projectile.aiStyle = 3;
            projectile.width = 30;
            projectile.height = 30;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.tileCollide = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 720;
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