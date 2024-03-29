using Terraria.ModLoader;

namespace Consolaria.Items
{
    public class LepusTrophy : ModItem
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
            item.scale = 0.5f;
            item.value = 10000;
            item.createTile = mod.TileType("LepusTrophy");
            item.placeStyle = 0;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lepus Trophy");
            Tooltip.SetDefault("");
        }
    }
}
