using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Consolaria.NPCs
{
    public class Orca : ModNPC
    {
        public override void SetDefaults()
        {
            npc.damage = 50;
            npc.lifeMax = 400;
            npc.defense = 20;
            npc.knockBackResist = 0.1f;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.width = 120;
            npc.height = 50;
            npc.scale = 1.1f;
            npc.noGravity = true;
            npc.value = Item.buyPrice(0, 1, 0, 0);
            npc.aiStyle = 16;
            aiType = NPCID.Shark;
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Shark];
            animationType = NPCID.Shark;
            npc.buffImmune[BuffID.Confused] = true;
            banner = npc.type;
            bannerItem = mod.ItemType("OrcaBanner");
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Orca");
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            Dust.NewDust(npc.position, npc.width, npc.height, 5, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
            if (npc.life <= 0)
            {
                for (int k = 0; k < 20; k++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, 5, 2.5f * hitDirection, -2.5f, 0, default(Color), 1f);
                }
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Gore_490"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Gore_491"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Gore_492"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Gore_493"), 1f);
            }
        }

        public override void NPCLoot()
        {
            if (Main.netMode != 1)
            {
                int centerX = (int)(npc.position.X + (npc.width / 2)) / 16;
                int centerY = (int)(npc.position.Y + (npc.height / 2)) / 16;
                int halfLength = npc.width / 2 / 16;

                if (Main.rand.Next(98) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DivingHelmet);
                };
                if (Main.rand.Next(25) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GoldenSeaweed"));
                };
            }
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            int x = spawnInfo.spawnTileX;
            int y = spawnInfo.spawnTileY;
            int tile = Main.tile[x, y].type;
            return (Consolaria.NormalSpawn(spawnInfo) && spawnInfo.water) && y < Main.rockLayer && (x < 250 || x > Main.maxTilesX - 250) && !spawnInfo.playerSafe ? 0.01f : 0f;
        }
    }
}
