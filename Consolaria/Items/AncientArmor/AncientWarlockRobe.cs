using Terraria;
using Terraria.ID;
using ReLogic.Localization.IME;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Consolaria.Items.AncientArmor
{
    [AutoloadEquip(EquipType.Body)]
    public class AncientWarlockRobe : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.buyPrice(0, 20, 0, 0);
            item.rare = 7;
            item.defense = 9;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Warlock Robe");
            DisplayName.AddTranslation(GameCulture.Spanish, "Túnica del Brujo Antigua");
            Tooltip.SetDefault("9% increased minion damage\nIncreases your max number of minions" + "\n'Ceremonial armor of a fabled summoner'");
            Tooltip.AddTranslation(GameCulture.Spanish, "9% aumento de daño de minion" + "\nAumenta tu número máximo de minions" + "\n'Armadura ceremonial de un invocador legendario'");
        }

        public override void UpdateEquip(Player player)
        {
            player.maxMinions += 1;
            player.minionDamage += 0.09f;
        }
    }
}

