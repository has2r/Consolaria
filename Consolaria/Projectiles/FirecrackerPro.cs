using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ReLogic.Localization.IME;
using Terraria.Localization;

namespace Consolaria.Projectiles
{
    public class FirecrackerPro : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Firecracker");
            DisplayName.AddTranslation(GameCulture.Spanish, "Petardo");
            DisplayName.AddTranslation(GameCulture.Russian, "Петарда");
        }
        public override void SetDefaults()
        {
            projectile.width = 20;   
            projectile.height = 38;    
            projectile.aiStyle = 16;  
            projectile.friendly = true; 
            projectile.penetrate = 3; 
            projectile.timeLeft = 120; 
        }    
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{		
			target.AddBuff(BuffID.OnFire, 120);
		}
        public override void Kill(int timeLeft)
        {
            Vector2 position = projectile.Center;
            Main.PlaySound(SoundID.Item14, (int)position.X, (int)position.Y);
            int radius = 10;    
            for (int x = -radius; x <= radius; x++)
            {
                for (int y = -radius; y <= radius; y++)
                {
                    int xPosition = (int)(x + position.X / 16.0f);
                    int yPosition = (int)(y + position.Y / 16.0f);

                    if (Math.Sqrt(x * x + y * y) <= radius + 0.5)  
                    {                   
                        Dust.NewDust(position, 22, 22, DustID.Smoke, 0.0f, 0.0f, 120, new Color(), 1f);  
                    }
                }
            }
        }
    }
}
