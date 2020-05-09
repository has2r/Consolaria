using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Consolaria.Items
{
    public class SuspiciousLookingEgg : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Suspicious Looking Egg");
            Tooltip.SetDefault("Summons Lepus");
        }

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 28;
            item.maxStack = 20;
            item.value = Item.sellPrice(0, 0, 1, 0);
            item.rare = 3;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useStyle = 4;
            item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(mod.NPCType("Lepus"));
        }
        public override bool UseItem(Player player)
        {
            int SpawnPoint = Main.rand.Next(-500, 500);
            if (Main.netMode != 1)
            {
                Helper.NewNPC(player.Center + new Vector2(SpawnPoint, -40f), "Lepus").netUpdate = true;
            }
            return true;
        }
        /* public override bool UseItem(Player player)
          {
              NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("Lepus"));
              return true;
          }   */
    }
}