using ReLogic.Localization.IME;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Consolaria.Projectiles
{
	public abstract class Minion : ModProjectile
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Minion");
            DisplayName.AddTranslation(GameCulture.Spanish, "Minion");
        }
		
		public override void AI()
		{
			CheckActive();
		}
		public abstract void CheckActive();

	}
}