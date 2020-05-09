using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Consolaria.Items.Pets
{
	public class Brain : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Carrot);
			item.useTime = 20;
            item.useAnimation = 20;
            item.rare = 2;
            item.value = Item.buyPrice(0, 5, 0, 0);
            item.shoot = mod.ProjectileType("Zombie");
			item.buffType = mod.BuffType("Zombie");
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Brain");
			Tooltip.SetDefault("Summons a pet zombie");
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
