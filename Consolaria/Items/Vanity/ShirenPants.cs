using Terraria;
using ReLogic.Localization.IME;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Consolaria.Items.Vanity
{
    [AutoloadEquip(EquipType.Legs)]

    public class ShirenPants : ModItem
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
            DisplayName.SetDefault("Shiren Pants");
            DisplayName.AddTranslation(GameCulture.Spanish, "Pantalones Shiren");
            Tooltip.SetDefault("");
            Tooltip.AddTranslation(GameCulture.Spanish, "");
        }      
    }
}
