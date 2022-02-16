using System.Collections.Generic;
using Terraria.ModLoader;
using ReLogic.Localization.IME;
using Terraria.Localization;
using Microsoft.Xna.Framework;

namespace Consolaria.Items.Vanity
{
    [AutoloadEquip(EquipType.Head)]
    public class MythicalLionMask : ModItem
    {     
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 26;
            item.rare = 5;
            item.vanity = true;
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            tooltips[0].overrideColor = new Color(178, 34, 34);
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mythical Lion Mask");
            DisplayName.AddTranslation(GameCulture.Spanish, "Máscara de león mítico");
            Tooltip.SetDefault("");
            Tooltip.AddTranslation(GameCulture.Spanish, "");
        }    
    }
}