using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Consolaria.Projectiles
{
    public class AlbinoMandible : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Albino Mandible");
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.IceBoomerang);
            projectile.aiStyle = 3;
            projectile.width = 30;
            projectile.height = 30;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.tileCollide = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 720;
        }
    }
}