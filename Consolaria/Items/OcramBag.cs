using Terraria;
using Terraria.ModLoader;

namespace Consolaria.Items
{
    public class OcramBag : ModItem
    {
        public override void SetDefaults()
        {
            item.maxStack = 999;
            item.consumable = true;
            item.width = 24;
            item.height = 24;
            item.rare = 7;
            item.expert = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Treasure Bag");
            Tooltip.SetDefault("Right click to open");
        }

        public override int BossBagNPC => ModContent.NPCType<NPCs.Ocram.Ocram>();

        public override bool CanRightClick()
        {
            return true;
        }

        public override void OpenBossBag(Player player)
        {
            player.TryGettingDevArmor();
            int choice = Main.rand.Next(3);
            if (choice == 0)
            {
                player.QuickSpawnItem(mod.ItemType("EternityStaff"));
            }
            if (choice == 1)
            {
                player.QuickSpawnItem(mod.ItemType("DragonBreath"));
            }
            if (choice == 2)
            {
                player.QuickSpawnItem(mod.ItemType("EoO"));
            }

            if (Main.rand.Next(2) == 0)
            {
                int choice2 = Main.rand.Next(12);
                if (choice2 == 0)
                {
                    player.QuickSpawnItem(mod.ItemType("AncientDragonMask"));
                }
                if (choice2 == 1)
                {
                    player.QuickSpawnItem(mod.ItemType("AncientDragonBreastplate"));
                }
                if (choice2 == 2)
                {
                    player.QuickSpawnItem(mod.ItemType("AncientDragonGreaves"));
                }
                if (choice2 == 3)
                {
                    player.QuickSpawnItem(mod.ItemType("AncientSpectralHeadgear"));
                }
                if (choice2 == 4)
                {
                    player.QuickSpawnItem(mod.ItemType("AncientSpectralArmor"));
                }
                if (choice2 == 5)
                {
                    player.QuickSpawnItem(mod.ItemType("AncientSpectralSubligar"));
                }
                if (choice2 == 6)
                {
                    player.QuickSpawnItem(mod.ItemType("AncientTitanHelmet"));
                }
                if (choice2 == 7)
                {
                    player.QuickSpawnItem(mod.ItemType("AncientTitanMail"));
                }
                if (choice2 == 8)
                {
                    player.QuickSpawnItem(mod.ItemType("AncientTitanLeggings"));
                }
                if (choice2 == 9)
                {
                    player.QuickSpawnItem(mod.ItemType("AncientWarlockHood"));
                }
                if (choice2 == 10)
                {
                    player.QuickSpawnItem(mod.ItemType("AncientWarlockLeggings"));
                }
                if (choice2 == 11)
                {
                    player.QuickSpawnItem(mod.ItemType("AncientWarlockRobe"));
                }
            }

            if (Main.rand.Next(8) == 0)
            {
                player.QuickSpawnItem(mod.ItemType("OcramMask"));
            }
            player.QuickSpawnItem(mod.ItemType("SoulofBlight"), Main.rand.Next(15, 40));
            player.QuickSpawnItem(mod.ItemType("SpectralArrow"), Main.rand.Next(15, 30));
            player.QuickSpawnItem(mod.ItemType("CursedFang"));
        }
    }
}
