using System;
using Terraria;
using Terraria.ModLoader;

namespace Consolaria
{
	public static class GlowMask
	{
		const short Count = 6;

		public static short TurkorBurningCharcoal;
		public static short TitanHelmet;
		public static short TitanMail;
		public static short TitanMailArms;
		public static short TitanLeggings;
		public static short SpectralArrow;

		static short End;
		static bool Loaded;

		public static void Load()
		{
			Array.Resize(ref Main.glowMaskTexture, Main.glowMaskTexture.Length + GlowMask.Count);
			short i = (short)(Main.glowMaskTexture.Length - GlowMask.Count);			
			Main.glowMaskTexture[i] = ModContent.GetTexture("Consolaria/Glow/TitanHelmet_Head_Glow");
			TitanHelmet = i;
			i++;
			Main.glowMaskTexture[i] = ModContent.GetTexture("Consolaria/Glow/TitanMail_Body_Glow");
			TitanMail = i;
			i++;
			Main.glowMaskTexture[i] = ModContent.GetTexture("Consolaria/Glow/TitanMail_Arms_Glow");
			TitanMailArms = i;
			i++;
			Main.glowMaskTexture[i] = ModContent.GetTexture("Consolaria/Glow/TitanLeggings_Legs_Glow");
			TitanLeggings = i;
			i++;
			Main.glowMaskTexture[i] = ModContent.GetTexture("Consolaria/Glow/SpectralArrowPro_Glow");
			SpectralArrow = i;
			i++;
			End = i;
			Loaded = true;
		}

		public static void Unload()
		{
			if (Main.glowMaskTexture.Length == GlowMask.End)
			{
				Array.Resize(ref Main.glowMaskTexture, Main.glowMaskTexture.Length - GlowMask.Count);
			}
			else if (Main.glowMaskTexture.Length > GlowMask.End && Main.glowMaskTexture.Length > GlowMask.Count)
			{
				for (int i = GlowMask.End - GlowMask.Count; i < GlowMask.End; i++)
				{
					Main.glowMaskTexture[i] = ModContent.GetTexture("Terraria/Item_0");
				}
			}

			Loaded = false;
			TurkorBurningCharcoal = 0;
			TitanHelmet = 0;
			TitanMail = 0;
			TitanMailArms = 0;
			TitanLeggings = 0;
			SpectralArrow = 0;
			End = 0;
		}
	}
}
