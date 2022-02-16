using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using ReLogic.Localization.IME;
using Terraria.Localization;
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
			DisplayName.AddTranslation(GameCulture.Spanish, "Atrapadora Dragón");
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
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DSnatcherGore1"), 1f);
				for (int i = 0; i < 2; ++i)
				{
					Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DSnatcherGore2"), 1f);
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
				PosX = Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f);
				PosY = Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f);
				npc.ai[1] = npc.position.X + (float)(npc.width / 2);
				npc.ai[2] = npc.position.Y + (float)(npc.height / 2);
			}

			if (timer > 180)
			{
				timer = 0;
				PosX = Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f);
				PosY = Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f);
			}
			else if (timer > 110 || npc.Distance(new Vector2(npc.ai[1], npc.ai[2])) > 450)
			{
				Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f) - Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f), npc.position.Y + (npc.height * 0.5f) - Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f));
				PosX = npc.ai[1] - vector8.X * 1f;
				PosY = npc.ai[2] - vector8.Y * 1f;
			}
			if (timer == 100)
			{
				Projectile.NewProjectile(npc.Center, new Vector2(6f, -6f).RotatedBy(npc.rotation + 180), ProjectileID.JungleSpike, (int)(npc.damage / 2), 1, Main.myPlayer, 0, 0);
			}
			if (PosX < npc.position.X)
			{
				if (npc.velocity.X > -4) { npc.velocity.X -= 0.25f; }
			}
			else if (PosX > npc.Center.X)
			{
				if (npc.velocity.X < 4) { npc.velocity.X += 0.25f; }
			}
			if (PosY < npc.position.Y)
			{
				if (npc.velocity.Y > -4) npc.velocity.Y -= 0.25f;
			}
			else if (PosY > npc.Center.Y)
			{
				if (npc.velocity.Y < 4) npc.velocity.Y += 0.25f;
			}
			Vector2 vector6 = new Vector2(npc.Center.X - npc.ai[1], npc.Center.Y - npc.ai[1]);
			npc.rotation = ((float)Math.Atan2(Main.player[npc.target].Center.Y - (double)npc.Center.Y, Main.player[npc.target].Center.X - (double)npc.Center.X) + 3.14f) * 1f + ((float)Math.Atan2((double)npc.velocity.Y, (double)npc.velocity.X)) * 0.1f;
		}
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Vector2 vector7 = new Vector2(npc.Center.X, npc.Center.Y);
			float num29 = npc.ai[1] - vector7.X;
			float num30 = npc.ai[2] - vector7.Y;

			float rotation7 = (float)Math.Atan2((double)num30, (double)num29) - 1.57f;
			bool flag8 = true;
			while (flag8)
			{
				float num31 = (float)Math.Sqrt((double)(num29 * num29 + num30 * num30));
				if (num31 < 16f)
				{
					flag8 = false;
				}
				else
				{
					num31 = 16f / num31;
					num29 *= num31;
					num30 *= num31;
					vector7.X += num29;
					vector7.Y += num30;
					num29 = npc.ai[1] - vector7.X;
					num30 = npc.ai[2] - vector7.Y;

					Color color7 = Lighting.GetColor((int)vector7.X / 16, (int)(vector7.Y / 16f));
					Main.spriteBatch.Draw(mod.GetTexture("Gores/DragonSnatcher_Chain"), new Vector2(vector7.X - Main.screenPosition.X, vector7.Y - Main.screenPosition.Y), new Rectangle?(new Rectangle(0, 0, mod.GetTexture("Gores/DragonSnatcher_Chain").Width, Main.chain4Texture.Height)), color7, rotation7, new Vector2(mod.GetTexture("Gores/DragonSnatcher_Chain").Width * 0.5f, mod.GetTexture("Gores/DragonSnatcher_Chain").Height * 0.5f), 1f, SpriteEffects.None, 0f);
				}
			}
			return true;
		}
		public override void NPCLoot()
		{
			if (Main.netMode != NetmodeID.MultiplayerClient)
			{
				if (Main.rand.Next(20) == 1)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Cabbage"));
				}
			}
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return SpawnCondition.UndergroundJungle.Chance * 0.04f;
		}
	}
}