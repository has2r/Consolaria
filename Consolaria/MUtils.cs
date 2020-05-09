using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace Consolaria
{
	public static class MUtils
	{
		public static bool NextBool(this UnifiedRandom rand, int chance, int total)
		{
			return rand.Next(total) < chance;
		}

		public static void DrawNPCGlowMask(SpriteBatch spriteBatch, NPC npc, Texture2D texture)
		{
			var effects = npc.direction == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
			spriteBatch.Draw(texture, npc.Center - Main.screenPosition + new Vector2(0, npc.gfxOffY), npc.frame,
			Color.White, npc.rotation, npc.frame.Size() / 2, npc.scale, effects, 0);
		}
	 
		public static void DrawArmorGlowMask(EquipType type, Texture2D texture, PlayerDrawInfo info)
		{
			switch (type)
			{
				case EquipType.Head:
					{
						DrawData drawData = new DrawData(texture, new Vector2((float)((int)(info.position.X - Main.screenPosition.X) + (info.drawPlayer.width - info.drawPlayer.bodyFrame.Width) / 2), (float)((int)(info.position.Y - Main.screenPosition.Y) + info.drawPlayer.height - info.drawPlayer.bodyFrame.Height + 4)) + info.drawPlayer.headPosition + info.headOrigin, new Rectangle?(info.drawPlayer.bodyFrame), info.headGlowMaskColor, info.drawPlayer.headRotation, info.headOrigin, 1f, info.spriteEffects, 0);
						drawData.shader = info.headArmorShader;
						Main.playerDrawData.Add(drawData);
						break;
					}
				case EquipType.Body:
					{
						int i = 0;
						Rectangle bodyFrame = info.drawPlayer.bodyFrame;
						int k2 = i;
						bodyFrame.X += k2;
						bodyFrame.Width -= k2;
						if (info.drawPlayer.direction == -1)
						{
							k2 = 0;
						}
						if (!info.drawPlayer.invis)
						{
							DrawData drawData = new DrawData(texture, new Vector2((float)((int)(info.position.X - Main.screenPosition.X - (float)(info.drawPlayer.bodyFrame.Width / 2) + (float)(info.drawPlayer.width / 2) + (float)k2)), (float)((int)(info.position.Y - Main.screenPosition.Y + (float)info.drawPlayer.height - (float)info.drawPlayer.bodyFrame.Height + 4f))) + info.drawPlayer.bodyPosition + new Vector2((float)(info.drawPlayer.bodyFrame.Width / 2), (float)(info.drawPlayer.bodyFrame.Height / 2)), new Rectangle?(bodyFrame), info.bodyGlowMaskColor, info.drawPlayer.bodyRotation, info.bodyOrigin, 1f, info.spriteEffects, 0);
							drawData.shader = info.bodyArmorShader;
							Main.playerDrawData.Add(drawData);
						}
						break;
					}
				case EquipType.Legs:
					if (info.drawPlayer.shoe != 15 || info.drawPlayer.wearsRobe)
					{
						if (!info.drawPlayer.invis)
						{
							DrawData drawData = new DrawData(texture, new Vector2((float)((int)(info.position.X - Main.screenPosition.X - (float)(info.drawPlayer.legFrame.Width / 2) + (float)(info.drawPlayer.width / 2))), (float)((int)(info.position.Y - Main.screenPosition.Y + (float)info.drawPlayer.height - (float)info.drawPlayer.legFrame.Height + 4f))) + info.drawPlayer.legPosition + info.legOrigin, new Rectangle?(info.drawPlayer.legFrame), info.legGlowMaskColor, info.drawPlayer.legRotation, info.legOrigin, 1f, info.spriteEffects, 0);
							drawData.shader = info.legArmorShader;
							Main.playerDrawData.Add(drawData);
						}
					}
					break;
			}
		}

		public static void DrawItemGlowMask(Texture2D texture, PlayerDrawInfo info)
		{
			Item item = info.drawPlayer.HeldItem;
			if (info.shadow == 0f && !info.drawPlayer.frozen && ((info.drawPlayer.itemAnimation > 0 && item.useStyle != 0) || (item.holdStyle > 0 && !info.drawPlayer.pulley)) && !info.drawPlayer.dead && !item.noUseGraphic && (!info.drawPlayer.wet || !item.noWet))
			{
				Vector2 offset = default(Vector2);
				float rotOffset = 0f;
				Vector2 origin = default(Vector2);
				if (item.useStyle == 5)
				{
					if (Item.staff[item.type])
					{
						rotOffset = 0.785f * (float)info.drawPlayer.direction;
						if (info.drawPlayer.gravDir == -1f)
						{
							rotOffset -= 1.57f * (float)info.drawPlayer.direction;
						}
						origin = new Vector2((float)texture.Width * 0.5f * (float)(1 - info.drawPlayer.direction), (float)((info.drawPlayer.gravDir == -1f) ? 0 : texture.Height));
						int x = -(int)origin.X;
						ItemLoader.HoldoutOrigin(info.drawPlayer, ref origin);
						offset = new Vector2(origin.X + (float)x, 0f);
					}
					else
					{
						offset = new Vector2(10f, (float)(texture.Height / 2));
						ItemLoader.HoldoutOffset(info.drawPlayer.gravDir, item.type, ref offset);
						origin = new Vector2(-offset.X, (float)(texture.Height / 2));
						if (info.drawPlayer.direction == -1)
						{
							origin.X = (float)texture.Width + offset.X;
						}
						offset = new Vector2((float)(texture.Width / 2), offset.Y);
					}
				}
				else
				{
					origin = new Vector2((float)texture.Width * 0.5f * (float)(1 - info.drawPlayer.direction), (float)((info.drawPlayer.gravDir == -1f) ? 0 : texture.Height));
				}
				Main.playerDrawData.Add(new DrawData(texture, info.itemLocation - Main.screenPosition + offset, new Rectangle?(texture.Bounds), new Color(250, 250, 250, item.alpha), info.drawPlayer.itemRotation + rotOffset, origin, item.scale, info.spriteEffects, 0));
			}
		}

		public static void DrawItemGlowMaskWorld(SpriteBatch spriteBatch, Item item, Texture2D texture, float rotation, float scale)
		{
			Main.spriteBatch.Draw(texture, new Vector2(item.position.X - Main.screenPosition.X + (float)(item.width / 2), item.position.Y - Main.screenPosition.Y + (float)item.height - (float)(texture.Height / 2) + 2f), new Rectangle?(new Rectangle(0, 0, texture.Width, texture.Height)), new Color(250, 250, 250, item.alpha), rotation, new Vector2((float)(texture.Width / 2), (float)(texture.Height / 2)), scale, SpriteEffects.None, 0f);
		}

		public static void DrawProjectileGlowMaskWorld(SpriteBatch spriteBatch, Projectile projectile, Texture2D texture, float rotation, float scale)
		{
			Main.spriteBatch.Draw(texture, new Vector2(projectile.position.X - Main.screenPosition.X + (float)(projectile.width / 2), projectile.position.Y - Main.screenPosition.Y + (float)projectile.height - (float)(texture.Height / 2) + 2f), new Rectangle?(new Rectangle(0, 0, texture.Width, texture.Height)), new Color(250, 250, 250, projectile.alpha), rotation, new Vector2((float)(texture.Width / 2), (float)(texture.Height / 2)), scale, SpriteEffects.None, 0f);
		}

		public static void DrawNPCGlowMask(SpriteBatch spriteBatch, Texture2D texture, NPC npc, Color color, float rotation, float scale)
		{
			if (texture != null && !texture.IsDisposed)
			{
				SpriteEffects effects = (npc.spriteDirection == 1) ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
				Vector2 origin = new Vector2((float)(texture.Width / 2), (float)(texture.Height / Main.npcFrameCount[npc.type] / 2));
				Vector2 position = npc.Center - Main.screenPosition;
				Main.spriteBatch.Draw(texture, position, new Rectangle?(npc.frame), Color.White, rotation, origin, scale, effects, 0f);
			}
		}		
	}
}

