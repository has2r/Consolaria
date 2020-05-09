using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Consolaria.Projectiles
{
    public class SpectralFlames : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spectral Flames");
        }

        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.ignoreWater = true;
            projectile.ranged = true;
            projectile.friendly = true;
            projectile.penetrate = 3;
            projectile.timeLeft = 60;
            projectile.tileCollide = true;
            projectile.extraUpdates = 2;
            projectile.ranged = true;
        }
        public override void AI()
        {
            if (projectile.timeLeft > 45)
                projectile.timeLeft = 45;
            if (projectile.ai[0] > 7.0)
            {
                float num = 1f;
                if (projectile.ai[0] == 8.0)
                    num = 0.25f;
                else if (projectile.ai[0] == 9.0)
                    num = 0.5f;
                else if (projectile.ai[0] == 10.0)
                    num = 0.75f;
                ++projectile.ai[0];
                int Type = 66;
                if (Main.rand.Next(1) == 0)
                {
                    for (int index1 = 0; index1 < 2; ++index1)
                    {
                        int num3 = 4;
                        int index2 = Dust.NewDust(new Vector2(projectile.position.X + (float)num3, projectile.position.Y + (float)num3), projectile.width - num3 * 3, projectile.height - num3 * 3, ModContent.DustType<Dusts.SpectralFlame>(), 0.0f, 0.0f, 100, new Color(), 1.2f);
                        if (Type == 66 && Main.rand.Next(3) == 0)
                        {
                            Main.dust[index2].noGravity = true;
                            Main.dust[index2].scale *= 2f;
                            Dust dust1 = Main.dust[index2];
                            dust1.velocity.X = dust1.velocity.X * 2f;
                            Dust dust2 = Main.dust[index2];
                            dust2.velocity.Y = dust2.velocity.Y * 2f;
                        }
                        else
                        {
                            Main.dust[index2].noGravity = true;
                            Main.dust[index2].scale *= 1;
                        }
                        Dust dust3 = Main.dust[index2];
                        dust3.velocity.X = dust3.velocity.X * 1.2f;
                        Dust dust4 = Main.dust[index2];
                        dust4.velocity.Y = dust4.velocity.Y * 1.2f;
                        Main.dust[index2].scale *= num;
                        if (Type == 66)
                            Main.dust[index2].velocity += projectile.velocity;
                    }
                }
            }
            else
                ++projectile.ai[0];
            projectile.rotation += 0.3f * projectile.direction;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("SpectralFlame"), 180);
        }
    }
}