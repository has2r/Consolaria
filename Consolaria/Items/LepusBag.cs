using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Consolaria.Items
{
    public class LepusBag : ModItem
    {
        public override void SetDefaults()
        {
            item.maxStack = 999;
            item.consumable = true;
            item.width = 24;
            item.height = 24;
            item.rare = 3;
            item.expert = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Treasure Bag");
            Tooltip.SetDefault("Right click to open");
        }

        public override int BossBagNPC => ModContent.NPCType<NPCs.Lepus.Lepus>();

        public override bool CanRightClick()
        {
            return true;
        }

        public override void OpenBossBag(Player player)
        {
            int choice = Main.rand.Next(3);

            if (choice == 0)
            {
                player.QuickSpawnItem(mod.ItemType("OstaraHat"));
            }
            if (choice == 1)
            {
                player.QuickSpawnItem(mod.ItemType("OstaraChainmail"));
            }
            if (choice == 2)
            {
                player.QuickSpawnItem(mod.ItemType("OstaraBoots"));
            }

            if (Main.rand.Next(2) == 0)
            {
                player.QuickSpawnItem(mod.ItemType("EggCannon"));
            }
            if (Main.rand.Next(10) == 0)
            {
                player.QuickSpawnItem(mod.ItemType("LepusMask"));
            }
            if (Main.rand.Next(10) == 0)
            {
                player.QuickSpawnItem(mod.ItemType("LepusTrophy"));
            }
            if (Main.rand.Next(10) == 0)
            {
                player.QuickSpawnItem(ItemID.BunnyHood);
            }

            player.QuickSpawnItem(mod.ItemType("SuspiciousLookingEgg"));
            player.QuickSpawnItem(mod.ItemType("EasterEgg"));
        }
    }
}
