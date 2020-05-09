using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace Consolaria.Items.Vanity
{
    [AutoloadEquip(EquipType.Head)]

    public class HornedGodMask : ModItem
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
            DisplayName.SetDefault("Horned God Mask");
            Tooltip.SetDefault("");
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("HornedGodRobe") && legs.type == mod.ItemType("HornedGodBoots");
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "'Remnant of an age of wonders'";
        }
    }
}
  
