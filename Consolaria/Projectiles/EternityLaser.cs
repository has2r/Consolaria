using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Consolaria.Projectiles
{
	public class EternityLaser : ModProjectile
	{
        public override string Texture
        {
            get
            {
                return "Terraria/Projectile_83";
            }
        }

        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Eternity Laser");
		}

		public override void SetDefaults()
		{
            projectile.CloneDefaults(ProjectileID.EyeLaser);
            projectile.friendly = true;
            projectile.hostile = false;
			aiType = ProjectileID.EyeLaser;
            projectile.scale = 0.9f;
            projectile.penetrate = 1;
            projectile.minion = true;
		}

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(2) == 0)
            {
                target.AddBuff(mod.BuffType("SpectralFlame"), 60);
            }
        }        
    }
}