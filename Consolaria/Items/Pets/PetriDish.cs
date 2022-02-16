using Terraria;
using Terraria.ID;
using ReLogic.Localization.IME;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Consolaria.Items.Pets
{
	public class PetriDish : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Carrot);
			item.useTime = 20;
            item.useAnimation = 20;
            item.rare = 3;
            item.value = Item.buyPrice(0, 10, 0, 0);
            item.shoot = mod.ProjectileType("Slime");
			item.buffType = mod.BuffType("Slime");
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Petri Dish");
			DisplayName.AddTranslation(GameCulture.Spanish, "Placa de Petri");
			Tooltip.SetDefault("Summons a pet slime");
			Tooltip.AddTranslation(GameCulture.Spanish, "Invoca un Slime mascota");
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
