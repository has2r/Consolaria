using Terraria;
using Terraria.ModLoader;

namespace Consolaria.Items.AncientArmor
{
    [AutoloadEquip(EquipType.Head)]
    public class AncientDragonMask : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.defense = 20;
            item.rare = 7;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Dragon Mask");
            Tooltip.SetDefault("10% increased melee speed and damage" + "\n15% increased melee critical strike chance" + "\n'Ceremonial armor of a fabled warrior'");
        }

        public override void UpdateEquip(Player player)
        {
            player.meleeCrit += 15;
            player.meleeDamage += 0.1f;
            player.meleeSpeed += 0.1f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return (body.type == mod.ItemType("DragonBreastplate") || body.type == mod.ItemType("AncientDragonBreastplate")) && (legs.type == mod.ItemType("DragonGreaves") || legs.type == mod.ItemType("AncientDragonGreaves"));
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Creates a burst of flames when injured";
            player.GetModPlayer<CPlayer>().dragonExplosion = true;
            Lighting.AddLight((int)((player.position.X) / 16.0), (int)((player.position.Y) / 16.0), 0.4f, 0.4f, 0.9f);
        }

        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawShadow = true;
        }
    }
}
