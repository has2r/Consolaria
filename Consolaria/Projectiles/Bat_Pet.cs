using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Consolaria.Projectiles
{
	public class Bat_Pet : ModProjectile
	{
		public override void SetDefaults()
		{
            projectile.CloneDefaults(198);
            Main.projPet[projectile.type] = true;
            aiType = 198;
            projectile.width = 15;
            projectile.height = 10;
            projectile.damage = 4;
        }

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bat");
            Main.projFrames[projectile.type] = 5;
        }

        public override bool PreAI()
        {
            Main.player[projectile.owner].hornet = false;
            return true;
        }

        public override void AI()
		{
			Player player = Main.player[projectile.owner];

            if (Vector2.Distance(player.Center, projectile.Center) > 500f)
            {
                projectile.position.X = player.position.X;
                projectile.position.Y = player.position.Y;
            }

            CPlayer modPlayer = (CPlayer)player.GetModPlayer(mod, "CPlayer");
			if (player.dead)
			{
				modPlayer.Bat_Pet = false;
			}
			if (modPlayer.Bat_Pet)
			{
				projectile.timeLeft = 2;
			}
		}

        public override void PostAI()
        {
            projectile.frameCounter++;
            if (projectile.frameCounter > 15)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame >= 5)
            {
                projectile.frame = 0;
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Player player = Main.player[projectile.owner];
            player.HealEffect(1);
            player.statLife += 1;
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
