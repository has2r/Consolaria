using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Consolaria.Items.Pets
{
	public class WolfFang : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Carrot);
			item.useTime = 20;
            item.useAnimation = 20;
            item.rare = 4;
            item.value = Item.buyPrice(0, 20, 0, 0);
            item.shoot = mod.ProjectileType("Werewolf");
			item.buffType = mod.BuffType("Werewolf");
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wolf Fang");
			Tooltip.SetDefault("Summons a pet werewolf");
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
