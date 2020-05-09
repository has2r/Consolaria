using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Consolaria.Projectiles
{	
	public class Zombie : ModProjectile
	{		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Zombie");
			Main.projFrames[projectile.type] = 3;
		}
		
		public override void SetDefaults()
		{
			projectile.CloneDefaults(112);
			aiType = 112;          
            projectile.width = 34;
			projectile.height = 44;
            projectile.damage = 10;
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

            projectile.frameCounter++;
            if (projectile.frameCounter > 18)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame >= 3)
            {
                projectile.frame = 0;
            }

            if (projectile.localAI[0] >= 800f)
            {
                projectile.localAI[0] = 0f;
            }
            if (Vector2.Distance(player.Center, projectile.Center) > 500f)
            {
                projectile.position.X = player.position.X;
                projectile.position.Y = player.position.Y;
            }

            CPlayer modPlayer = (CPlayer)player.GetModPlayer(mod, "CPlayer");
            if (player.dead)
            {
                modPlayer.Zombie = false;
            }
            if (modPlayer.Zombie)
            {
                projectile.timeLeft = 2;
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
