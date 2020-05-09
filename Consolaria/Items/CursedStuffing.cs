using Microsoft.Xna.Framework;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Consolaria.Items
{
    public class CursedStuffing : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cursed Stuffing");
            Tooltip.SetDefault("It pulses with malevolent energy, summon Turkor the Ungrateful" + "\nPet turkey must be with you");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
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
             return !NPC.AnyNPCs(mod.NPCType("TurkortheUngrateful")) && Main.player[Main.myPlayer].buffType.Contains(mod.BuffType("PetTurkey"));
        }

        public override bool UseItem(Player player)
        {
            Main.PlaySound(SoundID.Roar, player.position, 0);
            int SpawnPoint = Main.rand.Next(-250, 250);
            if (Main.netMode != 1)
            {
                Helper.NewNPC(player.Center + new Vector2(SpawnPoint, -35f), "TurkortheUngrateful").netUpdate = true;
            }
            return true;
        }

        /*  public override bool UseItem(Player player)
           {
               Main.PlaySound(SoundID.Roar, player.position, 0);
               NPC.NewNPC((int)Main.player[Main.myPlayer].Center.X + 0, 0, NPC.NewNPC((int)Main.player[Main.myPlayer].Center.X + 300, (int)Main.player[Main.myPlayer].Center.Y - 50, mod.NPCType("TurkortheUngrateful")));
               return true;
           }     */
    }
}