using Terraria.ModLoader;

namespace Consolaria.Projectiles
{
	public abstract class Minion : ModProjectile
	{
		public override void AI()
		{
			CheckActive();
		}
		public abstract void CheckActive();

	}
}