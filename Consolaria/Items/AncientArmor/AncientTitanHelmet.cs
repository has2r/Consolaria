using Terraria;
using ReLogic.Localization.IME;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Consolaria.Items.AncientArmor
{
    [AutoloadEquip(EquipType.Head)]
    public class AncientTitanHelmet : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.defense = 14;
            item.rare = 7;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Titan Helmet");
            DisplayName.AddTranslation(GameCulture.Spanish, "Casco De Titán Antiguo");
            Tooltip.SetDefault("15% increased ranged damage and critical strike chance" + "\n25% chance to not consume ammo" + "\n'Ceremonial armor of a fabled archer'");
            Tooltip.AddTranslation(GameCulture.Spanish, "15% aumento de daño a distancia y probabilidad de golpe crítico" + "\n25% De Probabilidad de No Consumir Munición" + "\n'Armadura ceremonial de un legendario arquero'");
        }

        public override void UpdateEquip(Player player)
        {
            player.rangedDamage += 0.15f;
            player.rangedCrit += 15;        
            player.ammoCost75 = true;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return (body.type == mod.ItemType("TitanMail") || body.type == mod.ItemType("AncientTitanMail")) && (legs.type == mod.ItemType("TitanLeggings") || legs.type == mod.ItemType("AncientTitanLeggings"));
        }

        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawOutlines = true;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Ranged damage crits cause stars to fall";
            player.GetModPlayer<CPlayer>().titanPower = true;
        }
    }
}
