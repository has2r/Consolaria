using Terraria;
using Terraria.ID;
using ReLogic.Localization.IME;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Consolaria.Items.Vanity
{
    [AutoloadEquip(EquipType.Legs)]

    public class MonomiLegs : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.buyPrice(0, 25, 0, 0);
            item.rare = 0;
            item.vanity = true;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Monomi Legs");
            DisplayName.AddTranslation(GameCulture.Spanish, "Piernas de Monomi");
            Tooltip.SetDefault("");
            Tooltip.AddTranslation(GameCulture.Spanish, "");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Silk, 15);
            recipe.AddIngredient(ItemID.PinkThread, 3);
            recipe.AddIngredient(null, "WhiteThread", 3);
            recipe.AddTile(TileID.Loom);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
