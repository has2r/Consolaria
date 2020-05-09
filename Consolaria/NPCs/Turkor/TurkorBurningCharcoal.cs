using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Consolaria.NPCs.Turkor
{
    class TurkorBurningCharcoal : ModNPC
    {
        int collides = 0;
        int killTimer;
        public override bool CloneNewInstances
        {
            get { return true; }
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Turkor Burning Charcoal");
            Main.npcFrameCount[npc.type] = 4;
        }

        public override void SetDefaults()
        {
            npc.lifeMax = 10;
            npc.defense = 3;
            npc.width = 32;
            npc.height = 30;
            npc.npcSlots = 0.1f;
            npc.DeathSound = SoundID.NPCDeath3;
            animationType = 48;
            npc.noTileCollide = false;
            npc.noGravity = false;
            npc.aiStyle = 9;
            npc.knockBackResist = 0f;
            npc.alpha = 50;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 3; i++)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, 6, hitDirection, -1f, 0, default(Color), 1f);
            }
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Charcoal_Gore"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Charcoal_Gore"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Charcoal_Gore"), 1f);
                Main.PlaySound(SoundID.Item88, npc.position);
                for (int j = 0; j < 12; j++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, 6, hitDirection, -1f, 0, default(Color), 1f);
                }            
            }
        }

        public override void AI()
        {
            Lighting.AddLight(npc.Center, 0.9f, 0.9f, 0.1f);
            if (Main.rand.Next(2) == 0)
            {
                Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, 6, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 0, default(Color), 1.1f);
            }
            if (npc.collideX)
            {
                npc.velocity.X *=-2.5f;
            }
            if (npc.collideY)
            {
                npc.velocity.Y *= -4f;
            }
            if(npc.collideX || npc.collideY)
            {
                collides++;
            }
            if (collides > 1)
            {
                for (int i = 0; i < 2; ++i)
                {
                    Vector2 vector2 = Main.player[npc.target].Center - npc.Center;
                    int RandX = Main.rand.Next(-1, 2);
                    Main.projectile[Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vector2.X * 0.01f + RandX, vector2.Y * 0.01f, mod.ProjectileType("TurkorFire"), 10, 2, 255, 0f, 0f)].hostile = true;
                }
                killTimer++;
            }
            if(killTimer > 2)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Charcoal_Gore"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Charcoal_Gore"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Charcoal_Gore"), 1f);
                Main.PlaySound(SoundID.Item88, npc.position);
                npc.life = 0;
            }
        }

        public override void OnHitPlayer(Player player, int damage, bool crit)
        {
            if (Main.expertMode)
            {
                player.AddBuff(BuffID.OnFire, 300, true);
            }
            else
            {
                player.AddBuff(BuffID.OnFire, 180, true);
            }
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            var GlowMask = mod.GetTexture("Glow/TurkorBurningCharcoal_Glow");
            var Effects = npc.direction == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            spriteBatch.Draw(GlowMask, npc.Center - Main.screenPosition + new Vector2(0, npc.gfxOffY), npc.frame, Color.White, npc.rotation, npc.frame.Size() / 2, npc.scale, Effects, 0);
        }
    }
}
