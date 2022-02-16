using Terraria;
using Terraria.ID;
using ReLogic.Localization.IME;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Consolaria.Items.Pets
{
	public class Vial_of_Blood : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Carrot);
			item.useTime = 20;
            item.useAnimation = 20;
            item.rare = 4;
            item.value = Item.buyPrice(0, 10, 0, 0);
            item.shoot = mod.ProjectileType("Bat_Pet");
			item.buffType = mod.BuffType("Bat");
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Vial of Blood");
			DisplayName.AddTranslation(GameCulture.Spanish, "Vial de Sangre");
			Tooltip.SetDefault("Summons a pet bat");
			Tooltip.AddTranslation(GameCulture.Spanish, "Invoca un Murciélago mascota");
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
