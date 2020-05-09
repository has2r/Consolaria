using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Consolaria.Projectiles
{
    public class TitanStar : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Titan Star");
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.Starfury);
            aiType = ProjectileID.Starfury;
            projectile.melee = false;
            projectile.ranged = true;
            projectile.penetrate = 1;
        }

        public override void AI()
        {
            if (Main.rand.Next(2) == 0)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustID.GoldFlame, projectile.velocity.X * 0.4f, projectile.velocity.Y * 0.4f, 0, default(Color), 2f);
            }
        }

        public override void Kill(int timeLeft)
        {
            Vector2 position = projectile.Center;
            int radius = 4;
            for (int x = -radius; x <= radius; x++)
            {
                for (int y = -radius; y <= radius; y++)
                {
                    int xPosition = (int)(x + position.X / 16.0f);
                    int yPosition = (int)(y + position.Y / 16.0f);

                    if (Math.Sqrt(x * x + y * y) <= radius + 0.5)
                    {
                        Dust.NewDust(position, 20, 20, DustID.GoldFlame, 0.0f, 0.0f, 120, new Color(), 1f);
                    }
                }
            }
        }       
    }
}