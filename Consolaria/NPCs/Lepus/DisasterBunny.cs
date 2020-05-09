using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Consolaria.NPCs.Lepus
{
    public class DisasterBunny : ModNPC
    {
        public override void SetDefaults()
        {
            animationType = 47;
            npc.width = 35;
            npc.height = 28;
            npc.aiStyle = 3;
            aiType = 47;
            npc.damage = 20;
            npc.defense = 8;
            npc.lifeMax = 72;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0f;
            npc.noTileCollide = false;
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 80;
            npc.damage = 23;
            npc.defense = 9;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DBG1"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DBG2"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DBG3"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DBG4"), 1f);
            }
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Diseaster Bunny");
            Main.npcFrameCount[npc.type] = 7;
        }
        public override void NPCLoot()
        {
            if (!NPC.AnyNPCs(mod.NPCType("Lepus")))
            {
                if (Main.rand.Next(4) == 1)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SuspiciousLookingEgg"));
                }
            }
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            int x = spawnInfo.spawnTileX;
            int y = spawnInfo.spawnTileY;
            int tile = Main.tile[x, y].type;
            return (Consolaria.NormalSpawn(spawnInfo) && Consolaria.NoZoneAllowWater(spawnInfo)) && Main.dayTime && !CWorld.downedLepus &&  y < Main.worldSurface && !spawnInfo.sky ? 0.01f : 0;
        }
    }
}