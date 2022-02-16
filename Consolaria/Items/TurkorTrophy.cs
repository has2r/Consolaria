using Terraria.ModLoader;
using ReLogic.Localization.IME;
using Terraria.Localization;

namespace Consolaria.Items
{
    public class TurkorTrophy : ModItem
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
            item.scale = 0.8f;
            item.value = 10000;
            item.createTile = mod.TileType("TurkorTrophy");
            item.placeStyle = 0;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Turkor Trophy");
            DisplayName.AddTranslation(GameCulture.Spanish, "Trofeo Turkor");
            Tooltip.SetDefault("");
            Tooltip.AddTranslation(GameCulture.Spanish, "");
        }
    }
}
