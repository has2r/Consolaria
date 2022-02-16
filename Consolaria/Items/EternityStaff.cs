using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using ReLogic.Localization.IME;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Consolaria.Items
{
	public class EternityStaff : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 60;
			item.summon = true;
			item.mana = 25;
			item.width = 46;
			item.height = 46;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 1;
			item.noMelee = true;
			item.knockBack = 4;
			item.value = Item.sellPrice(0, 6, 0, 0);
			item.rare = 7;
			item.UseSound = SoundID.Item44;
			item.shoot = mod.ProjectileType("EternityStaffPro");
			item.shootSpeed = 1f;
			item.buffType = mod.BuffType("EE");
			item.buffTime = 7200;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Staff of Eternity");
			DisplayName.AddTranslation(GameCulture.Spanish, "Bastón de la Eternidad");
			Tooltip.SetDefault("Summons an Eye of Eternity to fight for you.");
			Tooltip.AddTranslation(GameCulture.Spanish, "Invoca un Ojo de la Eternidad para que luche por ti");
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
