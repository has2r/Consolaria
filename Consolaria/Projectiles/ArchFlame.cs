using System;
using Terraria;
using Terraria.ID;
using ReLogic.Localization.IME;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Consolaria.Projectiles
{
	public class ArchFlame : ModProjectile
	{
		private float aiTimer;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("A-Tier Flaming Breath");
			DisplayName.AddTranslation(GameCulture.Spanish, "Aliento llameante de nivel A");
		}
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.Flames);
			projectile.width = 10;
			projectile.height = 10;
			projectile.light = 0.3f;
			projectile.hostile = true;
			projectile.penetrate = 1;
			projectile.tileCollide = false;
			projectile.timeLeft = 600;
		}
		public override void AI()
		{
			projectile.velocity *= 0.95f;
		}
	}
}