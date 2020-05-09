using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

namespace Consolaria.Items.Vanity
{
    [AutoloadEquip(EquipType.Body)]

    public class HornedGodRobe : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.value = Item.buyPrice(0, 15, 0, 0);
            item.rare = 5;
            item.vanity = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Horned God Robe");
            Tooltip.SetDefault("");
        }
    }
}
