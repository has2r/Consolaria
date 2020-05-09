using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Consolaria.NPCs.Lepus
{
    public class SmallEgg : ModNPC
    {
        private int timer = 0;

        public override void SetDefaults()
        {
            npc.friendly = false;
            npc.width = 22;
            npc.height = 24;
            npc.aiStyle = 0;
            npc.damage = 0;
            npc.defense = 3;
            npc.lifeMax = 65;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0f;
            npc.noTileCollide = false;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lepus Egg");
        }

        public override void AI()
        {
            if (Main.netMode != 1)
            {
                npc.homeless = false;
                npc.homeTileX = -1;
                npc.homeTileY = -1;
                npc.netUpdate = true;
            }
            npc.spriteDirection = 0;
            npc.velocity.X = 0f;
            npc.velocity.Y = 5f;
            timer++;
            if (timer >= 360)//will hatch after time
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/EggShell"));
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/EggShell"));
                npc.Transform(mod.NPCType("DisasterBunny"));
            }
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 10, 1f, 0f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/EggShell"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/EggShell"), 1f);
            }
        }
    }
}