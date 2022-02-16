using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using ReLogic.Localization.IME;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Consolaria.Projectiles
{
	public class ArchScythe : ModProjectile
	{
		private float aiTimer;
		private float rotationTimer = 3.14f;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Arch Scythe");
			DisplayName.AddTranslation(GameCulture.Spanish, "Archiguadaña");
		}
		public override void SetDefaults()
		{
			projectile.width = 48;
			projectile.height = 48;
			projectile.light = 0.3f;
			projectile.hostile = true;
			projectile.penetrate = 1;
			projectile.tileCollide = true;
			projectile.scale = 0.9f;
			projectile.alpha = 0;
		}
		public override void AI()
		{
			if (projectile.timeLeft > 200)
			projectile.velocity *= 1.05f;
			
			if (projectile.timeLeft == 299)
			{
				float dustCount = 32f;
				int num1 = 0;
				while (num1 < dustCount)
				{
					Vector2 vector = Vector2.UnitX * 0f;
					vector += -Vector2.UnitY.RotatedBy(num1 * (8f / dustCount), default) * new Vector2(18f, 18f);
					vector = vector.RotatedBy(projectile.velocity.ToRotation(), default);
					int num3 = Dust.NewDust(projectile.Center, 0, 0, DustID.Fire, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num3].noGravity = true;
					Main.dust[num3].position = new Vector2(projectile.Center.X, projectile.Center.Y) + vector;
					Main.dust[num3].velocity = projectile.velocity * 0f + vector.SafeNormalize(Vector2.UnitY) * 0.8f;
					int num4 = num1;
					num1 = num4 + 1;
				}
			}
			
			int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Fire, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 1.2f);
			Main.dust[dust].noGravity = true;
			
			projectile.rotation += 2 / rotationTimer;
			rotationTimer += 0.01f;
		}
		public override void OnHitPlayer(Player target, int damage, bool crit)
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
		/*public override Color? GetAlpha(Color lightColor)
		{
			return Color.Red;
		}*/
	}
}