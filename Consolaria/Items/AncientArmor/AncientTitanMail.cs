using Terraria;
using ReLogic.Localization.IME;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Consolaria.Items.AncientArmor
{
    [AutoloadEquip(EquipType.Body)]
    public class AncientTitanMail : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.defense = 18;
            item.value = Item.sellPrice(0, 20, 0, 0);
            item.rare = 7;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Titan Mail");
            DisplayName.AddTranslation(GameCulture.Spanish, "Cota de malla de Titán Antigua");
            Tooltip.SetDefault("5% increased ranged damage, 20% chance to not consume ammo" + "\n15% increased ranged critical strike chance" + "\n'Ceremonial armor of a fabled archer'");
            Tooltip.AddTranslation(GameCulture.Spanish, "5% Incrementa el Daño de Rango" + "\n15% Incrementa de Probabilidad de Daño Crítico" + "\n'Armadura ceremonial de un arquero legendario'");
        }

        public override void UpdateEquip(Player player)
        {
            player.rangedDamage += 0.05f;
            player.rangedCrit += 15;
            player.ammoCost80 = true;
        }
    }
}

