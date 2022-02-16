using Terraria.ID;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using ReLogic.Localization.IME;
using Terraria.Localization;
using Microsoft.Xna.Framework;

namespace Consolaria.Items
{
    public class Firecracker : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 40;
            item.width = 20;
            item.height = 16;
            item.thrown = true;
            item.maxStack = 99;
            item.consumable = true;
            item.useStyle = 1;
            item.rare = 5;
            item.UseSound = SoundID.Item1;
            item.useAnimation = 18;
            item.useTime = 18;
            item.value = Item.buyPrice(0, 0, 5, 5);
            item.noUseGraphic = true;
            item.noMelee = true;
            item.shoot = mod.ProjectileType("FirecrackerPro");
            item.shootSpeed = 10f;
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            tooltips[0].overrideColor = new Color(178, 34, 34);
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Firecracker");
            DisplayName.AddTranslation(GameCulture.Spanish, "Petardo");
            Tooltip.SetDefault("");
            Tooltip.AddTranslation(GameCulture.Spanish, "");
        }
    }
}
