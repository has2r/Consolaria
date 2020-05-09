using Terraria;
using Terraria.ModLoader;

namespace Consolaria.Items.AncientArmor
{
    [AutoloadEquip(EquipType.Legs)]
    public class AncientTitanLeggings : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 18;
            item.rare = 7;
            item.defense = 13;
            item.value = Item.sellPrice(0, 15, 0, 0);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Titan Leggings");
            Tooltip.SetDefault("10% increased movement speed and ranged damage" + "\n15% chance to not consume ammo" + "\n'Ceremonial armor of a fabled archer'");
        }
        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.1f;
            player.rangedDamage += 0.1f;
            player.GetModPlayer<CPlayer>().dontConsumeAmmo15 = true;
        }
    }
}
