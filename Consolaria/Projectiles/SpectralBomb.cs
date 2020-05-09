using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Consolaria.Projectiles
{  
    public class SpectralBomb : ModProjectile
    {
        private int runerotation;

        public override void SetDefaults()
        {
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.width = 90;
            projectile.height = 90;
            projectile.aiStyle = 1;
            projectile.penetrate = 1;
            projectile.tileCollide = true;
            projectile.timeLeft = 8;
            projectile.damage = 40;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("SpectralFlame"), 300);
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = mod.GetTexture("Projectiles/SpectralRune");
            Vector2 origin = new Vector2(texture.Width * 0.5f, texture.Height * 0.5f);
            spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, new Rectangle?(), Color.White, runerotation / 2, origin, 1f, SpriteEffects.None, 0.0f);
            return true;
        }

        public override void Kill(int timeLeft)
        {
            Vector2 position = projectile.Center;
            Main.PlaySound(SoundID.Item14, (int)position.X, (int)position.Y);
            int radius = 9;
            for (int x = -radius; x <= radius; x++)
            {
                for (int y = -radius; y <= radius; y++)
                {
                    int xPosition = (int)(x + position.X / 16.0f);
                    int yPosition = (int)(y + position.Y / 16.0f);

                    if (Math.Sqrt(x * x + y * y) <= radius + 0.5)
                    {
                      int dust = Dust.NewDust(position, 20, 20, ModContent.DustType<Dusts.SpectralFlame>(), 0.0f, 0.0f, 0, new Color(), 2f);
                        Main.dust[dust].noGravity = true;
                    }
                }
            }
        }
    }
}
