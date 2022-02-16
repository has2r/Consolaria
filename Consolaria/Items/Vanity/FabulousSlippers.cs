using Terraria;
using ReLogic.Localization.IME;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Consolaria.Items.Vanity
{
    [AutoloadEquip(EquipType.Legs)]

    public class FabulousSlippers : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.value = Item.buyPrice(0, 25, 0, 0);
            item.rare = 0;
            item.vanity = true;         
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fabulous Slippers");
            DisplayName.AddTranslation(GameCulture.Spanish, "Zapatillas fabulosas");
            Tooltip.SetDefault("Oh myyy!");
            Tooltip.AddTranslation(GameCulture.Spanish, "!Oh mi¡");
        }    
    }
}
