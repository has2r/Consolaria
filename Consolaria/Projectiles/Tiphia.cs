using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Consolaria.Projectiles
{
	public class Tiphia : ModProjectile
	{
		public override void SetDefaults()
		{
            projectile.CloneDefaults(198);
            aiType = 198;
            Main.projPet[projectile.type] = true;
            projectile.width = 42;
            projectile.height = 36;                 
        }

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tiphia");
            Main.projFrames[projectile.type] = 3;
        }

        public override bool PreAI()
        {
            Main.player[projectile.owner].hornet = false;
            return true;
        }

        public override void AI()
		{
			Player player = Main.player[projectile.owner];
			CPlayer modPlayer = (CPlayer)player.GetModPlayer(mod, "CPlayer");
			if (player.dead)
			{
				modPlayer.Tiphia = false;
			}
			if (modPlayer.Tiphia)
			{
				projectile.timeLeft = 2;
			}

            projectile.frameCounter++;
            if (projectile.frameCounter > 9)
            {
               // projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame >= 3)
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
