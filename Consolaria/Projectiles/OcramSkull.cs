using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using ReLogic.Localization.IME;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Consolaria.Projectiles
{
    public class OcramSkull : ModProjectile
    {      
         public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ocram Skull");
            DisplayName.AddTranslation(GameCulture.Spanish, "Cráneo de Ocram");
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.Skull);
            aiType = ProjectileID.Skull;
            projectile.hostile = true;
            projectile.friendly = false;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.scale = 1f;
            projectile.penetrate = 3;
            projectile.extraUpdates = 1;
            Main.projFrames[projectile.type] = 5;
            projectile.light = 0.2f;
            projectile.alpha = 0;
        }

        public override void AI()
        {
            for (int num104 = 0; num104 < 8; num104++)
            {
                int num105 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, ModContent.DustType<Dusts.SpectralFlame>(), projectile.velocity.X, projectile.velocity.Y, 0, default(Color), 2f);
                Main.dust[num105].noGravity = true;
                Main.dust[num105].velocity = projectile.Center - Main.dust[num105].position;
                Main.dust[num105].velocity.Normalize();
                Main.dust[num105].velocity *= -5f;
                Main.dust[num105].velocity += projectile.velocity / 2f;
            }

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

            Lighting.AddLight(projectile.Center, 0.5f, 0.4f, 0.9f);
        }

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(mod.BuffType("SpectralFlame"), 180);
        }

        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 5; k++)
            {
                int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, ModContent.DustType<Dusts.TizonaDust>(), projectile.oldVelocity.X * 0.1f, projectile.oldVelocity.Y * 0.1f);
            }
            Main.PlaySound(SoundID.NPCHit2, projectile.position);
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
    }
}