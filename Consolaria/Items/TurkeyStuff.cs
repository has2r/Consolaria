using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using ReLogic.Localization.IME;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Consolaria.Items
{
	public class TurkeyStuff : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 30;
			item.summon = true;
			item.mana = 15;
			item.width = 26;
			item.height = 28;
			item.useTime = 36;
			item.channel = true;
			item.useAnimation = 36;
			item.useStyle = 1;
			item.noMelee = true;
			item.knockBack = 4;
			item.value = Item.buyPrice(0, 3, 0, 0);
			item.rare = 3;
			item.UseSound = SoundID.Item44;
			item.shoot = mod.ProjectileType("TurkeyHead");
			item.shootSpeed = 2f;
			item.buffType = mod.BuffType("TurkeyBuff");
			item.buffTime = 3600;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Turkey Staff");
			DisplayName.AddTranslation(GameCulture.Spanish, "Báculo de pavo");
			Tooltip.SetDefault("Summons a weird turkey to fight for you?");
			Tooltip.AddTranslation(GameCulture.Spanish, "Invoca a un ¿pavo raro para que luche por ti?");
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			return player.altFunctionUse != 2;
		}

		public override bool UseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				player.MinionNPCTargetAim();
			}
			return base.UseItem(player);
		}
	}
}
