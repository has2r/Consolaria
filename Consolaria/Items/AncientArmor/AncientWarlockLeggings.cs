using Terraria;
using Terraria.ID;
using ReLogic.Localization.IME;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Consolaria.Items.AncientArmor
{
    [AutoloadEquip(EquipType.Legs)]
    public class AncientWarlockLeggings : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.rare = 7;
            item.value = Item.buyPrice(0, 15, 0, 0);
            item.defense = 9;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Warlock Leggings");
            DisplayName.AddTranslation(GameCulture.Spanish, "Perneras del Brujo Antiguas");
            Tooltip.SetDefault("8% increased movement speed and summon damage"+ "\nIncreases your max number of minions" + "\n'Ceremonial armor of a fabled summoner'");
            Tooltip.AddTranslation(GameCulture.Spanish, "8% aumento de la velocidad de movimiento y daño de invocación" + "\nAumenta tu número máximo de minions" + "\n'Armadura ceremonial de un invocador legendario'");
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.08f;
            player.maxMinions += 1;
            player.minionDamage += 0.08f;
        }
    }
}
