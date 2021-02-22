using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Consolaria.NPCs
{
	public class DragonSnatcher : ModNPC
	{
		private int timer = 0;
		private bool spawn = false;
		private float PosX = 0f;
		private float PosY = 0f;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dragon Snatcher");
		}
		public override void SetDefaults()
		{
			npc.width = 30;
			npc.height = 30;
			npc.aiStyle = -1;
			Main.npcFrameCount[npc.type] = 3;
			npc.damage = 30;
			npc.defense = 10;
			npc.lifeMax = 80;
			npc.dontTakeDamage = false;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0f;
			npc.noTileCollide = true;
			npc.noGravity = true;
			npc.value = Item.buyPrice(0, 0, 0, 65);
			npc.buffImmune[20] = true;
			banner = npc.type;
			bannerItem = mod.ItemType("DragonSnatcherBanner");
		}
		public override void FindFrame(int frameHeight)
		{
			npc.frameCounter += 0.25f;
			npc.frameCounter %= Main.npcFrameCount[npc.type];
			int frame = (int)npc.frameCounter;
			npc.frame.Y = frame * frameHeight;
		}
		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int j = 0; j < 20; ++j)
				{
					Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, 5, 0f, 2f);
				}
				Gore.NewGore(npc.position, npc.velocity, 70, 1f);
				for (int i = 0; i < 2; ++i)
				{
					Gore.NewGore(npc.position, npc.velocity, 72, 1f);
				}
			}
		}
		public override void AI()
		{
			timer++;
			npc.TargetClosest(true);
			int i = (int)(npc.Center.X) / 16;
			int j = (int)(npc.Center.Y) / 16;
			while (j < Main.maxTilesY - 10 && Main.tile[i, j] != null && (!WorldGen.SolidTile2(i, j) && Main.tile[i - 1, j] != null) && (!WorldGen.SolidTile2(i - 1, j) && Main.tile[i + 1, j] != null && !WorldGen.SolidTile2(i + 1, j)))
				j += 2;
			int num = j - 1;
			float worldY = num * 16;
			if (!spawn)
			{
				spawn = true;
				npc.position.Y = worldY;
				PosX = Main.player[npc.target].position.X;
				PosY = Main.player[npc.target].position.Y;
				npc.ai[1] = npc.position.X + (float)(npc.width / 2);
				npc.ai[2] = npc.position.Y + (float)(npc.height / 2);
			}

			if (timer > 180)
			{
				timer = 0;
				PosX = Main.player[npc.target].position.X;
				PosY = Main.player[npc.target].position.Y;
			}

			Vector2 vector = Main.player[npc.target].Center + new Vector2(npc.Center.X, npc.Center.Y);
			Vector2 vector2 = npc.Center + new Vector2(npc.Center.X, npc.Center.Y);
			if (timer % 100 == 0)
			{
				for (int p = 0; p < 3; ++p)
				{
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, Main.rand.Next(-3, 3), -3, ProjectileID.JungleSpike, (int)(npc.damage / 4), 1, Main.myPlayer, 0, 0);
				}
			}
			if (PosX < npc.position.X)
			{
				if (npc.velocity.X > -2) { npc.velocity.X -= 0.2f; }
			}
			else if (PosX > npc.Center.X)
			{
				if (npc.velocity.X < 2) { npc.velocity.X += 0.2f; }
			}
			if (PosY < npc.position.Y)
			{
				if (npc.velocity.Y > -2) npc.velocity.Y -= 0.2f;
			}
			else if (PosY > npc.Center.Y)
			{
				if (npc.velocity.Y < 2) npc.velocity.Y += 0.2f;
			}
		}
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Vector2 vector9 = new Vector2(npc.position.X + (float)(npc.width / 2), npc.position.Y + (float)(npc.height / 2));
			float num36 = npc.ai[1] - vector9.X;
			float num37 = npc.ai[2] - vector9.Y;
			float num38 = (float)Math.Atan2((double)num37, (double)num36) - 1.57f;
			float rotate = (float)Math.Atan2((double)num37, (double)num36) - 3.14f;
			npc.rotation = rotate;
			bool flag9 = true;
			while (flag9)
			{
				int height2 = 28;
				float num39 = (float)Math.Sqrt((double)(num36 * num36 + num37 * num37));
				if (num39 < 20f)
				{
					height2 = (int)num39 - 20 + 12;
					flag9 = false;
				}
				num39 = 12f / num39;
				num36 *= num39;
				num37 *= num39;
				vector9.X += num36;
				vector9.Y += num37;
				num36 = npc.ai[1] - vector9.X;
				num37 = npc.ai[2] - vector9.Y;
				Color color9 = Lighting.GetColor((int)vector9.X / 16, (int)(vector9.Y / 16f));
				spriteBatch.Draw(Main.chain4Texture, new Vector2(vector9.X - Main.screenPosition.X, vector9.Y - Main.screenPosition.Y), new Rectangle?(new Rectangle(0, 0, Main.chain4Texture.Width, height2)), color9, num38, new Vector2((float)Main.chain4Texture.Width * 0.5f, (float)Main.chain4Texture.Height * 0.5f), 1f, SpriteEffects.None, 0f);
			}
			return true;
		}
		public override void NPCLoot()
		{
			if (Main.netMode != 1)
			{
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

