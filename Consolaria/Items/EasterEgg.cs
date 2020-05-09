using Terraria;
using Terraria.ModLoader;

namespace Consolaria.Items
{
    public class EasterEgg : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 30;
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = 3;
            item.expert = true;
            item.accessory = true;                
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ostara's Gift");
            Tooltip.SetDefault("Enemies have a chance of leaving chocolate eggs on death" + "\nBroken eggs drop some life hearts and mana stars");
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<CPlayer>().chocolateEgg = true;
        }
    }
}