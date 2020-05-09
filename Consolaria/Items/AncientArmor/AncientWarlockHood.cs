using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Consolaria.Items.AncientArmor
{
    [AutoloadEquip(EquipType.Head)]
    public class AncientWarlockHood : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.buyPrice(0, 10, 0, 0);
            item.defense = 7;
            item.rare = 7;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Warlock Hood");
            Tooltip.SetDefault("9% increased minion damage\nIncreases your max number of minions" + "\n'Ceremonial armor of a fabled summoner'");
        }

        public override void UpdateEquip(Player player)
        {
            player.maxMinions += 1;
            player.minionDamage += 0.09f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return (body.type == mod.ItemType("WarlockRobe") || body.type == mod.ItemType("AncientWarlockRobe")) && (legs.type == mod.ItemType("WarlockLeggings") || legs.type == mod.ItemType("AncientWarlockLeggings"));
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Minions attack stronger when health is high" + "\nMinions restore life on attack when health is low";
            player.GetModPlayer<CPlayer>().Warlock = true;
            Lighting.AddLight((int)((player.position.X) / 16.0), (int)((player.position.Y) / 16.0), 0.4f, 0.4f, 0.9f);
        }
    }
}
