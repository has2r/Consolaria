using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using ReLogic.Localization.IME;

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
            DisplayName.AddTranslation(GameCulture.Spanish, "Sombrero de George");
            Tooltip.SetDefault("Oh myyy!");
            Tooltip.AddTranslation(GameCulture.Spanish, "¡Oh mi!");
            DisplayName.AddTranslation(GameCulture.Russian, "����� ����������");
            Tooltip.AddTranslation(GameCulture.Russian, "");
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("GeorgesTuxedoShirt") && legs.type == mod.ItemType("GeorgesTuxedoPants");
        }      
    }
}
  
