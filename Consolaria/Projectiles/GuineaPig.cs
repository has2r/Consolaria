using Microsoft.Xna.Framework;
using Terraria;
using ReLogic.Localization.IME;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Consolaria.Projectiles
{
	public class GuineaPig : ModProjectile
	{
		public override void SetDefaults()
		{
            projectile.CloneDefaults(111);
            aiType = 111;
            Main.projPet[projectile.type] = true;
            projectile.height = 36;
            projectile.width = 30;                    
        }

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Guinea Pig");
            DisplayName.AddTranslation(GameCulture.Spanish, "Conejillo de Indias");
            Main.projFrames[projectile.type] = 8;
        }

        public override bool PreAI()
        {
            Main.player[projectile.owner].bunny = false;
            return true;
        }

        public override void AI()
		{
			Player player = Main.player[projectile.owner];
			CPlayer modPlayer = (CPlayer)player.GetModPlayer(mod, "CPlayer");
			if (player.dead)
			{
				modPlayer.pigPet = false;
			}
			if (modPlayer.pigPet)
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
