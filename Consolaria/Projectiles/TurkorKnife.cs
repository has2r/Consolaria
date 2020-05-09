using Terraria.ID;
using Terraria.ModLoader;

namespace Consolaria.Projectiles
{
    public class TurkorKnife : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Turkor Knife");
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