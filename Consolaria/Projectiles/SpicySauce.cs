using System;
using Terraria;
using Terraria.ModLoader;

namespace Consolaria.Projectiles
{
    public class SpicySauce : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.thrown = true;
            projectile.width = 14;
            projectile.height = 14;
            projectile.friendly = true;
            projectile.tileCollide = true;
            projectile.aiStyle = 2;
            projectile.penetrate = 1;
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(13, (int)projectile.position.X, (int)projectile.position.Y); // Shatter
            Gore.NewGore(projectile.position, -projectile.oldVelocity * 0.2f, 704, 1f);
            Gore.NewGore(projectile.position, -projectile.oldVelocity * 0.2f, 705, 1f);

            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X * 0, projectile.velocity.Y * 0, mod.ProjectileType("SpicyExplosion"), (int)((double)projectile.damage * 0.75f), projectile.knockBack, projectile.owner, 0f, 0f);
            --projectile.penetrate;
        }
    }
}
