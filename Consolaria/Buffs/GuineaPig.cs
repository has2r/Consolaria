using Terraria;
using ReLogic.Localization.IME;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Consolaria.Buffs
{
	public class GuineaPig : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Guinea Pig");
			DisplayName.AddTranslation(GameCulture.Spanish, "Conejillo de Indias");
			Description.SetDefault("Simply adorable");
			Description.AddTranslation(GameCulture.Spanish, "Simplemente adorable");
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.buffTime[buffIndex] = 18000;
			CPlayer modPlayer = (CPlayer)player.GetModPlayer(mod, "CPlayer");
			modPlayer.pigPet = true;
			bool petProjectileNotSpawned = true;
			if (player.ownedProjectileCounts[mod.ProjectileType("GuineaPig")] > 0)
			{
				petProjectileNotSpawned = false;
			}
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
			{
				Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2, 0f, 0f, mod.ProjectileType("GuineaPig"), 0, 0f, player.whoAmI, 0f, 0f);
			}
		}
	}
}