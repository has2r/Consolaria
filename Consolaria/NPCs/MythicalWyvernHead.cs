using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Consolaria.NPCs
{
	public class MythicalWyvernHead : ModNPC
	{
		bool initiate = false;
		public int TimerHeal = 0;
		public float TimerAnim = 0;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mythical Wyvern");
			Main.npcFrameCount[npc.type] = Main.npcFrameCount[npc.type] = 1;
		}
		public override void SetDefaults()
		{
			npc.width = 32;
			npc.height = 32;
			npc.aiStyle = 6;
			npc.damage = 80;
			npc.defense = 35;
			npc.lifeMax = 10000;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.HitSound = SoundID.NPCHit7;
			npc.DeathSound = SoundID.NPCDeath8;
			npc.knockBackResist = 0.0f;
			npc.buffImmune[24] = true;
			npc.buffImmune[46] = true;
			npc.buffImmune[47] = true;
			npc.buffImmune[67] = true;
		}
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.defense = 45;
			npc.lifeMax = 15000;
		}
		public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
		{
			scale = 1.1f;
			return new bool?();
		}
		public override void AI()
		{
			if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead)
			{
				npc.TargetClosest(true);
			}
			if (Main.player[npc.target].dead && npc.timeLeft > 300)
			{
				npc.timeLeft = 300;
			}
		  
			if (Main.netMode != 1)
			{
				if (npc.ai[0] == 0f)
				{
					npc.ai[2] = npc.whoAmI;
					npc.realLife = npc.whoAmI;
					int num96 = npc.whoAmI;
					for (int num97 = 0; num97 < 24; num97++)
					{
						int num98 = mod.GetNPC("MythicalWyvernBody").npc.type;
						if (num97 == 4 || num97 == 9 || num97 == 14 || num97 == 19)
						{
							num98 = mod.GetNPC("MythicalWyvernLegs").npc.type;
						}
						else
						{
							if (num97 == 21)
							{
								num98 = mod.GetNPC("MythicalWyvernBody2").npc.type;
							}
							else
							{
								if (num97 == 22)
								{
									num98 = mod.GetNPC("MythicalWyvernBody3").npc.type;
								}
								else
								{
									if (num97 == 23)
									{
										num98 = mod.GetNPC("MythicalWyvernTail").npc.type;
									}
								}
							}
						}
						int num99 = NPC.NewNPC((int)(npc.position.X + (npc.width / 2)), (int)(npc.position.Y + npc.height), num98, npc.whoAmI);
						Main.npc[num99].ai[2] = npc.whoAmI;
						Main.npc[num99].realLife = npc.whoAmI;
						Main.npc[num99].ai[1] = num96;
						Main.npc[num96].ai[0] = num99;
						num96 = num99;
					}
				}
			
			}
			int num107 = (int)(npc.position.X / 16f) - 1;
			int num108 = (int)((npc.position.X + npc.width) / 16f) + 2;
			int num109 = (int)(npc.position.Y / 16f) - 1;
			int num110 = (int)((npc.position.Y + npc.height) / 16f) + 2;
			if (num107 < 0)
			{
				num107 = 0;
			}
			if (num108 > Main.maxTilesX)
			{
				num108 = Main.maxTilesX;
			}
			if (num109 < 0)
			{
				num109 = 0;
			}
			if (num110 > Main.maxTilesY)
			{
				num110 = Main.maxTilesY;
			}

			if (npc.velocity.X < 0f)
			{
				npc.spriteDirection = 1;
			}
			if (npc.velocity.X > 0f)
			{
				npc.spriteDirection = -1;
			}
			
			float num115 = 16f;
			float num116 = 0.4f;
			
			Vector2 vector14 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
			float num118 = Main.rand.Next(-500,500)+Main.player[npc.target].position.X + (Main.player[npc.target].width / 2);
			float num119 = Main.rand.Next(-500,500)+Main.player[npc.target].position.Y + (Main.player[npc.target].height / 2);
			num118 = ((int)(num118 / 16f) * 16);
			num119 = ((int)(num119 / 16f) * 16);
			vector14.X = ((int)(vector14.X / 16f) * 16);
			vector14.Y = ((int)(vector14.Y / 16f) * 16);
			num118 -= vector14.X;
			num119 -= vector14.Y;
			float num120 = (float)Math.Sqrt((num118 * num118 + num119 * num119));
			
			float num123 = Math.Abs(num118);
			float num124 = Math.Abs(num119);
			float num125 = num115 / num120;
			num118 *= num125;
			num119 *= num125;

			bool flag14 = false;
			if (((npc.velocity.X > 0f && num118 < 0f) || (npc.velocity.X < 0f && num118 > 0f) || (npc.velocity.Y > 0f && num119 < 0f) || (npc.velocity.Y < 0f && num119 > 0f)) && Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y) > num116 / 2f && num120 < 300f)
			{
				flag14 = true;
				if (Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y) < num115)
				{
					npc.velocity *= 1.1f;
				}
			}
			if (npc.position.Y > Main.player[npc.target].position.Y || (Main.player[npc.target].position.Y / 16f) > Main.worldSurface || Main.player[npc.target].dead)
			{
				flag14 = true;
				if (Math.Abs(npc.velocity.X) < num115 / 2f)
				{
					if (npc.velocity.X == 0f)
					{
						npc.velocity.X = npc.velocity.X - npc.direction;
					}
					npc.velocity.X = npc.velocity.X * 1.1f;
				}
				else
				{
					if (npc.velocity.Y > -num115)
					{
						npc.velocity.Y = npc.velocity.Y - num116;
					}
				}
			}
			if (!flag14)
			{
				if ((npc.velocity.X > 0f && num118 > 0f) || (npc.velocity.X < 0f && num118 < 0f) || (npc.velocity.Y > 0f && num119 > 0f) || (npc.velocity.Y < 0f && num119 < 0f))
				{
					if (npc.velocity.X < num118)
					{
						npc.velocity.X = npc.velocity.X + num116;
					}
					else
					{
						if (npc.velocity.X > num118)
						{
							npc.velocity.X = npc.velocity.X - num116;
						}
					}
					if (npc.velocity.Y < num119)
					{
						npc.velocity.Y = npc.velocity.Y + num116;
					}
					else
					{
						if (npc.velocity.Y > num119)
						{
							npc.velocity.Y = npc.velocity.Y - num116;
						}
					}
					if (Math.Abs(num119) < num115 * 0.2 && ((npc.velocity.X > 0f && num118 < 0f) || (npc.velocity.X < 0f && num118 > 0f)))
					{
						if (npc.velocity.Y > 0f)
						{
							npc.velocity.Y = npc.velocity.Y + num116 * 2f;
						}
						else
						{
							npc.velocity.Y = npc.velocity.Y - num116 * 2f;
						}
					}
					if (Math.Abs(num118) < num115 * 0.2 && ((npc.velocity.Y > 0f && num119 < 0f) || (npc.velocity.Y < 0f && num119 > 0f)))
					{
						if (npc.velocity.X > 0f)
						{
							npc.velocity.X = npc.velocity.X + num116 * 2f;
						}
						else
						{
							npc.velocity.X = npc.velocity.X - num116 * 2f;
						}
					}
				}
				else
				{
					if (num123 > num124)
					{
						if (npc.velocity.X < num118)
						{
							npc.velocity.X = npc.velocity.X + num116 * 1.1f;
						}
						else
						{
							if (npc.velocity.X > num118)
							{
								npc.velocity.X = npc.velocity.X - num116 * 1.1f;
							}
						}
						if ((Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y)) < num115 * 0.5)
						{
							if (npc.velocity.Y > 0f)
							{
								npc.velocity.Y = npc.velocity.Y + num116;
							}
							else
							{
								npc.velocity.Y = npc.velocity.Y - num116;
							}
						}
					}
					else
					{
						if (npc.velocity.Y < num119)
						{
							npc.velocity.Y = npc.velocity.Y + num116 * 1.1f;
						}
						else
						{
							if (npc.velocity.Y > num119)
							{
								npc.velocity.Y = npc.velocity.Y - num116 * 1.1f;
							}
						}
						if ((Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y)) < num115 * 0.5)
						{
							if (npc.velocity.X > 0f)
							{
								npc.velocity.X = npc.velocity.X + num116;
							}
							else
							{
								npc.velocity.X = npc.velocity.X - num116;
							}
						}
					}
				}
			}
			npc.rotation = (float)Math.Atan2(npc.velocity.Y, npc.velocity.X) + 1.57f;
		}	
		public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
		{
			Vector2 origin = new Vector2((Main.npcTexture[npc.type].Width / 2), (Main.npcTexture[npc.type].Height / Main.npcFrameCount[npc.type] / 2));
			Color alpha = Color.White;
			SpriteEffects effects = SpriteEffects.None;
			if (npc.spriteDirection == 1)
			{
				effects = SpriteEffects.FlipHorizontally;
			}
			spriteBatch.Draw(Main.npcTexture[npc.type], new Vector2(npc.position.X - Main.screenPosition.X + (npc.width / 2) - Main.npcTexture[npc.type].Width * npc.scale / 2f + origin.X * npc.scale, npc.position.Y - Main.screenPosition.Y + npc.height - Main.npcTexture[npc.type].Height * npc.scale / Main.npcFrameCount[npc.type] + 4f + origin.Y * npc.scale + 56f), new Rectangle?(npc.frame), alpha, npc.rotation, origin, npc.scale, effects, 0f);
			npc.alpha = 255;
			return true;
		}
		public override void NPCLoot()
		{
			if (Main.netMode != 1)
			{
				int centerX = (int)(npc.position.X + (npc.width / 2)) / 16;
				int centerY = (int)(npc.position.Y + (npc.height / 2)) / 16;
				int halfLength = npc.width / 2 / 16 + 1;

				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 575, Main.rand.Next(10, 15));
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("RedEnvelope"), Main.rand.Next(5, 15));
				if (Main.rand.Next(2) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MythicalLionMask"));
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MythicalRobe"));
				};
			}
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = Main.tile[x, y].type;
			return (spawnInfo.sky && Main.hardMode) && !Helper.ChineseNewYear ? 0.04f : 0f;
		}
	}
}