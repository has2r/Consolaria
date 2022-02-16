using Terraria;
using ReLogic.Localization.IME;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Consolaria.Items.Vanity
{
    [AutoloadEquip(EquipType.Head)]

    public class ShirenHat : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 0, 25, 0);
            item.rare = 0;
            item.vanity = true;         
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shiren Hat");
            DisplayName.AddTranslation(GameCulture.Spanish, "Sombrero Shiren");
            Tooltip.SetDefault("");
            Tooltip.AddTranslation(GameCulture.Spanish, "");
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("ShirenShirt") && legs.type == mod.ItemType("ShirenPants");
        }       
    }
}
