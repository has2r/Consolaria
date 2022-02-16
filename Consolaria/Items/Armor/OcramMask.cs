using Terraria.ModLoader;
using ReLogic.Localization.IME;
using Terraria.Localization;

namespace Consolaria.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class OcramMask : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 24;
			item.rare = 7;
			item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ocram Mask");
			DisplayName.AddTranslation(GameCulture.Spanish, "Máscara de Ocram");
			Tooltip.SetDefault("");
			Tooltip.AddTranslation(GameCulture.Spanish, "");
		}

	}
}
