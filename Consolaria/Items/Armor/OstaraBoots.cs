using Terraria;
using Terraria.ModLoader;

namespace Consolaria.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class OstaraBoots : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = 2;
            item.defense = 4;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Boots of Ostara");
            Tooltip.SetDefault("5% increased movement speed" + "\nAllows the wearer to perform a bunny hop, ");
        }
        public override void UpdateEquip(Player player)
        {
            player.GetModPlayer<CPlayer>().bunnyHope = true;
            player.moveSpeed += 0.05f;
        }      
    }
}
