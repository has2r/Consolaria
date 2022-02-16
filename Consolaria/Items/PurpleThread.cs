using Terraria;
using Terraria.ModLoader;
using ReLogic.Localization.IME;
using Terraria.Localization;
using Terraria.ID;

namespace Consolaria.Items
{
    public class PurpleThread : ModItem
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
            DisplayName.SetDefault("Purple Thread");
            DisplayName.AddTranslation(GameCulture.Spanish, "Hilo morado");
            Tooltip.SetDefault("");
            Tooltip.AddTranslation(GameCulture.Spanish, "");
        }

        /*public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DeathweedSeeds, 3);
            recipe.AddTile(TileID.Loom);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
    }
}
