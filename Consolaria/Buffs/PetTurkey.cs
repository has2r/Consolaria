using Terraria;
using ReLogic.Localization.IME;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Consolaria.Buffs
{
	public class PetTurkey : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Pet Turkey");
			DisplayName.AddTranslation(GameCulture.Spanish, "Pavo Mascota");
			Description.SetDefault("");
			Description.AddTranslation(GameCulture.Spanish, "Pavo grande y carnoso");
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.buffTime[buffIndex] = 18000;
			CPlayer modPlayer = (CPlayer)player.GetModPlayer(mod, "CPlayer");
			modPlayer.turkeyPet = true;
			bool petProjectileNotSpawned = true;
			if (player.ownedProjectileCounts[mod.ProjectileType("PetTurkey")] > 0)
			{
				petProjectileNotSpawned = false;
			}
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
			{
				Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2, 0f, 0f, mod.ProjectileType("PetTurkey"), 0, 0f, player.whoAmI, 0f, 0f);
			}
		}
	}
}