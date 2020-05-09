using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Consolaria.Items.Pets
{
	public class Cabbage : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Carrot);
			item.useTime = 20;
            item.useAnimation = 20;
            item.rare = 3;
            item.value = Item.buyPrice(0, 10, 0, 0);
            item.shoot = mod.ProjectileType("GuineaPig");
			item.buffType = mod.BuffType("GuineaPig");
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cabbage");
			Tooltip.SetDefault("Summons a pet guinea pig");
        }

        public override void UseStyle(Player player)
		{
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(item.buffType, 3600, true);
			}
		}
	}
}
