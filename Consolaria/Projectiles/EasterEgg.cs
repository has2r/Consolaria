using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Consolaria.Projectiles
{
    public class EasterEgg : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.RottenEgg);
            projectile.width = 14;
            projectile.height = 16;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.tileCollide = true;
            projectile.ranged = true;
        }

        public override void Kill(int timeLeft)
        {
            if (Main.rand.Next(150) == 0)
            {
                NPC.NewNPC((int)projectile.Center.X, (int)projectile.Center.Y, NPCID.Bunny);
            }
            if (Main.rand.Next(150) == 0)
            {
                NPC.NewNPC((int)projectile.Center.X, (int)projectile.Center.Y, NPCID.CorruptBunny);
            }
            if (Main.rand.Next(100) == 0)
            {
                NPC.NewNPC((int)projectile.Center.X, (int)projectile.Center.Y, NPCID.CrimsonBunny);
            }
            if (Main.rand.Next(100) == 0)
            {
                NPC.NewNPC((int)projectile.Center.X, (int)projectile.Center.Y, NPCID.Bird);
            }           
            Gore.NewGore(projectile.position, projectile.oldVelocity * 0.2f, mod.GetGoreSlot("Gores/Easter_Egg"), 1f);
            Gore.NewGore(projectile.position, -projectile.oldVelocity * 0.2f, mod.GetGoreSlot("Gores/Easter_Egg"), -1f);           
        }       
    }
}
