using Terraria.ModLoader;

namespace Consolaria.Projectiles
{
    public class LilLepusStomp : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(683);
            aiType = 683;
            projectile.width = 70;
            projectile.height = 20;
            projectile.hostile = true;
            projectile.friendly = false;
            projectile.timeLeft = 400;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lepus Stomp");
        }
    }
}