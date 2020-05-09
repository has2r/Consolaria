using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;

namespace Consolaria.Projectiles
{
    public class EternityStaffPro : Minion
    {
        const int ShootRate = 40;
        const float ShootDistance = 400f;
        const float ShootSpeed = 8f;
        int TimeToShoot = ShootRate;
        float glowRotation;

        public override void SetDefaults()
        {
            projectile.netImportant = true;
            projectile.CloneDefaults(317);
            projectile.aiStyle = 62;
            projectile.width = 36;
            projectile.height = 32;
            projectile.alpha = 50;
            projectile.friendly = true;
            projectile.minion = true;
            projectile.minionSlots = 1;
            projectile.penetrate = -1;
            projectile.timeLeft = 18000;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eye of Eternity");
        }

        void Shoot()
        {
            if (--TimeToShoot <= 0)
            {
                TimeToShoot = ShootRate;

                float NearestNPCDist = ShootDistance;
                int NearestNPC = -1;
                foreach (NPC npc in Main.npc)
                {
                    if (!npc.active)
                        continue;
                    if (npc.friendly || npc.lifeMax <= 5 || npc.type == 488)
                        continue;
                    if (NearestNPCDist == -1 || npc.Distance(projectile.Center) < NearestNPCDist && Collision.CanHitLine(projectile.Center, 16, 16, npc.Center, 16, 16))
                    {
                        NearestNPCDist = npc.Distance(projectile.Center);
                        NearestNPC = npc.whoAmI;
                    }
                }
                if (NearestNPC == -1)
                    return;
                Vector2 Velocity = Helper.VelocityToPoint(projectile.Center, Main.npc[NearestNPC].Center, ShootSpeed);
                if (Main.rand.Next(2) == 1)
                {
                    Main.PlaySound(SoundID.Item8, projectile.Center);
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, Velocity.X, Velocity.Y, mod.ProjectileType("EternityScythe"), 50, 4, projectile.owner);
                }
                if (Main.rand.Next(2) == 1)
                {
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, Velocity.X, Velocity.Y, mod.ProjectileType("EternityLaser"), 60, 1, projectile.owner);
                }
            }
        }
        public override void AI()
        {
            glowRotation += 0.04f;
            Shoot();
            base.AI();
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.velocity.X != oldVelocity.X)
            {
                projectile.tileCollide = false;
            }
            if (projectile.velocity.Y != oldVelocity.Y)
            {
                projectile.tileCollide = false;
            }
            return false;
        }
        public override void CheckActive()
        {
            Player player = Main.player[projectile.owner];
            CPlayer modPlayer = (CPlayer)player.GetModPlayer(mod, "CPlayer");
            if (player.dead)
            {
                modPlayer.eternityEye = false;
            }
            if (modPlayer.eternityEye)
            {
                projectile.timeLeft = 2;
            }
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = mod.GetTexture("Glow/EternityStaffPro_Glow");
            Vector2 origin = new Vector2(projectile.width * 0.5f, projectile.height * 0.5f);
            spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, new Rectangle?(), Color.White, glowRotation, origin, 1f, SpriteEffects.FlipHorizontally, 0f);
        }
    }
}
