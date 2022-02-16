using Microsoft.Xna.Framework;
using Terraria;
using ReLogic.Localization.IME;
using Terraria.Localization;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Consolaria.Items
{
    public class SoulofBlight : ModItem
    {
        public override void SetDefaults()
        {
            Item refItem = new Item();
            refItem.SetDefaults(ItemID.SoulofSight);
            item.width = refItem.width;
            item.height = refItem.height;
            item.rare = 7;
            item.maxStack = 999;
            item.value = Item.sellPrice(0, 2, 0, 0);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Soul of Blight");
            DisplayName.AddTranslation(GameCulture.Spanish, "Alma de plaga");
            Tooltip.SetDefault("'The essence of infected creatures'");
            Tooltip.AddTranslation(GameCulture.Spanish, "'La esencia de las criaturas infectadas'");
            
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 4));
            ItemID.Sets.AnimatesAsSoul[item.type] = true;
            ItemID.Sets.ItemIconPulse[item.type] = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
        }

        public override void PostUpdate()
        {
            Lighting.AddLight(item.Center, Color.Yellow.ToVector3() * 0.55f * Main.essScale);
        }
    }
}
