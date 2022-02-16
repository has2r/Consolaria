using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using ReLogic.Localization.IME;
using Microsoft.Xna.Framework;
using Terraria.Localization;

namespace Consolaria.Items
{
	public class RedEnvelope : ModItem
	{
		public override void SetDefaults()
		{
			item.maxStack = 999;
			item.consumable = true;
			item.width = 24;
			item.height = 24;
			item.rare = 5;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Red Envelope");
			DisplayName.AddTranslation(GameCulture.Spanish, "Sobre rojo");
			DisplayName.AddTranslation(GameCulture.Russian, "������� �������");
			Tooltip.SetDefault("Right click to open");
			Tooltip.AddTranslation(GameCulture.Spanish, "Haga clic derecho para abrir");
			Tooltip.AddTranslation(GameCulture.Russian, "���, ����� �������");
		}
		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			tooltips[0].overrideColor = new Color(178, 34, 34);
		}
		public override bool CanRightClick()
		{
			return true;
		}
		public override void RightClick(Player player)
		{
			player.QuickSpawnItem(mod.ItemType("Firecracker"), Main.rand.Next(3, 6));
			player.QuickSpawnItem(73, Main.rand.Next(1, 3));
		}

	}
}
