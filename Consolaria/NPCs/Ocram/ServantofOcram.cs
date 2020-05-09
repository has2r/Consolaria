using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Consolaria.NPCs.Ocram
{
    public class ServantofOcram : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Servant of Ocram");
            Main.npcFrameCount[npc.type] = 2;
        }

        public override void SetDefaults()
        {
            npc.aiStyle = 23;
            animationType = NPCID.ServantofCthulhu;
            npc.lifeMax = 450;
            npc.damage = 40;
            npc.defense = 8;
            npc.width = 54;
            npc.height = 54;
            animationType = 5;
            npc.knockBackResist = 0f;
            npc.HitSound = SoundID.NPCHit18;
            npc.DeathSound = SoundID.NPCHit18;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 600;
            npc.damage = 60;
        }

        public override void AI()
        {
            npc.position += npc.velocity * 1.1f;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 3; i++)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, ModContent.DustType<Dusts.TizonaDust>(), hitDirection, -1f, 0, default(Color), 1f);
            }
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Servant_Gore"), 1f);
                for (int j = 0; j < 12; j++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, ModContent.DustType<Dusts.TizonaDust>(), hitDirection, -1f, 0, default(Color), 1f);
                }
            }
        }
    }
}