using Terraria;
using ReLogic.Localization.IME;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Consolaria.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class OstaraHat : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.defense = 4;
            item.rare = 2;
        }
   
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hat of Ostara");
            DisplayName.AddTranslation(GameCulture.Spanish, "Sombrero de Ostara");
            Tooltip.SetDefault("5% increased movement speed");
            Tooltip.AddTranslation(GameCulture.Spanish, "5% Aumenta la velocidad de movimiento");
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.1f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("OstaraChainmail") && legs.type == mod.ItemType("OstaraBoots");
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Negates fall damage";
            player.noFallDmg = true;
        }       
    }
}
