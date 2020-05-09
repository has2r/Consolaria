using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Consolaria.Items
{
	public class EggCannon : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 20;
			item.width = 56;
			item.height = 20;
			item.ranged = true;
			item.shootSpeed = 5f;
			item.useAnimation = 22;
			item.useTime = 22;
			item.useStyle = 5;
			item.knockBack = 0.5f;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.shoot = mod.ProjectileType("EasterEgg");
			item.rare = 3;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Egg Cannon");
			Tooltip.SetDefault("'To kill a goblin, you have to break a few eggs'");
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-8, 0);
		}		
	}
}
