using Terraria;
using ReLogic.Localization.IME;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Consolaria.Items.Banners
{
	public class SpectralMummyBanner : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spectral Mummy Banner");
			DisplayName.AddTranslation(GameCulture.Spanish, "Estandarte de Momia Espectral");
		}

		public override void SetDefaults()
        {
			item.width = 10;
			item.height = 24;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.rare = 1;
			item.value = Item.buyPrice(0, 0, 10, 0);
			item.createTile = mod.TileType("MonsterBanner");
			item.placeStyle = 9;       
		}
	}
}
