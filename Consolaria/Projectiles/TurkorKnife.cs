using Terraria.ID;
using ReLogic.Localization.IME;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Consolaria.Projectiles
{
    public class TurkorKnife : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Turkor Knife");
            DisplayName.AddTranslation(GameCulture.Spanish, "Cuchilla de Turkor");
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.DeathSickle);
            aiType = ProjectileID.DeathSickle;
            projectile.width = 36;
            projectile.height = 44;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.penetrate = 1;
        }              
    }
}