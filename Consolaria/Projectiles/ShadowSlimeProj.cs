using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using ReLogic.Localization.IME;
using Terraria.Localization;
using Terraria.ID;
using System;

namespace Consolaria.Projectiles
{
    class ShadowSlimeProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shadow Slime Projectile");
            DisplayName.AddTranslation(GameCulture.Spanish, "Proyectil de Slime Sombrío");
        }

        public override void SetDefaults()
        {
            projectile.alpha = 255;
            projectile.width = 6;
            projectile.height = 6;
            projectile.aiStyle = 1;
            projectile.hostile = true;
            projectile.penetrate = -1;
            projectile.scale = 1.2f;
        }

        public override void AI()
        {
            if (projectile.alpha == 0)
            {
                int dust = Dust.NewDust(projectile.oldPosition - projectile.velocity * 3f, projectile.width, projectile.height, 50, 0f, 0f, 100, default, 1f);
                Main.dust[dust].noGravity = false;
                Main.dust[dust].noLight = true;
                Main.dust[dust].velocity *= 0.5f;
            }

            projectile.alpha -= 50;
            if (projectile.alpha < 0)
            {
                projectile.alpha = 0;
            }
            if (projectile.ai[1] == 0f)
            {
                projectile.ai[1] = 1f;
                Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 17);
            }
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item112, projectile.Center);
            Vector2 position = projectile.Center;
            int radius = 2;
            for (int i = 0; i < 20; i++)
            {
                int dustID = Dust.NewDust(new Vector2(projectile.Center.X - 1f, projectile.Center.Y - 1f), 2, 2, 50, 0f, 0f, 100, default, 1.6f);
                Main.dust[dustID].velocity *= 0.5f;
                Main.dust[dustID].noLight = true;
                Main.dust[dustID].noGravity = false;
            }

            for (int j = 0; j < 20; j++)
            {
                int dustID2 = Dust.NewDust(new Vector2(projectile.Center.X - 1f, projectile.Center.Y - 1f), 2, 2, 50, 0f, 0f, 100, default, 2f);
                Main.dust[dustID2].velocity *= 0.5f;
                Main.dust[dustID2].noLight = true;
                Main.dust[dustID2].noGravity = false;
            }

            for (int x = -radius; x <= radius; x++)
            {
                for (int y = -radius; y <= radius; y++)
                {
                    int xPosition = (int)(x + position.X / 16f);
                    int yPosition = (int)(y + position.Y / 16f);
                    if (Math.Sqrt((x * x + y * y)) <= radius + 0.5)
                    {
                        WorldGen.Convert(xPosition, yPosition, 1, 1);
                    }
                }
            }
        }
    }
}
