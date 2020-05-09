using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace  Consolaria.Items
{
    public class SoulofBlight : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 22;
            item.rare = 7;
            item.maxStack = 999;
            item.value = Item.sellPrice(0, 2, 0, 0);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Soul of Blight");
            Tooltip.SetDefault("'The essence of infected creatures'");
             Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(7, 4));
            ItemID.Sets.AnimatesAsSoul[item.type] = true;
            ItemID.Sets.ItemIconPulse[item.type] = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
        }
    }
}
