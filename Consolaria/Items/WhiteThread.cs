using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Consolaria.Items
{
    public class WhiteThread : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 22;
            item.value = Item.sellPrice(0, 0, 4, 0);
            item.rare = 0;
            item.maxStack = 99;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("White Thread");
            Tooltip.SetDefault("");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MushroomGrassSeeds, 3);
            recipe.AddTile(TileID.Loom);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
