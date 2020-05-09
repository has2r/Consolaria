using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using Consolaria.Projectiles;

namespace Consolaria.NPCs
{
    class ShadowSlime : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shadow Slime");
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.SpikedIceSlime];
        }

        public override void SetDefaults()
        {
            npc.lifeMax = 125;
            npc.defense = 20;
            npc.damage = 20;
            npc.width = 44;
            npc.height = 30;
            npc.npcSlots = 1f;
            npc.value = Item.buyPrice(0, 0, 90, 0);
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            animationType = 81;
            npc.aiStyle = 1;
            npc.alpha = 70;
            banner = npc.type;
            bannerItem = mod.ItemType("ShadowSlimeBanner");
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 150;
            npc.defense = 25;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            Dust.NewDust(npc.position, npc.width, npc.height, 109, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
            if (npc.life <= 0)
            {
                Vector2 vector = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                float num11 = Main.player[npc.target].position.X + Main.player[npc.target].width * 0.5f - vector.X;
                float num12 = Main.player[npc.target].position.Y - vector.Y;
                float num13 = (float)Math.Sqrt((num11 * num11 + num12 * num12));

                if (Main.netMode != 1 && npc.localAI[0] == 0f)
                {
                    for (int m = 0; m < 5; m++)
                    {
                        Vector2 vector2 = new Vector2((m - 2), -4f);
                        vector2.X *= 1f + Main.rand.Next(-50, 51) * 0.005f;
                        vector2.Y *= 1f + Main.rand.Next(-50, 51) * 0.005f;
                        vector2.Normalize();
                        vector2 *= 4f + Main.rand.Next(-50, 51) * 0.01f;
                        Projectile.NewProjectile(vector.X, vector.Y, vector2.X, vector2.Y, ModContent.ProjectileType<ShadowSlimeProj>(), 40, 0f, Main.myPlayer, 0f, 0f);
                        npc.localAI[0] = 30f;
                    }
                }

                Gore.NewGore(npc.position, npc.velocity / 2f, 99, 1f);
                Gore.NewGore(npc.position, npc.velocity / 2f, 99, 1f);
                Gore.NewGore(npc.position, npc.velocity / 2f, 99, 1f);
                for (int i = 0; i < 20; i++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, 109, 2.5f * hitDirection, -2.5f, 0, default(Color), 1f);
                }
            }
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            int x = spawnInfo.spawnTileX;
            int y = spawnInfo.spawnTileY;
            int tile = (int)Main.tile[x, y].type;
            return (Consolaria.NormalSpawn(spawnInfo) && spawnInfo.player.ZoneCorrupt && Main.hardMode && y > Main.rockLayer) ? 0.01f : 0f;
        }

        public override void NPCLoot()
        {
                     
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Gel, Main.rand.Next(6, 7));

            if (Main.rand.Next(100) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Blindfold, 1);
            };
            if (Main.rand.Next(3) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PetriDish"));
            };
        }
    }
}
