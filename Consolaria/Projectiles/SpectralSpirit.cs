using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace Consolaria.Projectiles
{
    public class SpectralSpirit : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 5;
            projectile.height = 5;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 300;
            projectile.light = 1f;
            projectile.extraUpdates = 1;
            projectile.damage = 40;
        }
        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) - 1f;
            for (int index1 = 0; index1 < 3; ++index1)
            {
                float num1 = projectile.velocity.X / 3f * index1;
                float num2 = projectile.velocity.Y / 3f * index1;
                int index2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 59, 0.0f, 0.0f, 0, new Color(), 1f);
                Main.dust[index2].position.X = projectile.Center.X - num1;
                Main.dust[index2].position.Y = projectile.Center.Y - num2;
                Main.dust[index2].velocity *= 0.0f;
                Main.dust[index2].noGravity = true;
            }
            projectile.friendly = true;
            Player player = Main.player[projectile.owner];
            float num3 = projectile.Center.X;
            float num4 = projectile.Center.Y;
            float num5 = 500f;
            bool flag = false;
            for (int index = 0; index < 200; ++index)
            {
                if (Main.npc[index].CanBeChasedBy(projectile, false) && (double)projectile.Distance(Main.npc[index].Center) < num5 && Collision.CanHit(projectile.Center, 1, 1, Main.npc[index].Center, 1, 1))
                {
                    float num1 = Main.npc[index].position.X + (Main.npc[index].width / 2);
                    float num2 = Main.npc[index].position.Y + (Main.npc[index].height / 2);
                    float num6 = Math.Abs(projectile.position.X + (projectile.width / 2) - num1) + Math.Abs(projectile.position.Y + (projectile.height / 2) - num2);
                    if (num6 < num5)
                    {
                        num5 = num6;
                        num3 = num1;
                        num4 = num2;
                        flag = true;
                    }
                }
            }
            if (!flag)
                return;
            float num7 = 9f;
            Vector2 vector2 = new Vector2(projectile.position.X + projectile.width * 0.5f, projectile.position.Y + projectile.height * 0.5f);
            float num8 = num3 - vector2.X;
            float num9 = num4 - vector2.Y;
            float num10 = (float)Math.Sqrt(num8 * num8 + num9 * num9);
            float num11 = num7 / num10;
            float num12 = num8 * num11;
            float num13 = num9 * num11;
            projectile.velocity.X = (float)((projectile.velocity.X * 20.0 + num12) / 21.0);
            projectile.velocity.Y = (float)((projectile.velocity.Y * 20.0 + num13) / 21.0);
        }
        public override void Kill(int timeLeft)
        {
            for (int index1 = 11; index1 > 0; --index1)
            {
                int index2 = Dust.NewDust(projectile.position, 2, 2, 59, 0.0f, 0.0f, 100, new Color(), 2f);
                Main.dust[index2].noGravity = true;
                Vector2 velocity = projectile.velocity;
                Main.dust[index2].velocity = velocity.RotatedBy((15 * (index1 + 2)), new Vector2());
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("SpectralFlame"), 180);
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
    }
}
