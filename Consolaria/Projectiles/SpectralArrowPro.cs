using Terraria;
using Terraria.ModLoader;

namespace Consolaria.Projectiles
{
    public class SpectralArrowPro : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 5;
            projectile.height = 5;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.penetrate = 2;
            projectile.tileCollide = true;
            projectile.ranged = true;
            projectile.glowMask = GlowMask.SpectralArrow;
        }
        public override void AI()
        {
            if (Main.rand.Next(2) == 0)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, ModContent.DustType<Dusts.SpectralFlame>(), projectile.velocity.X * 0.4f, projectile.velocity.Y * 0.4f);
            }
        }
        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 5; k++)
            {
                int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 1, projectile.oldVelocity.X * 0.1f, projectile.oldVelocity.Y * 0.1f);
            }
            Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 0);
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("SpectralFlame"), 240);
        }
    }
}
