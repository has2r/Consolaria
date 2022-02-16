using Terraria;
using ReLogic.Localization.IME;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Consolaria.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class OstaraChainmail : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.defense = 5;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = 2;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jacket of Ostara");
            DisplayName.AddTranslation(GameCulture.Spanish, "Chaqueta de Ostara");
            Tooltip.SetDefault("5% increased movement speed");
            Tooltip.AddTranslation(GameCulture.Spanish, "5% Aumenta la velocidad de movimiento");
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.1f;
        }
    }
}

