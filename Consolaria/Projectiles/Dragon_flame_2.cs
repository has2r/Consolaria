using Microsoft.Xna.Framework;
using Terraria;
using ReLogic.Localization.IME;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Consolaria.Projectiles
{
    public class Dragon_flame_2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dragon Flame");
            DisplayName.AddTranslation(GameCulture.Spanish, "LLama de Dragón");
        }

        public override void SetDefaults()
        {
            projectile.width = 6;
            projectile.height = 12;
            projectile.timeLeft = 300;
            projectile.aiStyle = 14;
            projectile.friendly = true;
            projectile.penetrate = 2;
            projectile.melee = true;
            projectile.alpha = 100;
            projectile.light = 0.1f;
        }

        public override void AI()
        {
            Player player = Main.player[projectile.owner];

            int num199 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 92, 0f, 0f, 100, default(Color), 1f);
            Dust expr_8A12_cp_0 = Main.dust[num199];
            expr_8A12_cp_0.position.X = expr_8A12_cp_0.position.X - 2f;
            Dust expr_8A30_cp_0 = Main.dust[num199];
            expr_8A30_cp_0.position.Y = expr_8A30_cp_0.position.Y + 2f;
            Main.dust[num199].scale += Main.rand.Next(40) * 0.01f;
            Main.dust[num199].noGravity = true;
            Dust expr_8A83_cp_0 = Main.dust[num199];
            expr_8A83_cp_0.velocity.Y = expr_8A83_cp_0.velocity.Y - 2f;        
            if (projectile.velocity.Y < 0.25 && projectile.velocity.Y > 0.15)
            {
                projectile.velocity.X = projectile.velocity.X * 0.8f;
            }
            projectile.rotation = -projectile.velocity.X * 0.05f;

            if (player.ownedProjectileCounts[mod.ProjectileType("Dragon_flame_1")] > 3)
            {
                projectile.Kill();
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