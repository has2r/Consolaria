using Terraria;
using Terraria.ID;
using ReLogic.Localization.IME;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Consolaria.Items
{
    public class TurkorBag : ModItem
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
            DisplayName.AddTranslation(GameCulture.Spanish, "Bolsa del Tesoro");
            Tooltip.SetDefault("Right click to open");
            Tooltip.AddTranslation(GameCulture.Spanish, "Haga clic derecho para abrir");
        }

        public override int BossBagNPC => ModContent.NPCType<NPCs.Turkor.TurkortheUngrateful>();

        public override bool CanRightClick()
        {
            return true;
        }

        public override void OpenBossBag(Player player)
        {
            if (Main.rand.Next(2) == 0)
            {
                player.QuickSpawnItem(mod.ItemType("SpicySauce"), Main.rand.Next(20, 40));
            }
            if (Main.rand.Next(2) == 0)
            {
                player.QuickSpawnItem(mod.ItemType("GreatDrumstick"));
            }
            if (Main.rand.Next(2) == 0)
            {
                player.QuickSpawnItem(mod.ItemType("FeatherStorm"));
            }
            if (Main.rand.Next(2) == 0)
            {
                player.QuickSpawnItem(mod.ItemType("TurkeyStuff"));
            }
            if (Main.rand.Next(10) == 0)
            {
                player.QuickSpawnItem(mod.ItemType("TurkorMask"));
            }
            if (Main.rand.Next(10) == 0)
            {
                player.QuickSpawnItem(mod.ItemType("TurkorTrophy"));
            }         
            player.QuickSpawnItem(ItemID.Feather, Main.rand.Next(10, 20));
            player.QuickSpawnItem(mod.ItemType("HornoPlenty"));
        }
    }
}
