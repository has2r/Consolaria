using Terraria;
using Terraria.ModLoader;
using Consolaria;

namespace Consolaria.Buffs
{
	public class HotSauce : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Hot Sauce");
			Description.SetDefault("Enemies taking more damage from fire");
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
