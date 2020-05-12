using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Consolaria.NPCs
{	
	public class SpectralGastropod : ModNPC
	{
		public override void SetDefaults()
		{
			npc.width = 40;
			npc.height = 40;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.damage = 45;
			npc.defense = 5;
			npc.lifeMax = 250;
			npc.value = Item.buyPrice(0, 0, 8, 0);
			npc.knockBackResist = 0.3f;
			npc.noGravity = true;
			npc.aiStyle = 22;
			npc.lavaImmune = true;
			npc.buffImmune[20] = true;
			npc.buffImmune[mod.BuffType("SpectralFlame")] = true;
			Main.npcFrameCount[npc.type] = 11;
			aiType = -1;
			animationType = 122;
			banner = npc.type;
			bannerItem = mod.ItemType("SpectralGastropodBanner");
		}
	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spectral Gastropod");
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = npc.lifeMax;
			npc.damage = npc.damage;
		}

		public override void AI()
		{
			Player player = Main.player[Main.myPlayer];
			if (npc.justHit)
			{
				npc.ai[3] = 0f;
				npc.localAI[1] = 0f;
			}
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

			if (Main.netMode != 1 && npc.ai[3] == 32f && !player.npcTypeNoAggro[npc.type])
			{
				float num = (float)Math.Atan2((vector2.Y - vector.Y), (vector2.X - vector.X));
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)(Math.Cos(num) * 10.0 * -1.0), (float)(Math.Sin(num) * 10.0 * -1.0), mod.ProjectileType("SpectrallBall"), 25, 1f);
				npc.netUpdate = true;
			}

			if (npc.ai[3] > 0f)
			{
				npc.ai[3] += 1f;
				if (npc.ai[3] >= 64f)
				{
					npc.ai[3] = 0f;
				}
			}
			if (Main.netMode != 1 && npc.ai[3] == 0f)
			{
				npc.localAI[1] += 1f;
				if (npc.localAI[1] > 120f && Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height) && !Main.player[npc.target].npcTypeNoAggro[npc.type])
				{
					npc.localAI[1] = 0f;
					npc.ai[3] = 1f;
					npc.netUpdate = true;
				}
			}
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			Dust.NewDust(base.npc.position, base.npc.width, base.npc.height, 185, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
			if (base.npc.life <= 0)
			{
				Gore.NewGore(base.npc.position, base.npc.velocity, 11, 1f);
				Gore.NewGore(base.npc.position, base.npc.velocity, 12, 1f);
				Gore.NewGore(base.npc.position, base.npc.velocity, 13, 1f);
				for (int i = 0; i < 20; i++)
				{
					Dust.NewDust(base.npc.position, base.npc.width, base.npc.height, 185, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 1f);
				}
			}
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = Main.tile[x, y].type;
			return (Consolaria.NormalSpawn(spawnInfo) && spawnInfo.player.ZoneHoly && Main.hardMode && y < Main.rockLayer) ? 0.01f : 0f;
		}
	}
}
