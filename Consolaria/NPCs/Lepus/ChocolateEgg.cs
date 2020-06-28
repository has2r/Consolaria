using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Consolaria.NPCs.Lepus
{
    public class ChocolateEgg : ModNPC
    {
        public override void SetDefaults()
        {
            npc.width = 21;
            npc.height = 26;
            npc.aiStyle = 0;
            npc.damage = 0;
            npc.defense = 3;
            npc.lifeMax = 30;
            npc.HitSound = SoundID.NPCHit18;
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
        }
        public override void UpdateLifeRegen(ref int damage)
        {
            if (npc.lifeRegen > 0)
            {
                npc.lifeRegen = 0;
            }
            npc.lifeRegen -= 5;
            if (damage < 1)
            {
                damage = 1;
            }
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
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
            if (Main.rand.Next(2) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Heart);
            }
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Star);
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Heart);
        }
    }
}