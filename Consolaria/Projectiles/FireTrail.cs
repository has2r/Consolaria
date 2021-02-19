using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Consolaria.Projectiles
{
	public class FireTrail : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 8;
			projectile.height = 8;
			projectile.timeLeft = 100;
			projectile.alpha = 30;
			projectile.penetrate = -1;
			projectile.hostile = true;
			projectile.tileCollide = true;
		}
		public override bool PreAI()
		{
			if (Main.rand.Next(2) == 0)
			{
				int index1 = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 6, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f, 0, new Color(), 1f);
				Main.dust[index1].noGravity = true;
				Main.dust[index1].velocity *= 0.5f;
				Main.dust[index1].scale = 1f;
			}
			return true;
		}
		public override void OnHitPlayer(Player target, int damage, bool crit)
        {
			target.AddBuff(BuffID.OnFire, 180);
		}
	}
}
