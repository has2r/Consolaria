using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Consolaria.NPCs.Lepus
{
    [AutoloadBossHead]
    public class Lepus : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lepus");
            Main.npcFrameCount[npc.type] = 7;
        }

        private int timer = 0;
        private int jumpHeight;

        private int animatetimer = 0;

        public override void SetDefaults()
        {
            npc.width = 90;
            npc.height = 76;
            npc.lifeMax = 3800;
            npc.damage = 38;
            npc.defense = 8;
            npc.value = Item.buyPrice(0, 4, 0, 0);
            npc.knockBackResist = 0f;
            npc.boss = true;
            npc.aiStyle = -1;
            animationType = -1;
            npc.noTileCollide = false;
            npc.timeLeft = NPC.activeTime * 30;
            music = MusicID.UndergroundHallow;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            bossBag = mod.ItemType("LepusBag");
        }

        private Rectangle GetFrame(int number)
        {
            return new Rectangle(0, npc.frame.Height * (number - 1), npc.frame.Width, npc.frame.Height);
        }
        public override void FindFrame(int frameHeight)
        {
            npc.spriteDirection = npc.direction;
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 4750 + numPlayers * 500;
            npc.damage = 60;
            npc.defense = 10;
        }

        public override void BossLoot(ref string name, ref int potionType)
        {
            if (NPC.CountNPCS(mod.NPCType("Lepus")) == 1)
            {
                potionType = ItemID.LesserHealingPotion;
            }
            else
                potionType = 0;
        }
        public override void ModifyHitPlayer(Player target, ref int damage, ref bool crit)
        {
            target.AddBuff(32, 120);
        }

        public override void AI()
        {
            animatetimer++;
            npc.TargetClosest(true);
            npc.netUpdate = true;
            Player player = Main.player[npc.target];
            if (!player.active || player.dead)
            {
                npc.noTileCollide = true;
                npc.TargetClosest(false);
                npc.velocity.Y = -20;
                if (npc.timeLeft > 10)
                {
                    npc.timeLeft = 10;
                }
            }

            if (npc.velocity.Y < 0)
            {
                npc.frame = GetFrame(5);
            }
            if (npc.velocity.Y > 0)
            {
                npc.frame = GetFrame(6);
            }
            if (npc.velocity.Y == 0)
            {
                if (animatetimer % 10 == 0)
                {
                    npc.frame = GetFrame(Main.rand.Next(1, 3));
                }
            }

            jumpHeight = Main.rand.Next(2, 8);

            timer++;
            if (timer % 300 == 0)
            {
                animationType = -1;
                npc.frame = GetFrame(7);
                int Type = mod.NPCType("SmallEgg");
                switch (Main.rand.Next(5))
                {
                    case 0:
                        Type = mod.NPCType("SmallEgg");
                        break;
                    case 1:
                        Type = mod.NPCType("SmallEgg");
                        break;
                    case 2:
                        Type = mod.NPCType("SmallEgg");
                        break;
                    case 3:
                        Type = mod.NPCType("SmallEgg");
                        break;
                    case 4:
                        if (NPC.CountNPCS(mod.NPCType("Lepus")) <= 4)
                        {
                            Type = mod.NPCType("BigEgg");
                        }
                        break;

                    default:
                        break;
                }
                NPC.NewNPC((int)npc.position.X, (int)npc.position.Y + 35, Type);
            }
            if (timer >= 330)
            {
                animationType = 50;
                timer = 0;
            }
            if (npc.Center.X < Main.player[npc.target].Center.X - 2f)
            {
                npc.direction = 1;
            }
            if (npc.Center.X > Main.player[npc.target].Center.X + 2f)
            {
                npc.direction = -1;
            }
            npc.spriteDirection = npc.direction;
            int num;
            if (npc.ai[0] == 0f)
            {
                npc.noTileCollide = false;               
                if (npc.velocity.Y == 0f)
                {
                    npc.velocity.X = npc.velocity.X * 0.5f;
                    npc.ai[1] += 1f;
                    if (npc.ai[1] > 0f)
                    {
                        if (npc.life < npc.lifeMax)
                        {
                            npc.ai[1] += 0.25f;
                        }
                        if (npc.life < npc.lifeMax / 2)
                        {
                            npc.ai[1] += 0.5f;
                        }
                    }
                    if (npc.ai[1] >= 50f)
                    {
                        npc.ai[1] = -20f;
                    }
                    else if (npc.ai[1] == -1f)
                    {
                        npc.TargetClosest(true);
                        npc.velocity.X = npc.velocity.X + 2f * npc.direction;
                        npc.velocity.Y = -18 + jumpHeight;
                        npc.ai[0] = 1f;
                        npc.ai[1] = 0f;
                    }                                
                }
            }

            if (npc.ai[0] == 1f && npc.ai[0] <= 1f) //Ground Pound
            {
                if (npc.velocity.Y == 0f)
                {
                    if (Main.expertMode && Main.rand.Next(3) == 0)
                    {
                        Vector2 velocity = Vector2.Normalize(Main.player[npc.target].Center - npc.Center);
                        Projectile.NewProjectile(npc.position.X + 1, npc.position.Y, velocity.X, velocity.Y, mod.ProjectileType("LepusStomp"), 15, 0f, 0);
                        Projectile.NewProjectile(npc.position.X - 1, npc.position.Y, velocity.X, velocity.Y, mod.ProjectileType("LepusStomp"), 15, 0f, 0);
                        Main.PlaySound(SoundID.Item14, npc.position);

                        npc.ai[0] = 0f;
                        for (int num623 = (int)npc.position.X - 20; num623 < (int)npc.position.X + npc.width + 40; num623 += 20)
                        {
                            for (int num624 = 0; num624 < 4; num624 = num + 1)
                            {
                                int num625 = Dust.NewDust(new Vector2(npc.position.X - 20f, npc.position.Y + npc.height), npc.width + 20, 4, 31, 0f, 0f, 100, default(Color), 1.5f);
                                Dust dust3 = Main.dust[num625];
                                dust3.velocity *= 0.2f;
                                num = num624;
                            }
                            int num626 = Gore.NewGore(new Vector2((num623 - 20), npc.position.Y + npc.height - 8f), default(Vector2), Main.rand.Next(61, 64), 1f);
                            Gore gore = Main.gore[num626];
                            gore.velocity *= 0.4f;
                        }
                    }
                    if (!Main.expertMode && Main.rand.Next(4) == 0)
                    {
                        Vector2 velocity = Vector2.Normalize(Main.player[npc.target].Center - npc.Center);
                        Projectile.NewProjectile(npc.position.X + 1, npc.position.Y, velocity.X, velocity.Y, mod.ProjectileType("LilLepusStomp"), 15, 0f, 0);
                        Projectile.NewProjectile(npc.position.X - 1, npc.position.Y, velocity.X, velocity.Y, mod.ProjectileType("LilLepusStomp"), 15, 0f, 0);
                        Main.PlaySound(SoundID.Item14, npc.position);

                        npc.ai[0] = 0f;
                        for (int num623 = (int)npc.position.X - 20; num623 < (int)npc.position.X + npc.width + 40; num623 += 20)
                        {
                            for (int num624 = 0; num624 < 4; num624 = num + 1)
                            {
                                int num625 = Dust.NewDust(new Vector2(npc.position.X - 20f, npc.position.Y + npc.height), npc.width + 20, 4, 31, 0f, 0f, 100, default(Color), 1.5f);
                                Dust dust3 = Main.dust[num625];
                                dust3.velocity *= 0.2f;
                                num = num624;
                            }
                            int num626 = Gore.NewGore(new Vector2((num623 - 20), npc.position.Y + npc.height - 8f), default(Vector2), Main.rand.Next(61, 63), 1f);
                            Gore gore = Main.gore[num626];
                            gore.velocity *= 0.3f;
                        }
                    }
                    else
                        npc.ai[0] = 0f;
                }              
                else
                {
                    npc.TargetClosest(true);
                    if (npc.position.X < Main.player[npc.target].position.X && npc.position.X + (float)npc.width > Main.player[npc.target].position.X + (float)Main.player[npc.target].width)
                    {
                        npc.velocity.X = npc.velocity.X * 0.5f;
                        npc.velocity.Y = npc.velocity.Y + 0.5f;
                    }
                    else
                    {
                        if (npc.direction < 0)
                        {
                            npc.velocity.X = npc.velocity.X - 0.2f;
                        }
                        else if (npc.direction > 0)
                        {
                            npc.velocity.X = npc.velocity.X + 0.2f;
                        }
                        float num627 = 2f;
                        if (npc.life < npc.lifeMax)
                        {
                            num627 += 1f;
                        }
                        if (npc.velocity.X < -num627)
                        {
                            npc.velocity.X = -num627;
                        }
                        if (npc.velocity.X > num627)
                        {
                            npc.velocity.X = num627;
                        }
                    }
                }
            }
            int num628 = 3000;
            if (Math.Abs(npc.Center.X - Main.player[npc.target].Center.X) + Math.Abs(npc.Center.Y - Main.player[npc.target].Center.Y) > num628)
            {
                npc.TargetClosest(true);
                if (Math.Abs(npc.Center.X - Main.player[npc.target].Center.X) + Math.Abs(npc.Center.Y - Main.player[npc.target].Center.Y) > num628)
                {
                    npc.active = false;
                    return;
                }
            }
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/LPG1"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/LPG2"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/LPG3"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/LPG4"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/LPG5"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/LPG6"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/LPG7"), 1f);
            }
        }
        public override void NPCLoot()
        {
            if (NPC.CountNPCS(mod.NPCType("Lepus")) == 1)
            {
                if (Main.expertMode)
                {
                    if (!CWorld.downedLepus)
                    {
                        CWorld.downedLepus = true;
                        if (Main.netMode == NetmodeID.Server)
                        {
                            NetMessage.SendData(MessageID.WorldData);
                        }
                    }
                    npc.DropBossBags();
                    return;
                }
                if (!CWorld.downedLepus)
                {
                    CWorld.downedLepus = true;
                    if (Main.netMode == NetmodeID.Server)
                    {
                        NetMessage.SendData(MessageID.WorldData);
                    }
                }

                int drop = Main.rand.Next(3);
                if (drop == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("OstaraHat"));
                }
                if (drop == 1)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("OstaraChainmail"), 1);
                }
                if (drop == 2)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("OstaraBoots"), 1);
                }

                if (Main.rand.Next(2) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EggCannon"), 1);
                }
                if (Main.rand.Next(10) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BunnyHood, 1);
                }
                if (Main.rand.Next(10) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("LepusMask"), 1);
                }
                if (Main.rand.Next(10) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("LepusTrophy"), 1);
                }
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SuspiciousLookingEgg"), 1);
            }
        }
    }
}