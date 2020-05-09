using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Consolaria.NPCs
{
	public class VampireMiner : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Vampire Miner");
		}
		public override void SetDefaults()
		{
			npc.width = 40;
			npc.height = 40;
			npc.HitSound = SoundID.NPCHit13;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.damage = 30;
			npc.defense = 2;
			npc.lifeMax = 90;
			npc.value = Item.buyPrice(0, 0, 6, 0);
			npc.knockBackResist = 0.3f;
			npc.noGravity = false;
			npc.aiStyle = 3;
			npc.lavaImmune = false;
			Main.npcFrameCount[npc.type] = 15;
			aiType = 21;
			animationType = 21;
			banner = npc.type;
			bannerItem = mod.ItemType("VampireMinerBanner");
		}
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = npc.lifeMax;
			npc.damage = npc.damage;
		}
		public override void HitEffect(int hitDirection, double damage)
		{
			Dust.NewDust(npc.position, npc.width, npc.height, 1, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
			if (npc.life <= 0)
			{
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/vampgore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/vampgore2"), 1f);
				for (int i = 0; i < 20; i++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 1, 2.5f * hitDirection, -2.5f, 0, default(Color), 1f);
				}
			}
		}
		public override void AI()
		{
			Lighting.AddLight(npc.Center, new Vector3(0.8f, 0f, 0.8f));
		}
		public override void OnHitPlayer(Player player, int damage, bool crit)
		{
			if (npc.life < npc.lifeMax)
			{
				int HealLife = damage / 4;
				npc.life += HealLife;
			}
		}
		public override void NPCLoot()
		{
			if (Main.netMode != 1)
			{
				int centerX = (int)(npc.position.X + (npc.width / 2)) / 16;
				int centerY = (int)(npc.position.Y + (npc.height / 2)) / 16;
				int halfLength = npc.width / 2 / 16;

				if (Main.rand.Next(20) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Vial_of_Blood"));
				};
			}
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = (int)Main.tile[x, y].type;
			return (Consolaria.NoZoneAllowWater(spawnInfo)) && !spawnInfo.player.ZoneDungeon && !spawnInfo.player.ZoneJungle && y > Main.rockLayer ? 0.001f : 0f;
		}
	}
}
