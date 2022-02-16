using Terraria.ModLoader;
using ReLogic.Localization.IME;
using Terraria.Localization;

namespace Consolaria.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class LepusMask : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 24;
			item.rare = 3;
			item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lepus Mask");
			DisplayName.AddTranslation(GameCulture.Spanish, "Máscara de Lepus");
			Tooltip.SetDefault("");
			Tooltip.AddTranslation(GameCulture.Spanish, "");
		}
	}
}
