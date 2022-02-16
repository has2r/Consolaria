using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using ReLogic.Localization.IME;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Consolaria.Projectiles
{
	public class EternityScythe : ModProjectile
	{
		public override string Texture
		{
			get
			{
				return "Terraria/Projectile_45";
			}
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Eternity Scythe");
			DisplayName.AddTranslation(GameCulture.Spanish, "Guadaña de la eternidad");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.DemonScythe);
			aiType = ProjectileID.DemonScythe;
			projectile.scale = 0.6f;
			projectile.penetrate = 1;
			projectile.minion = true;
		}

		public override void AI()
		{
			int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<Dusts.TizonaDust>(), projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 136, default(Color), 1.2f);
			Main.dust[dust].noGravity = true;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(2) == 0)
			{
				target.AddBuff(mod.BuffType("SpectralFlame"), 180);
			}
		}        
	}
}