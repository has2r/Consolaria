using Terraria;
using Terraria.ID;
using ReLogic.Localization.IME;
using Terraria.Localization;
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
			DisplayName.AddTranslation(GameCulture.Spanish, "Repollo");
			Tooltip.SetDefault("Summons a pet guinea pig");
			Tooltip.AddTranslation(GameCulture.Spanish, "Convoca a una mascota Conejillo de Indias");
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
