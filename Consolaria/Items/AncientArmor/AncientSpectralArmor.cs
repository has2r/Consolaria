using Terraria;
using Terraria.ModLoader;

namespace Consolaria.Items.AncientArmor
{
    [AutoloadEquip(EquipType.Body)]
    public class AncientSpectralArmor : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 20, 0, 0);
            item.rare = 7;
            item.defense = 14;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Spectral Armor");
            Tooltip.SetDefault("7% increased magical damage"+"\n4% increased magical critical strike chance" + "\nIncreases maximum mana by 50" + "\n'Ceremonial armor of a fabled mystic'");
        }
        public override void UpdateEquip(Player player)
        {
            player.magicCrit += 4;
            player.magicDamage += 0.07f;
            player.statManaMax2 += 50;
        }
    }
}

