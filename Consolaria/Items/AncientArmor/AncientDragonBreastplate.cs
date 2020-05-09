using Terraria;
using Terraria.ModLoader;

namespace Consolaria.Items.AncientArmor
{
    [AutoloadEquip(EquipType.Body)]
    public class AncientDragonBreastplate : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.defense = 26;
            item.value = Item.sellPrice(0, 20, 0, 0);
            item.rare = 7;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Dragon Breastplate");
            Tooltip.SetDefault("10% increased melee critical strike chance" + "\n5% increased melee damage" + "\n'Ceremonial armor of a fabled warrior'");
        }

        public override void UpdateEquip(Player player)
        {
            player.meleeCrit += 10;
            player.meleeDamage += 0.05f;
        }
    }
}

