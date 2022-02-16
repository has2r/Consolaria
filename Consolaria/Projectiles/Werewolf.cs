using Microsoft.Xna.Framework;
using Terraria;
using ReLogic.Localization.IME;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Consolaria.Projectiles
{	
	public class Werewolf : ModProjectile
	{		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Werewolf");
            DisplayName.AddTranslation(GameCulture.Spanish, "Hombre Lobo");
			Main.projFrames[projectile.type] = 16;
		}
		
		public override void SetDefaults()
		{
			projectile.CloneDefaults(334);
			aiType = 334;
            Main.projPet[projectile.type] = true;
            projectile.width = 34;
			projectile.height = 52;
		}
		
		public override bool PreAI()
		{
			Player player = Main.player[projectile.owner];
			player.zephyrfish = false;
			return true;
		}

        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            CPlayer modPlayer = (CPlayer)player.GetModPlayer(mod, "CPlayer");
            if (player.dead)
            {
                modPlayer.wolfPet = false;
            }
            if (modPlayer.wolfPet)
            {
                projectile.timeLeft = 2;
            }
        }
        public override void PostAI()
        {
            projectile.frameCounter++;
            if (projectile.frameCounter > 32)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame >= 16)
            {
                projectile.frame = 0;
            }
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
		{
			fallThrough = false;
			return true;
		}
		
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			return false;
		}
	}
}
