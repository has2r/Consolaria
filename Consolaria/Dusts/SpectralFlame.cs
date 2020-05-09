using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Consolaria.Dusts
{
	public class SpectralFlame : ModDust
	{
		public override void OnSpawn(Dust dust)
		{
            dust.noLight = false;
            dust.velocity.Y = Main.rand.Next(-10, 6) * 0.1f;
            dust.velocity.X = dust.velocity.X * 0.3f;
            dust.scale *= 0.7f;
		}

		public override bool MidUpdate(Dust dust)
		{
            if (!dust.noGravity)
            {
                dust.velocity.Y = dust.velocity.Y + 0.05f;
            }
            if (!dust.noLight)
			{
				float strength = dust.scale * 1.4f;
				if (strength > 1f)
				{
					strength = 1f;
				}
				Lighting.AddLight(dust.position, 0.48f * strength, 0.4f * strength, 0.93f * strength);
			}
			return false;
		}
     
        public override Color? GetAlpha(Dust dust, Color lightColor)
		{
			return new Color(lightColor.R, lightColor.G, lightColor.B, 25);
		}
	}
}