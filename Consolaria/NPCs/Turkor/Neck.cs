using Terraria;
using Terraria.ModLoader;
using ReLogic.Localization.IME;
using Terraria.Localization;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Consolaria.NPCs.Turkor
{
	public class Neck : ModProjectile
	{
		 public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Neck");
			DisplayName.AddTranslation(GameCulture.Spanish, "Cuello");
        }
		public override void SetDefaults()
		{
			projectile.aiStyle = -1;
			projectile.width = 10;
			projectile.height = 10;
			projectile.hostile = true;
			projectile.penetrate = -1;
			projectile.magic = true;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			projectile.hide = true;
		}
		public override void AI()
		{
			Vector2 vector7 = new Vector2(projectile.position.X + (projectile.width * 0.5f), projectile.position.Y + (projectile.height * 0.5f));
			float rotation0 = (float)Math.Atan2((vector7.Y) - (Main.npc[CGlobalNPC.turkeyBoss].oldPosition.Y + 15 + (Main.npc[CGlobalNPC.turkeyBoss].height * 0.5f)), (vector7.X) - (Main.npc[CGlobalNPC.turkeyBoss].oldPosition.X + (Main.npc[CGlobalNPC.turkeyBoss].width * 0.5f)));
			projectile.velocity.X = (float)(Math.Cos(rotation0) * 16) * -1;
			projectile.velocity.Y = (float)(Math.Sin(rotation0) * 16) * -1;
			if (!NPC.AnyNPCs(mod.NPCType("TurkortheUngrateful")))
			{
				projectile.Kill();
			}
			projectile.rotation = projectile.direction - 1.7f;
			projectile.spriteDirection = projectile.direction;
			for (int k = 0; k < 200; k++)
			{
				if (Main.npc[k].Hitbox.Intersects(projectile.Hitbox))
				{
					if (Main.npc[k].type == mod.NPCType("TurkortheUngrateful"))
					{
						projectile.Kill();
					}
				}
			}
		}
		public override void DrawBehind(int index, List<int> drawCacheProjsBehindNPCsAndTiles, List<int> drawCacheProjsBehindNPCs, List<int> drawCacheProjsBehindProjectiles, List<int> drawCacheProjsOverWiresUI)
		{
			drawCacheProjsBehindNPCs.Add(index);
		}
	}
}