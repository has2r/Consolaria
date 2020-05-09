using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Consolaria.Projectiles
{
    public class TurkorBurningCharcoal : ModProjectile
    {
        int collides = 0;
        public override bool CloneNewInstances
        {
            get { return true; }
        }

        public override void SetDefaults()
        {
            projectile.aiStyle = 1;
            projectile.width = 32;
            projectile.height = 30;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.penetrate = -1;
            projectile.tileCollide = true;
            projectile.ranged = true;
            projectile.timeLeft = 600;
            projectile.ignoreWater = true;
            projectile.extraUpdates = 1;
            Main.projFrames[projectile.type] = 4;
            projectile.glowMask = GlowMask.TurkorBurningCharcoal;
        }


        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            for (int k = 0; k < projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                Color color = projectile.GetAlpha(lightColor) * ((projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
            }
            return true;
        }

        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            if (Main.rand.Next(2) == 0)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 6, projectile.velocity.X * 0.4f, projectile.velocity.Y * 0.4f, 0, default(Color), 1.1f);
            }
            projectile.frameCounter++;
            if (projectile.frameCounter > 4)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame >= 4)
            {
                projectile.frame = 0;
            }

            Lighting.AddLight(projectile.Center, 0.9f, 0.9f, 0.1f);
        }

        public override bool OnTileCollide(Vector2 velocityChange)
        {
            projectile.Kill();
            return true;
        }

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 60 * 3);
        }

        public override void Kill(int timeLeft)
        {
            NPC.NewNPC((int)projectile.Center.X, (int)projectile.Center.Y, mod.NPCType("TurkorBurningCharcoal"));
        }
    }
}