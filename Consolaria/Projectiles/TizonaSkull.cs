using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Consolaria.Projectiles
{
    public class TizonaSkull : ModProjectile
    {       
        public override void SetDefaults()
        {
            projectile.CloneDefaults(585);
            projectile.aiStyle = 1;
            aiType = 14;
            projectile.friendly = true;
            projectile.tileCollide = true;
            projectile.ignoreWater = false;
            projectile.scale = 1f;
            projectile.penetrate = 3;
            Main.projFrames[projectile.type] = 5;
            projectile.light = 0.1f;
        }

        public override void AI()
        {
            Player player = Main.player[projectile.owner];

           // projectile.rotation = 0f;
            projectile.velocity.Y += projectile.ai[0];
            var vector = projectile.velocity * 1.02f;
            projectile.velocity = vector;
            projectile.spriteDirection = player.direction;
            for (int num1 = 0; num1 < 8; num1++)
            {
                int num2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, ModContent.DustType<Dusts.SpectralFlame>(), projectile.velocity.X, projectile.velocity.Y, 0, default, 1.8f);
                Main.dust[num2].noGravity = true;
                Main.dust[num2].velocity = projectile.Center - Main.dust[num2].position;
                Main.dust[num2].velocity.Normalize();
                Main.dust[num2].velocity *= -5f;
                Main.dust[num2].velocity += projectile.velocity / 2f;
            }

            float num3 = projectile.Center.X;
            float num4 = projectile.Center.Y;
            float num5 = 600f;
            bool flag = false;
            for (int index = 0; index < 200; ++index)
            {
                if (Main.npc[index].CanBeChasedBy((object)projectile, false) && (double)projectile.Distance(Main.npc[index].Center) < (double)num5 && Collision.CanHit(projectile.Center, 1, 1, Main.npc[index].Center, 1, 1))
                {
                    float num1 = Main.npc[index].position.X + (float)(Main.npc[index].width / 2);
                    float num2 = Main.npc[index].position.Y + (float)(Main.npc[index].height / 2);
                    float num6 = System.Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num1) + System.Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num2);
                    if ((double)num6 < (double)num5)
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
            float num10 = (float)System.Math.Sqrt((double)num8 * (double)num8 + (double)num9 * (double)num9);
            float num11 = num7 / num10;
            float num12 = num8 * num11;
            float num13 = num9 * num11;
            projectile.velocity.X = (float)(((double)projectile.velocity.X * 20.0 + num12) / 21.0);
            projectile.velocity.Y = (float)(((double)projectile.velocity.Y * 20.0 + num13) / 21.0);         

            Lighting.AddLight(projectile.Center, 0.5f, 0.4f, 0.9f);
        }

        public override void PostAI()
        {
            projectile.frameCounter++;
            if (projectile.frameCounter > 5)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame >= 5)
            {
                projectile.frame = 0;
            }
        }

        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 5; k++)
            {
                int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, ModContent.DustType<Dusts.SpectralFlame>(), projectile.oldVelocity.X * 0.1f, projectile.oldVelocity.Y * 0.1f);
            }
           Main.PlaySound(SoundID.NPCHit2, projectile.position);
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
    }
}