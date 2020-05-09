using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Consolaria.NPCs
{
	public class DragonSnatcher : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dragon Snatcher");
			Main.npcFrameCount[npc.type] = 3;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 80;
            npc.damage = 30;
			npc.defense = 10;
			npc.knockBackResist = 0f;
			npc.width = 34;
			npc.height = 34;
			animationType = NPCID.ManEater;
			npc.aiStyle = 13;
            aiType = NPCID.ManEater;
            npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
            npc.buffImmune[20] = true;
            npc.value = Item.buyPrice(0, 0, 0, 60);
            npc.behindTiles = true;
            banner = npc.type;
            bannerItem = mod.ItemType("DragonSnatcherBanner");
        }

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = npc.lifeMax * 1;
			npc.damage = npc.damage * 1;
		}

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                for (int j = 0; j < 1; j++)
                {
                    Vector2 position = npc.position + new Vector2(Main.rand.Next(npc.width - 8), Main.rand.Next(npc.height / 2));
                    Gore.NewGore(position, npc.velocity, 71, 1f);
                }
                for (int k = 0; k < 1; k++)
                {
                    Vector2 position2 = npc.position + new Vector2(Main.rand.Next(npc.width - 8), Main.rand.Next(npc.height / 2));
                    Gore.NewGore(position2, npc.velocity, 70, 1f);
                }
                return;
            }
            int num = 0;
            while (num < damage / npc.lifeMax * 50.0)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, DustID.GreenBlood, hitDirection, -1f, 0, default(Color), 1f);
                num++;
            }
        }

        public override void NPCLoot()
		{
            if (Main.netMode != 1)
            {
                int centerX = (int)(npc.position.X + npc.width / 2) / 16;
                int centerY = (int)(npc.position.Y + npc.height / 2) / 16;
                int halfLength = npc.width / 2 / 16 + 1;
                if (Main.rand.Next(10) == 1)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Cabbage"));
                }
            }
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.UndergroundJungle.Chance * 0.2f;
        }
    }
}