using Terraria.ID;
using Terraria.ModLoader;

namespace Consolaria.Items
{
	public class PurpleStuccoWall : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Purple Stucco Wall");
		}
		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 24;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.createWall = mod.WallType("PurpleStuccoWall");
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("PurpleStucco"), 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this, 4);
			recipe.AddRecipe();
		}
	}
}