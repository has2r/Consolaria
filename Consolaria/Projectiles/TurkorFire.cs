using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Consolaria.Projectiles
{
	public class TurkorFire : ModProjectile
	{
        public override string Texture
        {
            get
            {
                return "Terraria/Projectile_376";
            }
        }

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.ImpFireball);
			aiType = ProjectileID.ImpFireball;
            projectile.scale = 1.1f;
            projectile.penetrate = -1;
            projectile.timeLeft = 1600;
            projectile.friendly = false;
            projectile.hostile = true;
		}

        public override void AI()
        {
            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 136, default(Color), 1.2f);
            Main.dust[dust].noGravity = true;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(2) == 0)
            {
                target.AddBuff(BuffID.OnFire, 180, true);
            }
        }        
    }
}