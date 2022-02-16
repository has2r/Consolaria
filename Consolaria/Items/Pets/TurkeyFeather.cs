using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using ReLogic.Localization.IME;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Consolaria.Items.Pets
{
	public class TurkeyFeather : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Carrot);
			item.useTime = 25;
			item.useAnimation = 25;
            item.rare = 3;
            item.value = Item.buyPrice(0, 10, 0, 0);
            item.shoot = mod.ProjectileType("PetTurkey");
			item.buffType = mod.BuffType("PetTurkey");
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Turkey Feather");
			DisplayName.AddTranslation(GameCulture.Spanish, "Pluma de Pavo");
			Tooltip.SetDefault("Summons a pet turkey");
			Tooltip.AddTranslation(GameCulture.Spanish, "Convoca un Pavo mascota");
        }

       /* public override bool CanUseItem(Player player)
        {
            if(!NPC.AnyNPCs(mod.NPCType("TurkortheUngrateful")))
            {
                item.shoot = mod.ProjectileType("PetTurkey");
            }
            else
                item.shoot = 0;
            return true;
        }*/

        public override void UseStyle(Player player)
		{
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(item.buffType, 3600, true);
			}
		}
	}
}
