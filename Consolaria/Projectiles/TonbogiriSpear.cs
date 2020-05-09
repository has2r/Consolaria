using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Consolaria.Projectiles
{
    public class TonbogiriSpear : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 90;
            projectile.height = 90;
            projectile.CloneDefaults(218);
            aiType = 66;
            projectile.scale = 1.1f;
        }

        public override void AI()
        {
            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<Dusts.TizonaDust>(), projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 136, default(Color), 1.2f);
            Main.dust[dust].noGravity = true;
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(2) == 0)
            {
                target.AddBuff(mod.BuffType("SpectralFlame"), 300);
            }
        }
    }
}