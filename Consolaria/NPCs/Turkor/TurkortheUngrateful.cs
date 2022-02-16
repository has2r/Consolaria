using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using ReLogic.Localization.IME;
using Terraria.Localization;
using Microsoft.Xna.Framework;

namespace Consolaria.NPCs.Turkor
{
    [AutoloadBossHead]
    public class TurkortheUngrateful : ModNPC
    {
        private int timer = 0;

        public override void SetDefaults()
        {
            npc.width = 200;
            npc.height = 50;
            npc.aiStyle = -1;
            npc.boss = true;
            Main.npcFrameCount[npc.type] = 3;
            npc.damage = 15;
            npc.defense = 0;
            npc.lifeMax = 7000;
            npc.value = Item.buyPrice(0, 5, 0, 0);
            music = MusicID.Boss1;
            npc.HitSound = SoundID.NPCHit7;
            npc.DeathSound = SoundID.NPCDeath8;
            npc.knockBackResist = 0f;
            npc.noTileCollide = false;
            bossBag = mod.ItemType("TurkorBag");
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Turkor the Ungrateful");
            DisplayName.AddTranslation(GameCulture.Spanish, "Turkor el Desagradecido");
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 7500 + numPlayers * 1000;
            npc.damage = 45;
            npc.defense = 5;
        }  
        public override void HitEffect(int hitDirection, double damage)
        {
            if (Main.rand.Next(8) == 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Gore_Turkor_Feather"), 1f);
            }
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Gore_Turkor_Feather"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Gore_Turkor_Feather"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Gore_Turkor_Meat"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Gore_Turkor_Meat"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Gore_Turkor_Feather"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Gore_Turkor_Feather"), 1f);
            }
        }

        public bool headSpawned2 = false;
        public bool headSpawned = false;
        public bool TwoHeadSpawned = false;
        public bool neckGore = false;
        public float TimerAI = 0;
        bool charcoalAttack = false;

        public override void AI()
        {
            CGlobalNPC.turkeyBoss = npc.whoAmI;

            if (npc.life <= npc.lifeMax * 0.75f)
            {
                charcoalAttack = true;
            }
            else
            {
                charcoalAttack = false;
            }
                
            npc.TargetClosest(true);
            npc.netUpdate = true;
            Player player = Main.player[npc.target];
            if (Main.rand.Next(90) == 0)
            {
                int num220 = 9;
                for (int num221 = 0; num221 < num220; num221++)
                {
                    Vector2 value17 = new Vector2(Main.rand.Next(-25, 25), Main.rand.Next(-100, 101));
                    value17.Normalize();
                    value17 *= Main.rand.Next(200, 500) * 0.01f;
                    int k = Projectile.NewProjectile(npc.position.X, npc.position.Y, value17.X, value17.Y, 326, 39 / 3, 3, Main.myPlayer);
                }
            }

            if (npc.life <= npc.lifeMax * 0.25f)
            {
                charcoalAttack = false;
                if (Main.rand.Next(100) == 0)
                {
                    Main.PlaySound(SoundID.Item69, npc.position);
                    for (int il = 0; il < 1; ++il)
                    {
                        Vector2 vector2 = Main.player[npc.target].Center - npc.Center;
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 50, vector2.X * 0.01f, vector2.Y * 0.01f, mod.ProjectileType("TurkorBurningCharcoal"), 25, 5f);
                    }
                }
            }

            if (!player.active || player.dead)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Gore_Turkor_Feather"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Gore_Turkor_Feather"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Gore_Turkor_Feather"), 1f);
                Main.PlaySound(SoundID.NPCDeath8, npc.position);
                npc.life = 0;
                npc.HitEffect(0, 10.0);
                npc.netUpdate = true;
            }

            bool flag100 = false;
            int num568 = 0;
            if (Main.netMode != 1)
            {
                for (int num569 = 0; num569 < 200; num569++)
                {
                    if ((Main.npc[num569].active && Main.npc[num569].type == (mod.NPCType("TurkortheUngratefulHead"))))
                    {
                        flag100 = true;
                        num568++;
                    }
                }
                npc.defense += num568 * 25;
            }
            if (!flag100)
            {
                npc.defense = 0;
            }
            npc.netUpdate = true;
            npc.netAlways = true;
            if (Main.netMode < 1) TimerAI += 1;
            if (Main.netMode == 1) TimerAI += 0.75f;

            if (!headSpawned && Main.netMode != 1)
            {
                npc.ai[1] = NPC.NewNPC((int)npc.position.X + (npc.width / 2), (int)npc.position.Y + (npc.height / 2), mod.GetNPC("TurkortheUngratefulHead").npc.type, npc.whoAmI);
                Main.npc[(int)npc.ai[1]].ai[0] = npc.whoAmI;
                headSpawned = true;
                if (Main.netMode == 2 && (int)npc.ai[1] < 200)
                {
                    NetMessage.SendData(23, -1, -1, null, (int)npc.ai[1], 0f, 0f, 0f, 0);
                }
                npc.netUpdate = true;
            }
       
            if (!Main.npc[(int)npc.ai[1]].active && (npc.ai[2] == 0 || (npc.ai[2] == 1 && !neckGore)))
            {
                TimerAI = 0;
                if (Main.netMode != 2) Gore.NewGore(Main.npc[(int)npc.ai[1]].Center, new Vector2(Main.rand.Next(-30, 31) * 0.2f, Main.rand.Next(-30, 31) * 0.2f), mod.GetGoreSlot("Gores/RidleyGore4"), 1f);
                for (int num36 = 0; num36 < 3; num36++)
                {
                    Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/NPC_Turkor_Neck_Piece"), 1f);
                }
                for (int num36 = 0; num36 < 3; num36++)
                {
                    Gore.NewGore((npc.Center + Main.npc[(int)npc.ai[1]].Center) / 2f, (npc.velocity + Main.npc[(int)npc.ai[1]].velocity) / 2f, mod.GetGoreSlot("Gores/NPC_Turkor_Neck_Piece"), 1f);
                }
                for (int num36 = 0; num36 < 3; num36++)
                {
                    Gore.NewGore(Main.npc[(int)npc.ai[1]].Center, Main.npc[(int)npc.ai[1]].velocity, mod.GetGoreSlot("Gores/NPC_Turkor_Neck_Piece"), 1f);
                }
                npc.ai[2] = 1;
                neckGore = true;
            }
            if (NPC.AnyNPCs(mod.NPCType("TurkortheUngratefulHead"))) 
            {
                animationType = -1;
            }
            if (!NPC.AnyNPCs(mod.NPCType("TurkortheUngratefulHead"))) 
            {
                if (charcoalAttack && timer % 180 == 0)
                {
                    Main.PlaySound(SoundID.Item69, npc.position);
                    for (int i = 0; i < 1; ++i)
                    {
                        Vector2 vector2 = Main.player[npc.target].Center - npc.Center;
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 50, vector2.X * 0.01f, vector2.Y * 0.01f, mod.ProjectileType("TurkorBurningCharcoal"), 30, 6f);
                    }
                }

                animationType = 4;
                timer++;
                if (timer % 5 == 0) 
                {
                    for (int m = 0; m < 10; m++)
                    {
                        int dustID = Dust.NewDust(npc.position, npc.width, npc.height, 12, 0, 0, 100, default(Color), 2f);
                        Main.dust[dustID].scale = 2f;
                        Main.dust[dustID].velocity *= 2.5f;
                        Main.dust[dustID].noGravity = false;
                    }
                    if (timer % 540 == 0) 
                    {
                        Main.PlaySound(29, (int)npc.position.X, (int)npc.position.Y, 9);
                        npc.netUpdate = true;
                        if (!TwoHeadSpawned)
                        {
                            npc.ai[1] = NPC.NewNPC((int)npc.position.X - 15, (int)npc.position.Y, mod.NPCType("TurkortheUngratefulHead"));
                            Main.npc[(int)npc.ai[1]].ai[0] = npc.whoAmI;
                            npc.ai[1] = NPC.NewNPC((int)npc.position.X + 15, (int)npc.position.Y, mod.NPCType("TurkortheUngratefulHead"));
                            Main.npc[(int)npc.ai[1]].ai[0] = npc.whoAmI;
                            TwoHeadSpawned = true;
                        }
                        else
                        {
                            if (TwoHeadSpawned) 
                            {
                                npc.ai[1] = NPC.NewNPC((int)npc.position.X - 15, (int)npc.position.Y, mod.NPCType("TurkortheUngratefulHead"));
                                Main.npc[(int)npc.ai[1]].ai[0] = npc.whoAmI;
                                npc.ai[1] = NPC.NewNPC((int)npc.position.X - 25, (int)npc.position.Y, mod.NPCType("TurkortheUngratefulHead"));
                                Main.npc[(int)npc.ai[1]].ai[0] = npc.whoAmI;
                                npc.ai[1] = NPC.NewNPC((int)npc.position.X + 15, (int)npc.position.Y, mod.NPCType("TurkortheUngratefulHead"));
                                Main.npc[(int)npc.ai[1]].ai[0] = npc.whoAmI;
                            }
                        }
                    }
                }
            }
        }
        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.LesserHealingPotion;
        }
        public override void NPCLoot()
        {
            if (!CWorld.downedTurkor)
            {
                CWorld.downedTurkor = true;
                if (Main.netMode == NetmodeID.Server)
                {
                    NetMessage.SendData(MessageID.WorldData);
                }
            }
            if (Main.expertMode)
            {                
                npc.DropBossBags();
                return;
            }
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Feather, Main.rand.Next(5, 10));

            int drop = Main.rand.Next(4);
            if (drop == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SpicySauce"), Main.rand.Next(30, 50));
            }
            if (drop == 1)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GreatDrumstick"));
            }
            if (drop == 2)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FeatherStorm"));
            }
            if (drop == 3)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TurkeyStuff"));
            }

            if (Main.rand.Next(10) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TurkorMask"), 1);
            }
            if (Main.rand.Next(10) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TurkorTrophy"), 1);
            }
        }
    }
}