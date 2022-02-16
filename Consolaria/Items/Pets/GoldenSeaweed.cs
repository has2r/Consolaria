using Terraria;
using Terraria.ID;
using ReLogic.Localization.IME;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Consolaria.Items.Pets
{
	public class GoldenSeaweed : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Carrot);
			item.useTime = 20;
            item.useAnimation = 20;
            item.rare = 3;
            item.value = Item.buyPrice(0, 10, 0, 0);
            item.shoot = mod.ProjectileType("GoldenTurtle");
			item.buffType = mod.BuffType("GoldenTurtle");
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Golden Seaweed");
			DisplayName.AddTranslation(GameCulture.Spanish, "Algas Doradas");
			Tooltip.SetDefault("Summons a golden turtle");
			Tooltip.AddTranslation(GameCulture.Spanish, "Invoca una Tortuga Dorada");
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
