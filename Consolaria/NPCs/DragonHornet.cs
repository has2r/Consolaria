using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Consolaria.NPCs
{	
	public class DragonHornet : ModNPC
	{	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dragon Hornet");
			Main.npcFrameCount[npc.type] = Main.npcFrameCount[42];
		}
		
		public override void SetDefaults()
		{
			npc.lifeMax = 75;
			npc.damage = 20;
			npc.defense = 20;
			npc.knockBackResist = 0.2f;
			npc.width = 42;
			npc.height = 40;
			npc.aiStyle = 14;
			npc.noGravity = true;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			banner = npc.type;
			bannerItem = 1661;
			npc.value = Item.buyPrice(0, 0, 4, 0);
			animationType = 42;
			npc.buffImmune[BuffID.Poisoned] = true;
		}
		
		public override void AI()
		{
			npc.TargetClosest(true);
			Player player = Main.player[npc.target];
			Vector2 vector = Main.player[npc.target].Center + new Vector2(npc.Center.X, npc.Center.Y);
			Vector2 vector2 = npc.Center + new Vector2(npc.Center.X, npc.Center.Y);
			npc.netUpdate = true;
			if (player.position.X > npc.position.X)
			{
				npc.spriteDirection = 1;
			}
			else
			{
				npc.spriteDirection = -1;
			}
			npc.ai[2] += 1f;
			if (npc.ai[2] >= 0f && Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height))
			{
				float num = (float)Math.Atan2((vector2.Y - vector.Y), (vector2.X - vector.X));
				Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 17, 1f, 0f);
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)(Math.Cos(num) * 10.0 * -1.0), (float)(Math.Sin(num) * 10.0 * -1.0), 55, 20, 1f);
				npc.ai[2] = -120f;
				npc.netUpdate = true;
			}
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
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Stinger, Main.rand.Next(1, 3));
            if (Main.rand.Next(20) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Beeswax"));
            };
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            int x = spawnInfo.spawnTileX;
            int y = spawnInfo.spawnTileY;
            int tile = Main.tile[x, y].type;
            return (Consolaria.NormalSpawn(spawnInfo) && Consolaria.NoZoneAllowWater(spawnInfo)) && spawnInfo.player.ZoneJungle && y > Main.rockLayer ? 0.03f : 0f;
        }
    }
}
