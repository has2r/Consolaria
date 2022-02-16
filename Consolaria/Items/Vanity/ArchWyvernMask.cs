using Terraria;
using Terraria.ID;
using ReLogic.Localization.IME;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Consolaria.Items.Vanity
{
    [AutoloadEquip(EquipType.Head)]

    public class ArchWyvernMask : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 1, 20, 0);
            item.rare = 3;
            item.vanity = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Arch Wyvern Mask");
            DisplayName.AddTranslation(GameCulture.Spanish, "Máscara de Archiguiverno");
            Tooltip.SetDefault("");
            Tooltip.AddTranslation(GameCulture.Spanish, "");
        }       
    }
}
  
