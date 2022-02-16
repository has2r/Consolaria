using Terraria;
using Terraria.ID;
using ReLogic.Localization.IME;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Consolaria.NPCs.Lepus
{
    public class BigEgg : ModNPC
    {
        private int timer = 0;

        public override void SetDefaults()
        {
            npc.friendly = false;
            npc.width = 44;
            npc.height = 48;
            npc.aiStyle = 0;
            npc.damage = 0;
            npc.defense = 3;
            npc.lifeMax = 90;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0f;
            npc.noTileCollide = false;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lepus Egg");
            DisplayName.AddTranslation(GameCulture.Spanish, "Huevo de Lepus");
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
            if (timer >= 600)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/EggShellBig"));
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/EggShellBig"));
                npc.Transform(mod.NPCType("Lepus"));
            }
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 10, 1f, 0f);
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/EggShellBig"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/EggShellBig"), 1f);
            }
        }
    }
}