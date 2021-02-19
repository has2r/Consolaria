using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace Consolaria.Items          
{
	public class AlbinoMandible : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 14;
			item.width = 32;
			item.height = 16;
			item.maxStack = 1;
			item.useStyle = 1;
			item.melee = true;
			item.noUseGraphic = true;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.useAnimation = 18;
			item.useTime = 18;
			item.value = Item.buyPrice(0, 1, 0, 0);
			item.shoot = mod.ProjectileType("AlbinoMandible");
			item.shootSpeed = 14f;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Albino Mandible");
			Tooltip.SetDefault("");
		}
		public override bool CanUseItem(Player player)
		{
			for (int i = 0; i < 1000; ++i)
			{
				if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == item.shoot)
				{
					return false;
				}
			}
			return true;
		}
	}
}
