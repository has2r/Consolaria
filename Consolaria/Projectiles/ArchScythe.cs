using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Consolaria.Projectiles
{
	public class ArchScythe : ModProjectile
	{
		private float aiTimer;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Arch Scythe");
		}
		public override void SetDefaults()
		{
			projectile.width = 48;
			projectile.height = 48;
			projectile.light = 0.3f;
			projectile.aiStyle = 18;
			projectile.hostile = true;
			projectile.penetrate = 1;
			projectile.tileCollide = true;
			projectile.scale = 0.9f;
		}
		public override void AI()
		{
			int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 1.2f);
			Main.dust[dust].noGravity = true;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.OnFire, 180);
		}
		public override void Kill(int timeLeft)
		{
			Vector2 position = projectile.Center;
			Main.PlaySound(SoundID.Item14, (int)position.X, (int)position.Y);
			for (int num505 = 0; num505 < 30; num505++)
			{
				int num506 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, projectile.velocity.X, projectile.velocity.Y, 100, default(Color), 1.5f);
				Main.dust[num506].noGravity = true;
				Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, projectile.velocity.X, projectile.velocity.Y, 100, default(Color), 1.1f);
			}
		}
		public override Color? GetAlpha(Color lightColor)
		{
			return Color.Red;
		}
	}
}