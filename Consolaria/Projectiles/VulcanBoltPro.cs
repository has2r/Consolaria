using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using ReLogic.Localization.IME;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Consolaria.Projectiles
{
    public class VulcanBoltPro : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vulcan Bolt");
            DisplayName.AddTranslation(GameCulture.Spanish, "Relámpago Volcánico");
        }

        public override void SetDefaults()
        {
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.arrow = true;
            projectile.width = 5;
            projectile.height = 5;
            projectile.aiStyle = 1;
            projectile.penetrate = 1;
            projectile.tileCollide = true;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 240);
        }
        public override void AI()
        {
            if (Main.rand.Next(2) == 0)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 6, projectile.velocity.X * 0.4f, projectile.velocity.Y * 0.4f);
            }
        }
        public override void Kill(int timeLeft)
        {
            Vector2 position = projectile.Center;
            Main.PlaySound(SoundID.Item14, (int)position.X, (int)position.Y);
            int radius = 5;
            for (int x = -radius; x <= radius; x++)
            {
                for (int y = -radius; y <= radius; y++)
                {
                    int xPosition = (int)(x + position.X / 16.0f);
                    int yPosition = (int)(y + position.Y / 16.0f);

                    if (Math.Sqrt(x * x + y * y) <= radius + 0.5)
                    {
                        Dust.NewDust(position, 20, 20, DustID.Smoke, 0.0f, 0.0f, 120, new Color(), 1f);
                        Dust.NewDust(position, 20, 20, 6, 0.0f, 0.0f, 120, new Color(), 1f);
                    }
                }
            }
        }
    }
}
