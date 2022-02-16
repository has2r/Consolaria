using Microsoft.Xna.Framework;
using System;
using Terraria;
using ReLogic.Localization.IME;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Consolaria.Projectiles
{
    public class SpectrallBall : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spectral Ball");
            DisplayName.AddTranslation(GameCulture.Spanish, "Bola Espectral");
        }
        public override void SetDefaults()
        {
            projectile.width = 12;
            projectile.height = 12;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.ignoreWater = true;
            projectile.aiStyle = 6;
            projectile.penetrate = 1;
            projectile.extraUpdates = 3;
            projectile.timeLeft = 180;
            projectile.light = 0.08f;
        }

        public override void AI()
        {
            Lighting.AddLight(projectile.Center, 0f, 0f, 0f);
            projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + (float)Math.PI;

            int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, ModContent.DustType<Dusts.SpectralFlame>(), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f, 50, new Color(), 1.5f);
            Main.dust[dust].noGravity = true;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(2) == 0)
            {
                target.AddBuff(mod.BuffType("SpectralFlame"), 180);
            }
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.LightCyan;
        }
    }
}