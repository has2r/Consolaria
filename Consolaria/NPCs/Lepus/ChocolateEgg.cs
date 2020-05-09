using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Consolaria.NPCs.Lepus
{
    public class ChocolateEgg : ModNPC
    {
        private int timer = 0;

        public override void SetDefaults()
        {
            npc.width = 22;
            npc.height = 27;
            npc.aiStyle = 0;
            npc.damage = 0;
            npc.defense = 4;
            npc.lifeMax = 50;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0f;
            npc.noTileCollide = false;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chocolate Egg");
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
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CHEGore"));
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CHEGore"), -1f);
                npc.active = false;
            }
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 10, 1f, 0f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CHEGore"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CHEGore"), -1f);
            }
        }

        public override void NPCLoot()
        {
            if (Main.rand.Next(2) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Star);
            }
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Star);
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Heart);
            if (Main.rand.Next(2) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Heart);
            }
        }
    }
}