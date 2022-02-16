using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ReLogic.Localization.IME;
using Terraria.Localization;

namespace Consolaria.Items.Vanity
{
    [AutoloadEquip(EquipType.Head)]

    public class FestiveHat : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 0, 20, 0);
            item.value = Item.buyPrice(0, 1, 0, 0);
            item.rare = 2;
            item.vanity = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Festive Top Hat");
            DisplayName.AddTranslation(GameCulture.Spanish, "Sombrero de copa festivo");
            Tooltip.SetDefault("");
            Tooltip.AddTranslation(GameCulture.Spanish, "");
        }       
    }
}
  
