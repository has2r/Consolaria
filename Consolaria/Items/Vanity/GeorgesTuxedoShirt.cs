using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using ReLogic.Localization.IME;

namespace Consolaria.Items.Vanity
{
    [AutoloadEquip(EquipType.Body)]

    public class GeorgesTuxedoShirt : ModItem
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
            DisplayName.SetDefault("George's Suit");
            DisplayName.AddTranslation(GameCulture.Spanish, "Camisa de esmoquin de George");
            Tooltip.SetDefault("Oh myyy!");
            Tooltip.AddTranslation(GameCulture.Spanish, "¡Oh mi!");
            DisplayName.AddTranslation(GameCulture.Russian, "������ ����������");
            Tooltip.AddTranslation(GameCulture.Russian, "");
        }
    }
}
