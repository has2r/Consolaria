using Terraria;
using ReLogic.Localization.IME;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Consolaria.Buffs
{
	public class TurkeyBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Weird turkey");
			DisplayName.AddTranslation(GameCulture.Spanish, "Pavo Raro");
			Description.SetDefault("Weird turkey will fight for you");
			Description.AddTranslation(GameCulture.Spanish, "Un Pavo Raro luchará por ti");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			CPlayer modPlayer = (CPlayer)player.GetModPlayer(mod, "CPlayer");
			if (player.ownedProjectileCounts[mod.ProjectileType("TurkeyHead")] > 0)
			{
				modPlayer.headminion = true;
			}
			if (!modPlayer.headminion)
			{
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else
			{
				player.buffTime[buffIndex] = 18000;
			}
		}
	}
}