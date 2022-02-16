﻿using Terraria;
using ReLogic.Localization.IME;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Consolaria.Items
{
    public class CursedFang : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = 7;
            item.expert = true;
            item.accessory = true;                
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cursed Fang");
            DisplayName.AddTranslation(GameCulture.Spanish, "Colmillo Maldito");
            Tooltip.SetDefault("Melee and throwing attacks inflict Spectral Flames" + "\nDestroying enemies with Spectral Flames restores some health");
            Tooltip.AddTranslation(GameCulture.Spanish, "Los ataques cuerpo a cuerpo y de lanzamiento infligen llamas espectrales" + "\nDestruir enemigos con llamas espectrales restaura algo de salud");
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<CPlayer>().cursedFang = true;
            player.GetModPlayer<CPlayer>().customMeleeEnchant = 1;
        }
    }
}