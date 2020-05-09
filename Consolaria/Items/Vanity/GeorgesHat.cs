using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace Consolaria.Items.Vanity
{
    [AutoloadEquip(EquipType.Head)]

    public class GeorgesHat : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 0, 20, 0);
            item.value = Item.buyPrice(0, 1, 0, 0);
            item.rare = 0;
            item.vanity = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("George's Hat");
            Tooltip.SetDefault("Oh myyy!");
            DisplayName.AddTranslation(GameCulture.Russian, "Шляпа Мафиозника");
            Tooltip.AddTranslation(GameCulture.Russian, "");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Silk, 10);
            recipe.AddIngredient(ItemID.PinkThread, 4);
            recipe.AddTile(TileID.Loom);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("GeorgesTuxedoShirt") && legs.type == mod.ItemType("GeorgesTuxedoPants");
        }      
    }
}
  
