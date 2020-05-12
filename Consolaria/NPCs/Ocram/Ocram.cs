using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Consolaria.NPCs.Ocram
{
    [AutoloadBossHead]
    public class Ocram : ModNPC
    {
        private float _laserRotation = MathHelper.PiOver2;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ocram");
            Main.npcFrameCount[npc.type] = 6;
        }
        public override void SetDefaults()
        {
            npc.aiStyle = -1;
            animationType = 126;
            npc.lifeMax = 35000;
            npc.damage = 65;
            npc.defense = 20;
            npc.knockBackResist = 0f;
            npc.width = 195;
            npc.height = 185;
            npc.value = Item.buyPrice(0, 10, 0, 0);
            npc.npcSlots = 1f;
            npc.boss = true;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.timeLeft = NPC.activeTime * 30;
            npc.HitSound = SoundID.NPCHit18;
            npc.DeathSound = SoundID.NPCDeath18;
            bossBag = mod.ItemType("OcramBag");
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/Ocram");
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 45000 + 1000 * numPlayers;
            npc.damage = 80;
            npc.defense = 25;
        }

        bool Phase2 = false;
        public const int MissileProjectiles = 5;
        public const float MissileAngleSpread = 150;

        public override void AI()
        {
            if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
            {
                npc.TargetClosest(true);
            }
            if (Main.expertMode)
            {
                if (npc.life < (int)(npc.lifeMax * 0.75))
                {
                    Phase2 = true;
                }
            }

            if (!Main.expertMode)
            {
                if (npc.life < (int)(npc.lifeMax / 2))
                {
                    Phase2 = true;
                }
            }

            bool dead2 = Main.player[npc.target].dead;
            float num317 = npc.position.X + (float)(npc.width / 2) - Main.player[npc.target].position.X - (float)(Main.player[npc.target].width / 2);
            float num318 = npc.position.Y + (float)npc.height - 59f - Main.player[npc.target].position.Y - (float)(Main.player[npc.target].height / 2);
            float num319 = (float)Math.Atan2((double)num318, (double)num317) + 1.57f;
            float num355 = npc.position.X + (float)(npc.width / 2) - Main.player[npc.target].position.X - (float)(Main.player[npc.target].width / 2);
            float num356 = npc.position.Y + (float)npc.height - 59f - Main.player[npc.target].position.Y - (float)(Main.player[npc.target].height / 2);
            float num357 = (float)Math.Atan2((double)num356, (double)num355) + 1.57f;

            if (num319 < 0f)
            {
                num319 += 6.2f;
            }
            else
            {
                if (num319 > 6.2f)
                {
                    num319 -= 6.2f;
                }
            }
            float num320 = 0.1f;
            if (npc.rotation < num319)
            {
                if ((double)(num319 - npc.rotation) > 3.1)
                {
                    npc.rotation -= num320;
                }
                else
                {
                    npc.rotation += num320;
                }
            }
            else
            {
                if (npc.rotation > num319)
                {
                    if ((double)(npc.rotation - num319) > 3.1)
                    {
                        npc.rotation += num320;
                    }
                    else
                    {
                        npc.rotation -= num320;
                    }
                }
            }
            if (npc.rotation > num319 - num320 && npc.rotation < num319 + num320)
            {
                npc.rotation = num319;
            }
            if (npc.rotation < 0f)
            {
                npc.rotation += 6.2f;
            }
            else
            {
                if (npc.rotation > 6.2)
                {
                    npc.rotation -= 6.2f;
                }
            }
            if (npc.rotation > num319 - num320 && npc.rotation < num319 + num320)
            {
                npc.rotation = num319;
            }
            if (Main.rand.Next(5) == 0)
            {
                int num321 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + (float)npc.height * 0.25f), npc.width, (int)((float)npc.height * 0.5f), 5, npc.velocity.X, 2f, 0, default(Color), 1f);
                Dust expr_146B6_cp_0 = Main.dust[num321];
                expr_146B6_cp_0.velocity.X = expr_146B6_cp_0.velocity.X * 0.5f;
                Dust expr_146D6_cp_0 = Main.dust[num321];
                expr_146D6_cp_0.velocity.Y = expr_146D6_cp_0.velocity.Y * 0.1f;
            }
            if (Main.netMode != 1 && !dead2 && npc.timeLeft < 10)
            {
                for (int num845 = 0; num845 < 200; num845++)
                {
                    if (num845 != npc.whoAmI && Main.npc[num845].active && Main.npc[num845].timeLeft - 1 > npc.timeLeft)
                    {
                        npc.timeLeft = Main.npc[num845].timeLeft - 1;
                    }
                }
            }
            if (dead2 || Main.dayTime)
            {
                npc.velocity.Y = npc.velocity.Y - 0.04f;
                if (npc.timeLeft > 10)
                {
                    npc.timeLeft = 10;
                    return;
                }
            }
            else
            {
                if (npc.ai[0] == 0f)
                {
                    if (npc.ai[1] == 0f)
                    {
                        float num322 = 12f;
                        float num323 = 0.1f;
                        int num324 = 1;
                        if (npc.position.X + (float)(npc.width / 2) < Main.player[npc.target].position.X + (float)Main.player[npc.target].width)
                        {
                            num324 = -1;
                        }
                        Vector2 vector36 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                        Vector2 vector32 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                        float num325 = Main.player[npc.target].position.X + (Main.player[npc.target].width / 2) - 300f - (num324 * 300) - vector32.X;
                        float num326 = Main.player[npc.target].position.Y + (Main.player[npc.target].height / 2) - 300f - vector32.Y;
                        float num327 = (float)Math.Sqrt((num325 * num325 + num326 * num326));
                        float num328 = num327;
                        num327 = num322 / num327;
                        num325 *= num327;
                        num326 *= num327;
                        if (npc.velocity.X < num325)
                        {
                            npc.velocity.X = npc.velocity.X + num323;
                            if (npc.velocity.X < 0f && num325 > 0f)
                            {
                                npc.velocity.X = npc.velocity.X + num323;
                            }
                        }
                        else
                        {
                            if (npc.velocity.X > num325)
                            {
                                npc.velocity.X = npc.velocity.X - num323;
                                if (npc.velocity.X > 0f && num325 < 0f)
                                {
                                    npc.velocity.X = npc.velocity.X - num323;
                                }
                            }
                        }
                        if (npc.velocity.Y < num326)
                        {
                            npc.velocity.Y = npc.velocity.Y + num323;
                            if (npc.velocity.Y < 0f && num326 > 0f)
                            {
                                npc.velocity.Y = npc.velocity.Y + num323;
                            }
                        }
                        else
                        {
                            if (npc.velocity.Y > num326)
                            {
                                npc.velocity.Y = npc.velocity.Y - num323;
                                if (npc.velocity.Y > 0f && num326 < 0f)
                                {
                                    npc.velocity.Y = npc.velocity.Y - num323;
                                }
                            }
                        }
                        npc.ai[2] += 1f;
                        if (npc.ai[2] >= 600f)
                        {
                            npc.ai[1] = 1f;
                            npc.ai[2] = 0f;
                            npc.ai[3] = 0f;
                            npc.target = 255;
                            npc.netUpdate = true;
                        }
                        else
                        {
                            if (Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height))
                            {
                                if (!Main.player[npc.target].dead)
                                {
                                    npc.ai[3] += 1f;
                                }
                                npc.ai[3]++;
                                if (npc.ai[3] >= 120 && npc.ai[3] <= 140)
                                {
                                    float Speed = 8f;
                                    Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                                    Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 33);
                                    float rotation = (float)Math.Atan2(vector8.Y - (Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)), vector8.X - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)));
                                    if (Main.expertMode)
                                    {
                                        Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), 100, 25, 0f, 0);
                                    }
                                    else
                                    {
                                        Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), 100, 35, 0f, 0);
                                    }
                                    if (npc.ai[3] % 70 == 0)
                                    {
                                        NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType("ServantofOcram"));
                                        if (npc.ai[3] >= 140)
                                        {
                                            npc.ai[3] = 0;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (npc.ai[1] == 1f)
                        {
                            npc.rotation = num319;
                            float num332 = 12f;
                            Vector2 vector33 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                            float num333 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector33.X;
                            float num334 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector33.Y;
                            float num335 = (float)Math.Sqrt((double)(num333 * num333 + num334 * num334));
                            num335 = num332 / num335;
                            npc.velocity.X = num333 * num335;
                            npc.velocity.Y = num334 * num335;
                            npc.ai[1] = 2f;
                        }
                        else
                        {
                            if (npc.ai[1] == 2f)
                            {
                                npc.ai[2] += 1f;
                                if (npc.ai[2] >= 25f)
                                {
                                    npc.velocity.X = npc.velocity.X * 0.96f;
                                    npc.velocity.Y = npc.velocity.Y * 0.96f;
                                    if ((double)npc.velocity.X > -0.0001 && (double)npc.velocity.X < 0.001)
                                    {
                                        npc.velocity.X = 0f;
                                    }
                                    if ((double)npc.velocity.Y > -0.0001 && (double)npc.velocity.Y < 0.001)
                                    {
                                        npc.velocity.Y = 0f;
                                    }
                                }
                                else
                                {
                                    npc.rotation = (float)Math.Atan2((double)npc.velocity.Y, (double)npc.velocity.X) - 1.57f;
                                }
                                if (npc.ai[2] >= 70f)
                                {
                                    npc.ai[3] += 1f;
                                    npc.ai[2] = 0f;
                                    npc.target = 255;
                                    npc.rotation = num319;
                                    if (npc.ai[3] >= 4f)
                                    {
                                        npc.ai[1] = 0f;
                                        npc.ai[3] = 0f;
                                    }
                                    else
                                    {
                                        npc.ai[1] = 1f;
                                    }
                                }
                            }
                        }
                    }
                    if (Phase2)
                    {
                        npc.ai[0] = 1f;
                        npc.ai[1] = 0f;
                        npc.ai[2] = 0f;
                        npc.ai[3] = 0f;
                        npc.netUpdate = true;
                        return;
                    }
                }
                else
                {
                    if (npc.ai[0] == 1f || npc.ai[0] == 2f)
                    {
                        if (npc.ai[0] == 1f)
                        {
                            npc.ai[2] += 0.005f;
                            if ((double)npc.ai[2] > 0.5)
                            {
                                npc.ai[2] = 0.5f;
                            }
                        }
                        else
                        {
                            npc.ai[2] -= 0.005f;
                            if (npc.ai[2] < 0f)
                            {
                                npc.ai[2] = 0f;
                            }
                        }
                        npc.rotation += npc.ai[2];
                        npc.ai[1] += 1f;
                        if (npc.ai[1] == 100f)
                        {
                            npc.ai[0] += 1f;
                            npc.ai[1] = 0f;
                            if (npc.ai[0] == 3f)
                            {
                                npc.ai[2] = 0f;
                            }
                            else
                            {
                                Main.PlaySound(3, (int)npc.position.X, (int)npc.position.Y, 1);
                                for (int num373 = 0; num373 < 2; num373++)
                                {
                                    Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), mod.GetGoreSlot("Gores/Gore_500"), 1f);
                                    Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), mod.GetGoreSlot("Gores/Gore_501"), 1f);
                                    Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), mod.GetGoreSlot("Gores/Gore_502"), 1f);
                                }
                                for (int num374 = 0; num374 < 20; num374++)
                                {
                                    Dust.NewDust(npc.position, npc.width, npc.height, 5, (float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f, 0, default(Color), 1f);
                                }
                                Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
                            }
                        }
                        Dust.NewDust(npc.position, npc.width, npc.height, 5, (float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f, 0, default(Color), 1f);
                        npc.velocity.X = npc.velocity.X * 0.98f;
                        npc.velocity.Y = npc.velocity.Y * 0.98f;
                        if ((double)npc.velocity.X > -0.1 && (double)npc.velocity.X < 0.1)
                        {
                            npc.velocity.X = 0f;
                        }
                        if ((double)npc.velocity.Y > -0.1 && (double)npc.velocity.Y < 0.1)
                        {
                            npc.velocity.Y = 0f;
                            return;
                        }
                    }
                    else
                    {
                        npc.damage = (int)(npc.defDamage * 1.01);
                        if (npc.ai[1] == 0f)
                        {
                            float num375 = 14f;
                            float num376 = 0.1f;
                            int num377 = 1;
                            if (npc.position.X + (float)(npc.width / 2) < Main.player[npc.target].position.X + (float)Main.player[npc.target].width)
                            {
                                num377 = -1;
                            }
                            Vector2 vector36 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                            Vector2 vector38 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                            float num378 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - (float)(num377 * 180) - vector38.X;
                            float num379 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - 300f - vector38.Y;
                            float num380 = (float)Math.Sqrt((double)(num378 * num378 + num379 * num379));
                            num380 = num375 / num380;
                            num378 *= num380;
                            num379 *= num380;
                            if (npc.velocity.X < num378)
                            {
                                npc.velocity.X = npc.velocity.X + num376;
                                if (npc.velocity.X < 0f && num378 > 0f)
                                {
                                    npc.velocity.X = npc.velocity.X + num376;
                                }
                            }
                            else
                            {
                                if (npc.velocity.X > num378)
                                {
                                    npc.velocity.X = npc.velocity.X - num376;
                                    if (npc.velocity.X > 0f && num378 < 0f)
                                    {
                                        npc.velocity.X = npc.velocity.X - num376;
                                    }
                                }
                            }
                            if (npc.velocity.Y < num379)
                            {
                                npc.velocity.Y = npc.velocity.Y + num376;
                                if (npc.velocity.Y < 0f && num379 > 0f)
                                {
                                    npc.velocity.Y = npc.velocity.Y + num376;
                                }
                            }
                            else
                            {
                                if (npc.velocity.Y > num379)
                                {
                                    npc.velocity.Y = npc.velocity.Y - num376;
                                    if (npc.velocity.Y > 0f && num379 < 0f)
                                    {
                                        npc.velocity.Y = npc.velocity.Y - num376;
                                    }
                                }
                            }
                            npc.ai[2] += 1f;
                            if (npc.ai[2] >= 200f)
                            {
                                npc.ai[1] = 1f;
                                npc.ai[2] = 0f;
                                npc.ai[3] = 0f;
                                npc.target = 255;
                                npc.netUpdate = true;
                            }
                            if (Main.netMode != 1)
                            {
                                npc.localAI[2] += 1f;
                                if (npc.localAI[2] > 8f)
                                {
                                    npc.localAI[2] = 0f;

                                }
                                if (Main.netMode != 1)
                                {
                                    npc.localAI[1] += 1f;
                                    if ((double)npc.life < (double)npc.lifeMax * 0.75)
                                    {
                                        npc.localAI[1] += 1f;
                                    }
                                    if ((double)npc.life < (double)npc.lifeMax * 0.5)
                                    {
                                        npc.localAI[1] += 1f;
                                    }
                                    if ((double)npc.life < (double)npc.lifeMax * 0.25)
                                    {
                                        npc.localAI[1] += 1f;
                                    }
                                    if ((double)npc.life < (double)npc.lifeMax * 0.1)
                                    {
                                        npc.localAI[1] += 2f;
                                    }
                                    if (npc.localAI[1] > 4f)
                                    {
                                        npc.localAI[1] = 0f;
                                        int num362 = 1;
                                        float num363 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - (float)(num362 * 150) - vector36.X;
                                        float num364 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector36.Y;
                                        float num365 = (float)Math.Sqrt((double)(num363 * num363 + num364 * num364));
                                        vector36 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                                        num363 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector36.X;
                                        num364 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2)- vector36.Y;
                                        float num366 = 12f;
                                        num365 = (float)Math.Sqrt((double)(num363 * num363 + num364 * num364));
                                        num365 = num366 / num365;
                                        num363 *= num365;
                                        num364 *= num365;
                                        num363 += (float)Main.rand.Next(-40, 41) * 0.05f;
                                        num364 += (float)Main.rand.Next(-40, 41) * 0.05f;
                                        vector36.X += num363 * 4f;
                                        vector36.Y += num364 * 4f;
                                        Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                                        Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 33);
                                        float rotation = (float)Math.Atan2(vector8.Y - (Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)), vector8.X - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)));
                                        if (Main.expertMode)
                                        {
                                            Projectile.NewProjectile(vector8.X, vector8.Y, num363, num364, 83, 20, 0f, 0);
                                        }
                                        else
                                        {
                                            Projectile.NewProjectile(vector8.X, vector8.Y, num363, num364, 83, 54, 0f, 0);
                                        }
                                    }
                                    return;
                                }
                            }
                        }
                        else
                        {
                            if (npc.ai[1] == 1f)
                            {
                                float Speed = 9f;
                                Vector2 velocity = Vector2.Normalize(Main.player[npc.target].Center - npc.Center) * Speed;
                                if (Main.expertMode)
                                {
                                    Projectile.NewProjectile(npc.position.X + 120, npc.position.Y + 50, velocity.X, velocity.Y, 44, 30, 0f, 0);
                                    Projectile.NewProjectile(npc.position.X + 160, npc.position.Y + 50, velocity.X, velocity.Y, 44, 30, 0f, 0);
                                    Projectile.NewProjectile(npc.position.X - 120, npc.position.Y - 50, velocity.X, velocity.Y, 44, 30, 0f, 0);
                                    Projectile.NewProjectile(npc.position.X - 160, npc.position.Y - 50, velocity.X, velocity.Y, 44, 30, 0f, 0);
                                    Projectile.NewProjectile(npc.position.X + 50, npc.position.Y + 120, velocity.X, velocity.Y, 44, 30, 0f, 0);
                                    Projectile.NewProjectile(npc.position.X + 50, npc.position.Y + 160, velocity.X, velocity.Y, 44, 30, 0f, 0);
                                    Projectile.NewProjectile(npc.position.X - 50, npc.position.Y - 120, velocity.X, velocity.Y, 44, 30, 0f, 0);
                                    Projectile.NewProjectile(npc.position.X - 50, npc.position.Y - 160, velocity.X, velocity.Y, 44, 30, 0f, 0);
                                }
                                else
                                {
                                    Projectile.NewProjectile(npc.position.X + 120, npc.position.Y + 50, velocity.X, velocity.Y, 44, 72, 0f, 0);
                                    Projectile.NewProjectile(npc.position.X + 160, npc.position.Y + 50, velocity.X, velocity.Y, 44, 72, 0f, 0);
                                    Projectile.NewProjectile(npc.position.X - 120, npc.position.Y - 50, velocity.X, velocity.Y, 44, 72, 0f, 0);
                                    Projectile.NewProjectile(npc.position.X - 160, npc.position.Y - 50, velocity.X, velocity.Y, 44, 72, 0f, 0);
                                    Projectile.NewProjectile(npc.position.X + 50, npc.position.Y + 120, velocity.X, velocity.Y, 44, 72, 0f, 0);
                                    Projectile.NewProjectile(npc.position.X + 50, npc.position.Y + 160, velocity.X, velocity.Y, 44, 72, 0f, 0);
                                    Projectile.NewProjectile(npc.position.X - 50, npc.position.Y - 120, velocity.X, velocity.Y, 44, 72, 0f, 0);
                                    Projectile.NewProjectile(npc.position.X - 50, npc.position.Y - 160, velocity.X, velocity.Y, 44, 72, 0f, 0);
                                }
                                Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
                                npc.rotation = num319;
                                float num384 = 18f;
                                Vector2 vector39 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                                float num385 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector39.X;
                                float num386 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector39.Y;
                                float num387 = (float)Math.Sqrt((double)(num385 * num385 + num386 * num386));
                                num387 = num384 / num387;
                                npc.velocity.X = num385 * num387;
                                npc.velocity.Y = num386 * num387;
                                npc.ai[1] = 2f;
                                return;
                            }
                            if (npc.ai[1] == 2f)
                            {
                                npc.ai[2] += 1f;
                                if (npc.ai[2] >= 50f)
                                {
                                    npc.velocity.X = npc.velocity.X * 0.93f;
                                    npc.velocity.Y = npc.velocity.Y * 0.93f;
                                    if ((double)npc.velocity.X > -0.1 && (double)npc.velocity.X < 0.1)
                                    {
                                        npc.velocity.X = 0f;
                                    }
                                    if ((double)npc.velocity.Y > -0.1 && (double)npc.velocity.Y < 0.1)
                                    {
                                        npc.velocity.Y = 0f;
                                    }
                                }
                                if (npc.ai[2] >= 80f)
                                {
                                    npc.ai[3] += 1f;
                                    npc.ai[2] = 0f;
                                    npc.target = 255;
                                    npc.rotation = num319;
                                    if (npc.ai[3] >= 6f)
                                    {
                                        npc.ai[1] = 0f;
                                        npc.ai[3] = 0f;
                                        return;
                                    }
                                    npc.ai[1] = 1f;
                                    return;
                                }
                            }
                        }
                    }
                }
            }
            if (Phase2 && Main.rand.Next(150) == 0)
            {
                Vector2 Vector3 = new Vector2(npc.position.X + npc.width * 0.1f, npc.position.Y + npc.height * 0.1f);
                float Num26 = Main.player[npc.target].position.X + (Main.player[npc.target].width / 2) - Vector3.X;
                float Num27 = Main.player[npc.target].position.Y + (Main.player[npc.target].height / 2) - 200f - Vector3.Y;
                if (Main.expertMode)
                {
                    if (Collision.CanHit(Vector3, 1, 1, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height))
                    {
                        if (Main.netMode != 1)
                        {
                            for (int playerIndex = 0; playerIndex < 255; playerIndex++)
                            {
                                if (Main.player[playerIndex].active)
                                {
                                    for (int i = 0; i < MissileProjectiles; i++)
                                    {
                                        Main.PlaySound(4, (int)npc.position.X, (int)npc.position.Y, 45, 0.8f, 0f);
                                        int Num32;
                                        Player player = Main.player[playerIndex];
                                        int Speed = 10;
                                        float SpawnX = Main.rand.Next(1000) - 500 + player.Center.X;
                                        float SpawnY = -1400 + player.Center.Y;
                                        Vector2 BaseSpawn = new Vector2(SpawnX, SpawnY);
                                        Vector2 BaseVelocity = player.Center - BaseSpawn;
                                        BaseVelocity.Normalize();
                                        BaseVelocity = BaseVelocity * Speed / 2;
                                        Vector2 Spawn = BaseSpawn;
                                        Spawn.X = Spawn.X + i * 30 - (MissileProjectiles * 15);
                                        Vector2 Velocity = BaseVelocity;
                                        Velocity = BaseVelocity.RotatedBy(MathHelper.ToRadians(-MissileAngleSpread / 4 + (MissileAngleSpread * i / MissileProjectiles)));
                                        Velocity.X = Velocity.X + 2 * Main.rand.NextFloat() - 1.3f;
                                        if (Main.expertMode)
                                        {
                                            if (Main.rand.Next(2) == 0)
                                            {
                                                Num32 = Projectile.NewProjectile(Spawn.X, Spawn.Y, Velocity.X, Velocity.Y, mod.ProjectileType("OcramSkull"), 32, 1f, Main.myPlayer, 0f, 0f); ;
                                            }
                                            int Num33 = Projectile.NewProjectile(Spawn.X, Spawn.Y, Velocity.X, Velocity.Y, mod.ProjectileType("OcramSkull"), 32, 1f, Main.myPlayer, 0f, 0f);
                                            Main.projectile[Num33].velocity.X = Main.rand.Next(-200, 201) * 0.1f;
                                            Main.npc[Num33].velocity.Y = Main.rand.Next(-200, 201) * 0.02f;
                                            Main.npc[Num33].netUpdate = true;
                                        }
                                        else
                                        {
                                            if (Main.rand.Next(2) == 0)
                                            {
                                                Num32 = Projectile.NewProjectile(Spawn.X, Spawn.Y, Velocity.X, Velocity.Y, mod.ProjectileType("OcramSkull"), 28, 1f, Main.myPlayer, 0f, 0f); ;
                                            }
                                            int Num33 = Projectile.NewProjectile(Spawn.X, Spawn.Y, Velocity.X, Velocity.Y, mod.ProjectileType("OcramSkull"), 28, 1f, Main.myPlayer, 0f, 0f);
                                            Main.projectile[Num33].velocity.X = Main.rand.Next(-200, 201) * 0.1f;
                                            Main.npc[Num33].velocity.Y = Main.rand.Next(-200, 201) * 0.02f;
                                            Main.npc[Num33].netUpdate = true;
                                        }                                      
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int k = 0; k < damage / npc.lifeMax * 100.0; k++)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, DustID.Blood, hitDirection, -1f, 0, default(Color), 1f);
            }
            if (npc.life <= 0)
            {
                Main.PlaySound(SoundID.Item14, npc.Center);
                for (int k = 0; k < 20; k++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
                }
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/OcramGore1"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/OcramGore1"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/OcramGore1"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/OcramGore2"), 1.2f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/OcramGore2"), 1.2f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/OcramGore3"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/OcramGore3"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/OcramGore1"), 1f);
            }
        }
        public override void NPCLoot()
        {
            if (!CWorld.downedOcram)
            {
                CWorld.downedOcram = true;
                if (Main.netMode == NetmodeID.Server)
                {
                    NetMessage.SendData(MessageID.WorldData);
                }
            }

            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SoulofBlight"), Main.rand.Next(10, 30));
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SpectralArrow"), Main.rand.Next(5, 15));

            if (Main.rand.Next(10) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("OcramTrophy"));
            }

            if (Main.rand.Next(10) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("OcramMask"), 1);
            }

            if (Main.expertMode)
            {
                if (!CWorld.downedOcram)
                {
                    CWorld.downedOcram = true;
                    if (Main.netMode == NetmodeID.Server)
                    {
                        NetMessage.SendData(MessageID.WorldData);
                    }
                }
                npc.DropBossBags();
                return;
            }

            int drop = Main.rand.Next(3);
            if (drop == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EternityStaff"));
            }
            if (drop == 1)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DragonBreath"), 1);
            }
            if (drop == 2)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EoO"), 1);
            }

            if (Main.rand.Next(2) == 0)
            {
                int drop2 = Main.rand.Next(12);
                if (drop2 == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AncientDragonMask"));
                }
                if (drop2 == 1)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AncientDragonBreastplate"));
                }
                if (drop2 == 2)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AncientDragonGreaves"));
                }
                if (drop2 == 3)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AncientSpectralHeadgear"), 1);
                }
                if (drop2 == 4)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AncientSpectralArmor"), 1);
                }
                if (drop2 == 5)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AncientSpectralSubligar"), 1);
                }
                if (drop2 == 6)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AncientTitanHelmet"), 1);
                }
                if (drop2 == 7)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AncientTitanMail"), 1);
                }
                if (drop2 == 8)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AncientTitanLeggings"), 1);
                }
                if (drop2 == 9)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AncientWarlockHood"), 1);
                }
                if (drop2 == 10)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AncientWarlockRobe"), 1);
                }
                if (drop2 == 11)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AncientWarlockLeggings"), 1);
                }
            }
        }
        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.GreaterHealingPotion;
        }
    }
}