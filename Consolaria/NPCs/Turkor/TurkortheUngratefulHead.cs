using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Consolaria.NPCs.Turkor
{
    public class TurkortheUngratefulHead : ModNPC
    {
        public override void SetDefaults()
        {
            npc.width = 60;
            npc.height = 60;
            npc.aiStyle = -1;
            animationType = -1;
            npc.damage = 25;
            npc.defense = 0;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.lifeMax = 1550;
            npc.HitSound = SoundID.NPCHit7;
            npc.DeathSound = SoundID.NPCDeath8;
            npc.knockBackResist = 0.0f;
            Main.npcFrameCount[npc.type] = 3;
            npc.buffImmune[BuffID.Poisoned] = true;
            npc.buffImmune[BuffID.Confused] = true;
            npc.buffImmune[BuffID.OnFire] = true;
        }

        public static Vector2 CenterPoint(Vector2 A, Vector2 B)
        {
            return new Vector2((A.X + B.X) / 2.0f, (A.Y + B.Y) / 2.0f);
        }

        public static float rotateBetween2Points(Vector2 A, Vector2 B)
        {
            return (float)Math.Atan2(A.Y - B.Y, A.X - B.X);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Turkor's Head");
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 2000;
            npc.damage = 40;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (Main.rand.Next(8) == 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Gore_Turkor_Feather"), 1f);
            }
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Gore_Turkor_Eye"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Gore_Turkor_Eye"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Gore_Turkor_Beak"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Gore_Turkor_Feather"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Gore_Turkor_Feather"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Gore_Turkor_Feather"), 1f);
            }
        }

        public override void FindFrame(int frameHeight)
        {
            if (npc.velocity.X > -3f && npc.velocity.X < 3f || npc.ai[1] >= 180 && npc.ai[1] <= 200)
            {
                npc.frame.Y = 130;
                npc.frameCounter += 0.0f;
            }
            else if (npc.velocity.X > -3f)
            {
                npc.spriteDirection = 1;
                npc.frameCounter += 0.1f;
                npc.frameCounter %= 2;
                int frame = (int)npc.frameCounter;
                npc.frame.Y = frame * frameHeight;
            }
            else if (npc.velocity.X < 3f)
            {
                npc.spriteDirection = -1;
                npc.frameCounter += 0.1f;
                npc.frameCounter %= 2;
                int frame = (int)npc.frameCounter;
                npc.frame.Y = frame * frameHeight;
            }
            if (dashTimer > 0)
            {
                npc.frame.Y = 0;
                npc.frameCounter = 0.0f;
            }
          
        }

        private Rectangle GetFrame(int number)
        {
            return new Rectangle(0, npc.frame.Height * (number - 1), npc.frame.Width, npc.frame.Height);
        }

        private int timer = 0;
        private float dashTimer = 0;
        int leader = ModContent.NPCType<TurkortheUngrateful>();

        public override void AI()
        {
           // Main.NewText(dash);
            Vector2 velocity1 = Vector2.Normalize(Main.npc[NPC.FindFirstNPC(leader)].Center - npc.Center) * 16;
            Vector2 vector32 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
            Projectile.NewProjectile(npc.Center.X - 4, npc.Center.Y + 14, velocity1.X, velocity1.Y, mod.ProjectileType("Neck"), (int)(npc.damage / 4), 0f, Main.myPlayer, 0f, npc.whoAmI);

            npc.TargetClosest(true);
            npc.netUpdate = true;
            Player player = Main.player[npc.target];
            if (!player.active || player.dead)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Gore_Turkor_Feather"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Gore_Turkor_Feather"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Gore_Turkor_Feather"), 1f);
                Main.PlaySound(SoundID.NPCDeath8, npc.position);
                npc.life = 0;
                npc.HitEffect(0, 10.0);
                npc.active = false;
                npc.netUpdate = true;
            }
            timer++;
            if (timer % 140 == 0)
            {
                for (int i = 0; i < 3; ++i)
                {
                    float speed = 8f;
                    Vector2 velocity = Vector2.Normalize(Main.player[npc.target].Center - npc.Center) * speed;
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y + 20, velocity.X, velocity.Y, mod.ProjectileType("TurkorFeather"), 13, 3, Main.myPlayer);
                }
            }

            Vector2 vector2_1 = Main.player[npc.target].Center + new Vector2(npc.Center.X, npc.Center.Y);
            Vector2 vector2_2 = npc.Center + new Vector2(npc.Center.X, npc.Center.Y);
            if (Main.expertMode)
            {
                npc.ai[1]++;
                if (npc.ai[1] >= 180 && npc.ai[1] < 200)
                {
                    npc.velocity = npc.velocity * 0;

                    if (npc.ai[1] == 190)
                    {
                        Main.PlaySound(SoundID.Item71, npc.position);
                        for (int i = 0; i < 1; ++i)
                        {
                            float shoot1 = (float)Math.Atan2(vector2_2.Y - (double)vector2_1.Y, vector2_2.X - (double)vector2_1.X);
                            Projectile.NewProjectile(npc.Center.X - 40, npc.Center.Y, (float)(Math.Cos(shoot1) * 4.0 * -1.0), (float)(Math.Sin(shoot1) * 7.0 * -1.0), mod.ProjectileType("TurkorKnife"), 20, 4f, Main.myPlayer);
                            Projectile.NewProjectile(npc.Center.X - 40, npc.Center.Y, -(float)(Math.Cos(shoot1) * -4.0 * 1.0), (float)(Math.Sin(shoot1) * 7.0 * -1.0), mod.ProjectileType("TurkorKnife"), 20, 4f, Main.myPlayer);
                        }
                    }
                }
                if (npc.ai[1] >= 200)
                {
                    npc.ai[1] = 0;
                }
            }
        
            if (timer % 200 == 0)
            {
                for (int i = 0; i < 3; ++i)
                {
                    float speed = 8f;
                    Vector2 velocity = Vector2.Normalize(Main.player[npc.target].Center - npc.Center) * speed;
                    Projectile.NewProjectile(npc.Center.X + 20, npc.Center.Y + 20, velocity.X, velocity.Y, mod.ProjectileType("TurkorFeather"), 20, 4, Main.myPlayer);
                }
            }
            if (Main.rand.Next(350) == 0)
            {
                dashTimer++;
                Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/turkor_attack"), npc.position);
                npc.velocity.X *= 0.98f;
                npc.velocity.Y *= 0.98f;
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height * 0.5f));
                {
                    float rotation = (float)Math.Atan2((vector8.Y) - (Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)), (vector8.X) - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)));
                    npc.velocity.X = (float)(Math.Cos(rotation) * 10) * -1;
                    npc.velocity.Y = (float)(Math.Sin(rotation) * 10) * -1;
                    npc.ai[1] = 2f;
                    return;
                }
            }
            //  Main.NewText(dashTimer);
            //   dashTimer = 0;
            if (dashTimer > 1.1f)
            {
                dashTimer = 0;
            }

            if (Main.player[npc.target].position.X < npc.position.X)
            {
                if (npc.velocity.X > -3) { npc.velocity.X -= 0.3f; }
            }
            else if (Main.player[npc.target].Center.X > npc.Center.X)
            {
                if (npc.velocity.X < 3) { npc.velocity.X += 0.3f; }
            }
            if (Main.player[npc.target].position.Y < npc.position.Y)
            {
                if (npc.velocity.Y > -3) npc.velocity.Y -= 0.3f;
            }
            else if (Main.player[npc.target].Center.Y > npc.Center.Y)
            {
                if (npc.velocity.Y < 3) npc.velocity.Y += 0.3f;
            }
            if (timer % 200 == 0)
            {
                switch (Main.rand.Next(2))
                {
                    case 0:
                        Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/turkor_doublegobble"), npc.position);
                        break;
                    case 1:
                        Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/turkor_gobble"), npc.position);
                        break;
                    default:
                        break;
                }
            }

            if (!Main.npc[(int)npc.ai[0]].active)
            {
                npc.active = false;
            }

            npc.netUpdate = true;
            npc.netAlways = true;

            if (Main.netMode == 2 && npc.whoAmI < 200)
            {
                NetMessage.SendData(23, -1, -1, null, npc.whoAmI, 0f, 0f, 0f, 0);
            }
        }
    }
}
