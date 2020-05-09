using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Consolaria
{
	public class CWorld : ModWorld
	{
		private const int saveVersion = 0;
		public static bool downedOcram;
		public static bool downedTurkor;
		public static bool downedLepus;

		public override void Initialize()
		{
			downedOcram = false;
			downedTurkor = false;
			downedLepus = false;
		}

		public override TagCompound Save()
		{
			var downed = new List<string>();
			if (downedOcram)
			{
				downed.Add("Ocram");
			}
			if (downedTurkor)
			{
				downed.Add("Turkor");
			}
			if (downedLepus)
			{
				downed.Add("Lepus");
			}

			return new TagCompound {
				{"downed", downed}
			};
		}

		public override void Load(TagCompound tag)
		{
			var downed = tag.GetList<string>("downed");
			downedOcram = downed.Contains("Ocram");
			downedTurkor = downed.Contains("Turkor");
			downedLepus = downed.Contains("Lepus");
		}

		public override void LoadLegacy(BinaryReader reader)
		{
			int loadVersion = reader.ReadInt32();
			if (loadVersion == 0)
			{
				BitsByte flags = reader.ReadByte();
				downedOcram = flags[0];
				downedTurkor = flags[1];
				downedLepus = flags[2];
			}
			else
			{
				mod.Logger.WarnFormat("Consolaria: Unknown loadVersion: {0}", loadVersion);
			}
		}

		public override void NetSend(BinaryWriter writer)
		{
			BitsByte flags = new BitsByte();
			flags[0] = downedOcram;
			flags[1] = downedTurkor;
			flags[2] = downedLepus;
			writer.Write(flags);
		}

		public override void NetReceive(BinaryReader reader)
		{
			BitsByte flags = reader.ReadByte();
			downedOcram = flags[0];
			downedTurkor = flags[1];
			downedLepus = flags[2];
		}
	}
}
