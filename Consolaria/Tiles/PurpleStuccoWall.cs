using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Consolaria.Tiles
{
	public class PurpleStuccoWall : ModWall
	{
		public override void SetDefaults()
		{
			dustType = 6;
			Main.wallHouse[Type] = true;
			drop = mod.ItemType("PurpleStuccoWall");
			AddMapEntry(Color.MediumPurple);
		}
		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = (fail ? 1 : 3);
		}
	}
}
