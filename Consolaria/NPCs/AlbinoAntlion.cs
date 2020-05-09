using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Consolaria.NPCs
{
	public class AlbinoAntlion : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Albino Antlion");
			Main.npcFrameCount[npc.type] = 5;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 45;
			npc.damage = 10;
			npc.defense = 10;
			npc.knockBackResist = 0f;
			npc.width = 24;
			npc.height = 24;
			animationType = NPCID.Antlion;
			npc.aiStyle = 19;
			npc.HitSound = SoundID.NPCHit31;
			npc.DeathSound = SoundID.NPCDeath34;
			npc.value = Item.buyPrice(0, 0, 0, 60);
            npc.behindTiles = true;
            banner = npc.type;
            bannerItem = mod.ItemType("AlbinoAntlionBanner");
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
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 59, 3f * hitDirection, -3f, 0, default(Color), 2f);
				}
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Gore_488"), 1f);
            }
		}

        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D drawTexture = mod.GetTexture("NPCs/AlbinoAntlionBody");
            Vector2 origin = new Vector2((drawTexture.Width / 2) * 0.5F, (drawTexture.Height / Main.npcFrameCount[npc.type]) * 0.5F);

            Vector2 drawPos = new Vector2(
            npc.position.X - Main.screenPosition.X + (npc.width / 2) - (Main.npcTexture[npc.type].Width) * npc.scale / 2f + origin.X * npc.scale,
            npc.position.Y - Main.screenPosition.Y + npc.height - Main.npcTexture[npc.type].Height * npc.scale / Main.npcFrameCount[npc.type] + 24f + origin.Y * npc.scale + npc.gfxOffY);

            SpriteEffects effects = npc.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            spriteBatch.Draw(drawTexture, drawPos, npc.frame, Color.White, 0f, origin, npc.scale, effects, 0);
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
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
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AlbinoMandible"));
                }
            }
        }   
    }
}