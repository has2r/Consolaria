using Terraria;
using Terraria.ModLoader;

namespace Consolaria.Items.AncientArmor
{
    [AutoloadEquip(EquipType.Legs)]
    public class AncientSpectralSubligar : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.rare = 7;
            item.value = Item.sellPrice(0, 15, 0, 0);
            item.defense = 10;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Spectral Subligar");
            Tooltip.SetDefault("12% increased movement speed" + "\n6% increased magical damage" + "\nIncreases maximum mana by 30" + "\n'Ceremonial armor of a fabled mystic'");
        }
        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.12f;
            player.magicDamage += 0.06f;
            player.statManaMax2 += 30;
        }
    }
}
