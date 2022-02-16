using Terraria.ID;
using ReLogic.Localization.IME;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Consolaria.Items
{
    public class PurpleStucco : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Purple Stucco");
            DisplayName.AddTranslation(GameCulture.Spanish, "Estuco morado");
            Tooltip.SetDefault("");
            Tooltip.AddTranslation(GameCulture.Spanish, "");
        }
        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
            item.maxStack = 999;
            item.value = 1;
            item.useStyle = 1;
            item.useTime = 15;
            item.useAnimation = 15;
            item.useTurn = true;
            item.autoReuse = true;
            item.consumable = true;
            item.createTile = mod.TileType("PurpleStucco");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(424, 1);
            recipe.AddIngredient(ItemID.StoneBlock, 10);
            recipe.AddIngredient(null, "PurpleThread", 1);
            recipe.SetResult(this, 10);
            recipe.AddRecipe();
        }
    }
}
