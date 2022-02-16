using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using ReLogic.Localization.IME;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Consolaria.NPCs
{	
	public class AchDemon : ModNPC
	{
		private float aiTimer;
		public override void SetDefaults()
		{
			npc.width = 90;
			npc.height = 50;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.damage = 41;
			npc.defense = 8;
			npc.lifeMax = 300;
			npc.value = Item.buyPrice(0, 0, 10, 0);
			npc.knockBackResist = 0.1f;
			npc.noGravity = true;
			npc.aiStyle = 14;
			npc.lavaImmune = true;
			npc.buffImmune[24] = true;
			Main.npcFrameCount[npc.type] = 2;
			animationType = NPCID.Demon;
		    banner = npc.type;
		    bannerItem = mod.ItemType("ArchDemonBanner");
		}	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Arch Demon");
			DisplayName.AddTranslation(GameCulture.Spanish, "Archidemonio");
		}
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = npc.lifeMax;
			npc.damage = npc.damage;
		}
		public override void AI()
		{
			aiTimer++;
			npc.TargetClosest();

			if (aiTimer >= 25f && aiTimer <= 95f)
			npc.dontTakeDamage = false;
			else
			{
				int index1 = Dust.NewDust(new Vector2(npc.position.X + npc.width * 0.5f + 30, npc.position.Y), 2, 2, DustID.Fire, 0, -1f, 0, default(Color), 1.75f);
				Main.dust[index1].noGravity = true;
				Main.dust[index1].scale *= 0.95f;
				int index2 = Dust.NewDust(new Vector2(npc.position.X + npc.width * 0.5f - 30, npc.position.Y), 2, 2, DustID.Fire, 0, -1f, 0, default(Color), 1.75f);
				Main.dust[index2].noGravity = true;
				Main.dust[index2].scale *= 0.95f;
				int index3 = Dust.NewDust(new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + 30), 2, 2, DustID.Fire, 0, -1f, 0, default(Color), 1.75f);
				Main.dust[index3].noGravity = true;
				Main.dust[index3].scale *= 0.95f;
				int index4 = Dust.NewDust(new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y - 30), 2, 2, DustID.Fire, 0, -1f, 0, default(Color), 1.75f);
				Main.dust[index4].noGravity = true;
				Main.dust[index4].scale *= 0.95f;
				
				npc.dontTakeDamage = true;
			}
			
			if (aiTimer == 30f || aiTimer == 50f || aiTimer == 70f || aiTimer == 90f)
			{
				if (Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height))
				{
					float num630 = 0.2f;
					Vector2 vector66 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
					float num631 = Main.player[npc.target].position.X + Main.player[npc.target].width * 0.5f - vector66.X + Main.rand.Next(-100, 101);
					float num632 = Main.player[npc.target].position.Y + Main.player[npc.target].height * 0.5f - vector66.Y + Main.rand.Next(-100, 101);
					float num633 = (float)Math.Sqrt((num631 * num631 + num632 * num632));
					num633 = num630 / num633;
					num631 *= num633;
					num632 *= num633;
					//int num636 = Projectile.NewProjectile(vector66.X, vector66.Y - 5, num631, num632, mod.ProjectileType("ArchScythe"), npc.damage / 2, 0f, Main.myPlayer, 0f, 0f);
					int num555 = Projectile.NewProjectile(vector66.X, vector66.Y, num631, num632, mod.ProjectileType("ArchScythe"), npc.damage / 2, 0f, Main.myPlayer, 0f, 0f);
					//int num556 = Projectile.NewProjectile(vector66.X, vector66.Y + 5, num631, num632, mod.ProjectileType("ArchScythe"), npc.damage / 2, 0f, Main.myPlayer, 0f, 0f);
					//Main.projectile[num636].timeLeft = 300;
					Main.projectile[num555].timeLeft = 300;
					//Main.projectile[num556].timeLeft = 300;
					Main.PlaySound(SoundID.Item8, npc.position);
				}
			}
			else if (aiTimer >= (300 + Main.rand.Next(300)))
			{
				aiTimer = 0;
			}
		}
		public override void HitEffect(int hitDirection, double damage)
		{
			Dust.NewDust(npc.position, npc.width, npc.height, 185, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
			if (npc.life <= 0)
			{
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ArchdemonGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ArchdemonGore1"), 1f);
				for (int i = 0; i < 20; i++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 185, 2.5f * hitDirection, -2.5f, 0, default(Color), 1f);
				}
			}
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
            _ = Main.tile[x, y].type;
            return (Consolaria.NormalSpawn(spawnInfo) && spawnInfo.spawnTileY > Main.maxTilesY - 200) ? 0.003f : 0f;
		}
		public override void NPCLoot()
		{
			if (Main.netMode != 1)
			{
				if (Main.rand.Next(12) == 0) // 8%
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ArchDemonMask"));
				}
			}
		} 
	}
}
