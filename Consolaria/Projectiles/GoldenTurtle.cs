using Microsoft.Xna.Framework;
using Terraria;
using ReLogic.Localization.IME;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Consolaria.Projectiles
{
	public class GoldenTurtle : ModProjectile
	{
		public override void SetDefaults()
		{
            projectile.CloneDefaults(324);
            aiType = 324;
            Main.projPet[projectile.type] = true;
            projectile.width = 46;
            projectile.height = 28;
        }

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Golden Turtle");
            DisplayName.AddTranslation(GameCulture.Spanish, "Tortuga Dorada");
            Main.projFrames[projectile.type] = 13;
        }

        public override bool PreAI()
        {
            Main.player[projectile.owner].penguin = false;
            return true;
        }

        public override void AI()
		{
			Player player = Main.player[projectile.owner];

            if (projectile.velocity.Y == 0)
            {
                projectile.velocity = projectile.velocity * 0.8f;
            }

			CPlayer modPlayer = (CPlayer)player.GetModPlayer(mod, "CPlayer");
			if (player.dead)
			{
				modPlayer.GTurtle = false;
			}
			if (modPlayer.GTurtle)
			{
				projectile.timeLeft = 2;
			}
		}

        public override void PostAI()
        {
            projectile.frameCounter++;
            if (projectile.frameCounter > 13)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame >= 13)
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
