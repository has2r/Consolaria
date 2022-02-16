using Terraria;
using Terraria.ModLoader;
using ReLogic.Localization.IME;
using Terraria.Localization;
using Terraria.ID;

namespace Consolaria.Items.Banners
{
	public class ArchDemonBanner : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Arch Demon Banner");
			DisplayName.AddTranslation(GameCulture.Spanish, "Estandarte de Archidemonio");
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
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.rare = ItemRarityID.Blue;
			item.value = Item.buyPrice(0, 0, 10, 0);
			item.createTile = mod.TileType("MonsterBanner");
			item.placeStyle = 11;       
		}
	}
}
