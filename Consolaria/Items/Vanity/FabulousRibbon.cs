using Terraria;
using ReLogic.Localization.IME;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Consolaria.Items.Vanity
{
    [AutoloadEquip(EquipType.Head)]

    public class FabulousRibbon : ModItem
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
            DisplayName.SetDefault("Fabulous Ribbon");
            DisplayName.AddTranslation(GameCulture.Spanish, "Pajarita fabulosa");
            Tooltip.SetDefault("Allows flight and slow fall");
            Tooltip.AddTranslation(GameCulture.Spanish, "");
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("FabulousDress") && legs.type == mod.ItemType("FabulousSlippers");
        }
    }
}
  
