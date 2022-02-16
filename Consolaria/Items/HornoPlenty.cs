﻿using Terraria;
using Terraria.ID;
using ReLogic.Localization.IME;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Consolaria.Items
{	
	public class HornoPlenty : ModItem
	{		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Horn o' plenty");
			DisplayName.AddTranslation(GameCulture.Spanish, "Cuerno de la abundancia");
            Tooltip.SetDefault("It is filled with the inexhaustible gifts of celebratory fruits.");
			Tooltip.AddTranslation(GameCulture.Spanish, "Está lleno de los dones inagotables de las frutas de celebración.");
        }

		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 30;
			item.useTime = 38;
			item.useAnimation = 38;
			item.healLife = 120;
            item.consumable = false;
            item.potion = true;
            item.useStyle = 2;
			item.noMelee = true;
			item.value = Item.sellPrice(0, 0, 50, 0);
			item.rare = 3;
            item.expert = true;
			item.UseSound = SoundID.Item2;
            item.buffType = BuffID.PotionSickness;
            item.buffTime = 1800;
		}
    
        public override bool ConsumeItem(Player player)
        {
            return false;
        }
    }
}
