using Terraria;
using Terraria.ID;
using ReLogic.Localization.IME;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Consolaria.Items.Pets
{
	public class Beeswax : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Carrot);
			item.useTime = 20;
            item.useAnimation = 20;
            item.rare = 4;
            item.value = Item.buyPrice(0, 10, 0, 0);
            item.shoot = mod.ProjectileType("Tiphia");
			item.buffType = mod.BuffType("Tiphia");
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Beeswax");
			DisplayName.AddTranslation(GameCulture.Spanish, "Cera de abejas");
			Tooltip.SetDefault("Summons a pet tiphia");
			Tooltip.AddTranslation(GameCulture.Spanish, "Convoca a una mascota Tiphia");
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
