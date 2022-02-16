using ReLogic.Localization.IME;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Consolaria.Projectiles
{
    public class LepusStomp : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(683);

            aiType = 683;
            projectile.width = 100;
            projectile.height = 20;
            projectile.hostile = true;
            projectile.friendly = false;
            projectile.timeLeft = 500;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lepus's Stomp");
            DisplayName.AddTranslation(GameCulture.Spanish, "Pisotón de Lepus");
        }
    }
}