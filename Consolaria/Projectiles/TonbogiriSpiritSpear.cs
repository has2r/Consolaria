using System;
using Microsoft.Xna.Framework;
using Terraria;
using ReLogic.Localization.IME;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Consolaria.Projectiles
{
	internal class TonbogiriSpiritSpear : ModProjectile
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tonbogiri");
            DisplayName.AddTranslation(GameCulture.Spanish, "Tonbogiri");
        }

		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 20;
			projectile.aiStyle = 19;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.tileCollide = false;
			projectile.melee = true;
			projectile.scale = 1f;
			projectile.damage = 30;
		}
		public float MovementFactor
		{
			get
			{
				return projectile.ai[0];
			}
			set
			{
				projectile.ai[0] = value;
			}
		}
		public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(Color.White * ((255 - projectile.alpha) / 255f));
		}
		public override void AI()
		{
			int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 68, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 136, default(Color), 1.2f);
			Main.dust[dust].noGravity = true;
			projectile.scale = projectile.ai[1];
			Player player = Main.player[projectile.owner];
			Vector2 vector = player.RotatedRelativePoint(player.MountedCenter, true);
			projectile.direction = player.direction;
			player.heldProj = projectile.whoAmI;
			player.itemTime = player.itemAnimation;
			projectile.position.X = vector.X - (projectile.width / 2);
			projectile.position.Y = vector.Y - (projectile.height / 2);
			if (MovementFactor == 0f)
			{
				MovementFactor = 3f;
				projectile.netUpdate = true;
			}
			MovementFactor -= ((player.itemAnimation < player.itemAnimationMax / 4) ? 1.5f : -1.5f);
			projectile.position += projectile.velocity * MovementFactor;
			projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + MathHelper.ToRadians(135f);
			if (projectile.spriteDirection == -1)
			{
				projectile.rotation -= MathHelper.ToRadians(90f);
			}
		}
		public override void Kill(int timeLeft)
		{
			Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 68, projectile.oldVelocity.X * 0.1f, projectile.oldVelocity.Y * 0.1f);
		}
	}
}
