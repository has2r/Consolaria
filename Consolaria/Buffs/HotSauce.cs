using Terraria;
using ReLogic.Localization.IME;
using Terraria.Localization;
using Terraria.ModLoader;
using Consolaria;

namespace Consolaria.Buffs
{
	public class HotSauce : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Hot Sauce");
			DisplayName.AddTranslation(GameCulture.Spanish, "Salsa Picante");
			Description.SetDefault("Enemies taking more damage from fire");
			Description.AddTranslation(GameCulture.Spanish, "Los Enemigos reciben más daño por fuego");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = true;
		}
        
		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<CGlobalNPC>().hotSauce = true;
		}
	}
}
