using Terraria;
using Terraria.ModLoader;

namespace Consolaria.Items.AncientArmor
{
    [AutoloadEquip(EquipType.Legs)]
    public class AncientDragonGreaves : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 15, 0, 0);
            item.rare = 7;
            item.defense = 14;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Dragon Greaves");
            Tooltip.SetDefault("15% increased movement speed" + "\n'Ceremonial armor of a fabled warrior'");
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.15f;
        }
    }
}
