using Terraria.ModLoader;
using ReLogic.Localization.IME;
using Terraria.Localization;

namespace Consolaria.Items
{
    public class OcramTrophy : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useStyle = 1;
            item.consumable = true;
            item.value = 50000;
            item.createTile = mod.TileType("OcramTrophy");
            item.placeStyle = 0;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ocram Trophy");
            DisplayName.AddTranslation(GameCulture.Spanish, "Trofeo Ocram");
            Tooltip.SetDefault("");
            Tooltip.AddTranslation(GameCulture.Spanish, "");
        }
    }
}
