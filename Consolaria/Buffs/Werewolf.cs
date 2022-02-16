using Terraria;
using ReLogic.Localization.IME;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Consolaria.Buffs
{
	public class Werewolf : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Werewolf");
			DisplayName.AddTranslation(GameCulture.Spanish, "Hombre Lobo");
			Description.SetDefault("Man's Best Friend");
			Description.AddTranslation(GameCulture.Spanish, "El Mejor amigo del hombre");
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.buffTime[buffIndex] = 18000;
			CPlayer modPlayer = (CPlayer)player.GetModPlayer(mod, "CPlayer");
			modPlayer.wolfPet = true;
			bool petProjectileNotSpawned = true;
			if (player.ownedProjectileCounts[mod.ProjectileType("Werewolf")] > 0)
			{
				petProjectileNotSpawned = false;
			}
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
			{
				Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2, 0f, 0f, mod.ProjectileType("Werewolf"), 0, 0f, player.whoAmI, 0f, 0f);
			}
		}
	}
}