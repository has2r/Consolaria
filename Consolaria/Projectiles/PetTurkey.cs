using Microsoft.Xna.Framework;
using Terraria;
using ReLogic.Localization.IME;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Consolaria.Projectiles
{
	public class PetTurkey : ModProjectile
	{
		public override void SetDefaults()
		{
            projectile.CloneDefaults(112);
            Main.projPet[projectile.type] = true;
            projectile.width = 40;
            projectile.height = 30;                       
            aiType = 112;
        }

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pet Turkey");
            DisplayName.AddTranslation(GameCulture.Spanish, "Pavo Mascota");
            Main.projFrames[projectile.type] = 2;
        }


        public override bool PreAI()
        {
            Main.player[projectile.owner].penguin = false;
            return true;
        }

        public override void AI()
		{
			Player player = Main.player[projectile.owner];
			CPlayer modPlayer = (CPlayer)player.GetModPlayer(mod, "CPlayer");
			if (player.dead)
			{
				modPlayer.turkeyPet = false;
			}
			if (modPlayer.turkeyPet)
			{
				projectile.timeLeft = 2;
			}
		}

        public override void PostAI()
        {
            projectile.frameCounter++;
            if (projectile.frameCounter > 8)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame >= 2)
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
