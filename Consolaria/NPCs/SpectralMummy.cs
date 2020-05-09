using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Consolaria.NPCs
{
	public class SpectralMummy : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spectral Mummy");
			Main.npcFrameCount[npc.type] = 15;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 120;
			npc.damage = 80;
			npc.defense = 12;
			npc.knockBackResist = 0.4f;
			npc.width = 36;
			npc.height = 46;
			animationType = NPCID.Mummy;
			npc.aiStyle = 3;
            aiType = 78;
            npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.value = Item.buyPrice(0, 0, 8, 0);
            npc.lavaImmune = false;
            banner = npc.type;
            bannerItem = mod.ItemType("SpectralMummyBanner");
        }

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = npc.lifeMax * 1;
			npc.damage = npc.damage * 1;
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

        public override void ModifyHitPlayer(Player target, ref int damage, ref bool crit)
        {
            target.AddBuff(mod.BuffType("SpectralFlame"), 300);
        }

        public override void NPCLoot()
		{
            if (Main.netMode != 1)
            {
                int centerX = (int)(npc.position.X + npc.width / 2) / 16;
                int centerY = (int)(npc.position.Y + npc.height / 2) / 16;
                int halfLength = npc.width / 2 / 16 + 1;
                if (Main.rand.Next(12) == 1)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LightShard, 1);
                }
                if (Main.rand.Next(90) == 1)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.TrifoldMap, 1);
                }
            }
        }   
    }
}