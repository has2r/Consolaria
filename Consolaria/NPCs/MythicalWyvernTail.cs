using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Consolaria.NPCs
{
    public class MythicalWyvernTail : ModNPC
    {
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
			npc.netAlways = true;
			npc.dontCountMe = true;
            npc.dontTakeDamage = true;
            npc.buffImmune[24] = true;
            npc.buffImmune[46] = true;
            npc.buffImmune[47] = true;
            npc.buffImmune[67] = true;
            npc.dontTakeDamage = true;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.defense = 45;
            npc.lifeMax = 15000;
        }
        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            return new bool?(false);
        }
        public override void AI()
		{
			if (!Main.npc[(int)npc.ai[1]].active)
			{
				npc.life = 0;
				npc.HitEffect(0, 10.0);
				npc.active = false;
			}
		/*	if (npc.position.X > Main.npc[(int)npc.ai[1]].position.X)
			{
				npc.spriteDirection = 1;
			}
			if (npc.position.X < Main.npc[(int)npc.ai[1]].position.X)
			{
				npc.spriteDirection = -1;
			}*/
		}
		
		public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
		{
			Vector2 origin = new Vector2((float)(Main.npcTexture[npc.type].Width / 2), (float)(Main.npcTexture[npc.type].Height / Main.npcFrameCount[npc.type] / 2));
			Color alpha = Color.White;
			SpriteEffects effects = SpriteEffects.None;
			if (npc.spriteDirection == 1)
			{
				effects = SpriteEffects.FlipHorizontally;
			}
			spriteBatch.Draw(Main.npcTexture[npc.type], new Vector2(npc.position.X - Main.screenPosition.X + (float)(npc.width / 2) - (float)Main.npcTexture[npc.type].Width * npc.scale / 2f + origin.X * npc.scale, npc.position.Y - Main.screenPosition.Y + (float)npc.height - (float)Main.npcTexture[npc.type].Height * npc.scale / (float)Main.npcFrameCount[npc.type] + 4f + origin.Y * npc.scale + 56f), new Rectangle?(npc.frame), alpha, npc.rotation, origin, npc.scale, effects, 0f);
			npc.alpha = 255;
			return true;
		}
    }
}