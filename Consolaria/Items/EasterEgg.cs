using Terraria;
using ReLogic.Localization.IME;
using Terraria.Localization;
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
            DisplayName.AddTranslation(GameCulture.Spanish, "Regalo de Ostara");
            Tooltip.SetDefault("Enemies have a chance of leaving chocolate eggs on death" + "\nBroken eggs drop some life hearts and mana stars");
            Tooltip.AddTranslation(GameCulture.Spanish, "Los enemigos tienen la posibilidad de dejar huevos de chocolate al morir" + "\nLos huevos rotos dejan caer algunos corazones de vida y estrellas de maná");
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<CPlayer>().chocolateEgg = true;
        }
    }
}