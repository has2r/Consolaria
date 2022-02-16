using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.ID;
using ReLogic.Localization.IME;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Consolaria.Items
{
    public class SpectralArrow : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 16;
            item.ranged = true;
            item.width = 26;
            item.maxStack = 999;
            item.consumable = true;
            item.height = 30;
            item.shoot = mod.ProjectileType("SpectralArrowPro");
            item.shootSpeed = 0.5f;
            item.knockBack = 3;
            item.value = 20;
            item.rare = 3;
            item.ammo = AmmoID.Arrow;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spectral Arrow");
            DisplayName.AddTranslation(GameCulture.Spanish, "Flecha espectral");
            Tooltip.SetDefault("inflict the Spectral Flames debuff on enemies");
            Tooltip.AddTranslation(GameCulture.Spanish, "inflige llamas espectrales a los enemigos");
        }      
    }
}
