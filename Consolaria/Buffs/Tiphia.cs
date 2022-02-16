using Terraria;
using ReLogic.Localization.IME;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Consolaria.Buffs
{
	public class Tiphia : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Tiphia");
			DisplayName.AddTranslation(GameCulture.Spanish, "Tiphia");
			Description.SetDefault("Don't let it sting you");
			Description.AddTranslation(GameCulture.Spanish, "No dejes que te pique");
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.buffTime[buffIndex] = 18000;
			CPlayer modPlayer = (CPlayer)player.GetModPlayer(mod, "CPlayer");
			modPlayer.Tiphia = true;
			bool petProjectileNotSpawned = true;
			if (player.ownedProjectileCounts[mod.ProjectileType("Tiphia")] > 0)
			{
				petProjectileNotSpawned = false;
			}
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
			{
				Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2, 0f, 0f, mod.ProjectileType("Tiphia"), 0, 0f, player.whoAmI, 0f, 0f);
			}
		}
	}
}