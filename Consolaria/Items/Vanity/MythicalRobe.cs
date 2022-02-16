using System.Collections.Generic;
using Terraria.ModLoader;
using ReLogic.Localization.IME;
using Terraria.Localization;
using Microsoft.Xna.Framework;

namespace Consolaria.Items.Vanity
{
    [AutoloadEquip(EquipType.Body)]
    public class MythicalRobe : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 18;
            item.rare = 5;
            item.vanity = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mythical Robe");
            DisplayName.AddTranslation(GameCulture.Spanish, "Túnica mítica");
            Tooltip.SetDefault("");
            Tooltip.AddTranslation(GameCulture.Spanish, "");

        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            tooltips[0].overrideColor = new Color(178, 34, 34);
        }
        public override void SetMatch(bool male, ref int equipSlot, ref bool robes)
        {
            robes = true;
            equipSlot = mod.GetEquipSlot("MythicalSubligar_Legs", EquipType.Legs);
        }

        public override void DrawHands(ref bool drawHands, ref bool drawArms)
        {
            drawHands = true;
        }
    }
}