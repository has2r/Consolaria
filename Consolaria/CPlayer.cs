using Consolaria.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Consolaria
{
    public class CPlayer : ModPlayer
    {
        public override bool Autoload(ref string name) { return true; }

        const int spread = 45;
        const float spreadMult = 0.03f;
        public bool check = false;

        public bool eternityEye;
        public bool sFlames;
        public bool cursedFang;
        public bool fangTrigger;
        public bool chocolateEgg;
        public bool turkeyPet;
        public bool headminion;
        public bool bunnyHope;
        public bool pigPet;
        public bool dragonExplosion;
        public bool titanPower;
        public bool spectralGuard;
        public bool Warlock;
        public bool dontConsumeAmmo15;
        public bool wolfPet;
        public bool Tiphia;
        public bool Zombie;
        public bool Bat_Pet;
        public bool Petri;
        public bool GTurtle;

        private int hopeCount;

        public int customMeleeEnchant = 0;
        public int constancustomMeleeEnchanttDamage = 0;

        public override void ResetEffects()
        {
            eternityEye = false;
            sFlames = false;
            cursedFang = false;
            fangTrigger = false;
            chocolateEgg = false;
            turkeyPet = false;
            headminion = false;
            bunnyHope = false;
            pigPet = false;
            dragonExplosion = false;
            titanPower = false;
            spectralGuard = false;
            Warlock = false;
            dontConsumeAmmo15 = false;
            wolfPet = false;
            Tiphia = false;
            Zombie = false;
            Bat_Pet = false;
            Petri = false;
            GTurtle = false;

            customMeleeEnchant = 0;
        }

        public override void UpdateDead()
        {
            sFlames = false;
        }

        public override void UpdateEquips(ref bool wallSpeedBuff, ref bool tileSpeedBuff, ref bool tileRangeBuff)
        {
            if (Warlock && player.statLife > (player.statLifeMax2 * 0.5f))
            {
                player.minionDamage += 0.05f;
            }
        }

        public override void PostUpdateEquips()
        {
            if (bunnyHope)
            {
                if (player.controlJump && player.releaseJump)
                {
                    hopeCount++;
                }
                if (hopeCount == 1)
                {
                    player.jumpSpeedBoost += 1f;
                }
                if (hopeCount == 2)
                {
                    player.jumpSpeedBoost += 2f;
                }
                if (hopeCount == 3)
                {
                    player.jumpSpeedBoost += 3f;
                }
                if (hopeCount == 4)
                {
                    player.jumpSpeedBoost += 4f;
                }
                if (hopeCount > 5)
                {
                    player.jumpSpeedBoost += 5f;
                    hopeCount = 1;
                }
            }
        }
        public override void MeleeEffects(Item item, Rectangle hitbox)
        {
            if (item.melee || item.thrown && !item.noMelee && !item.noUseGraphic && customMeleeEnchant > 0)
            {
                if (customMeleeEnchant == 1)
                {
                    if (Main.rand.Next(2) == 0)
                    {
                        int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, mod.DustType("SpectralFlame"), player.velocity.X * 0.2f + player.direction * 3f, player.velocity.Y * 0.2f, 100, default(Color), 2.5f);
                        Main.dust[dust].noGravity = true;
                        Main.dust[dust].velocity *= 0.7f;
                        Main.dust[dust].velocity.Y -= 0.5f;
                    }
                }
            }
        }
        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            if ((item.melee || item.thrown) && customMeleeEnchant == 1)
            {
                target.AddBuff(mod.BuffType("SpectralFlame"), 60 * Main.rand.Next(3, 7), false);
            }
            if (titanPower && item.ranged && crit)
            {
                Vector2 HighToLow = new Vector2(0, 25);
                Projectile.NewProjectile(new Vector2(target.position.X, target.position.Y - 1000), new Vector2(HighToLow.X, HighToLow.Y), ModContent.ProjectileType<TitanStar>(), Main.rand.Next(50, 100), 1, player.whoAmI);
            }
        }
        public override void OnHitNPCWithProj(Projectile projectile, NPC target, int damage, float knockback, bool crit)
        {
            if ((projectile.melee || projectile.thrown) && !projectile.noEnchantments)
            {
                if (customMeleeEnchant == 1)
                {
                    target.AddBuff(mod.BuffType("SpectralFlame"), 60 * Main.rand.Next(3, 7), false);
                }
            }
            if (titanPower && projectile.ranged && crit)
            {
                Vector2 HighToLow = new Vector2(0, 25);
                Projectile.NewProjectile(new Vector2(target.position.X, target.position.Y - 1000), new Vector2(HighToLow.X, HighToLow.Y), ModContent.ProjectileType<TitanStar>(), Main.rand.Next(50, 100), 1, player.whoAmI);
            }

            if (Warlock && player.statLife < (player.statLifeMax2 * 0.5f) && projectile.minion && Main.rand.Next(2) ==0)
            {
                player.statLife += projectile.damage / 16;
                player.HealEffect(projectile.damage / 16);
            }
        }

        public override void OnHitPvp(Item item, Player target, int damage, bool crit)
        {
            if ((item.melee || item.thrown) && customMeleeEnchant == 1)
            {
                target.AddBuff(mod.BuffType("SpectralFlame"), 60 * Main.rand.Next(3, 7), true);
            }
        }

        public override void OnHitPvpWithProj(Projectile projectile, Player target, int damage, bool crit)
        {
            if (projectile.melee || projectile.thrown && !projectile.noEnchantments)
            {
                if (customMeleeEnchant == 1)
                {
                    target.AddBuff(mod.BuffType("SpectralFlame"), 60 * Main.rand.Next(3, 7), true);
                }
            }
        }
        public override void OnHitByNPC(NPC npc, int damage, bool crit)
        {
            if (dragonExplosion)
            {
                Vector2 velocity = Helper.VelocityToPoint(player.Center, npc.Center, 6f);
                for (int i = 0; i < 1; i++)
                {
                    velocity.X = velocity.X + Main.rand.Next(-spread, spread + 1) * spreadMult;
                    velocity.Y = velocity.Y + Main.rand.Next(-spread, spread + 1) * spreadMult;
                    Projectile.NewProjectile(player.Center.X - 5, player.Center.Y - 10, velocity.X, velocity.Y, mod.ProjectileType("Dragon_flame_1"), 15, 4f, 0);
                    Projectile.NewProjectile(player.Center.X, player.Center.Y - 10, velocity.X, velocity.Y, mod.ProjectileType("Dragon_flame_2"), 15, 4f, 0);
                    Projectile.NewProjectile(player.Center.X + 5, player.Center.Y - 10, velocity.X, velocity.Y, mod.ProjectileType("Dragon_flame_3"), 15, 4f, 0);
                }
            }
        }

        public override void UpdateBadLifeRegen()
        {
            if (sFlames)
            {
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegenTime = 0;
                player.lifeRegen -= 15;
            }
            if (Warlock && player.lifeRegen > 0)
            {
                player.lifeRegen = player.lifeRegen / 2;
            }
        }

        public override void DrawEffects(PlayerDrawInfo drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
        {
            if (fangTrigger)
            {
                player.HealEffect(30);
                player.statLife += 30;

                Main.PlaySound(7, (int)player.position.X, (int)player.position.Y, 1, 1f, 0f);
                for (int i = 0; i < 35; i++)
                {
                    int dust = Dust.NewDust(player.position, player.width, player.height, mod.DustType("SpectralFlame"), 0f, -2f, 0, default(Color), 1.8f);
                    Main.dust[dust].noGravity = true;
                    Dust dust2 = Main.dust[dust];
                    dust2.position.X = dust2.position.X - ((Main.rand.Next(-50, 51) / 20) - 1.5f);
                    Dust dust3 = Main.dust[dust];
                    dust3.position.Y = dust3.position.Y - ((Main.rand.Next(-50, 51) / 20) - 1.5f);
                    if (Main.dust[dust].position != player.Center)
                    {
                        Main.dust[dust].velocity = player.DirectionTo(Main.dust[dust].position) * 8f;
                    }
                }

                fangTrigger = false;
            }
            if (sFlames)
            {
                if (Main.rand.Next(4) == 0 && drawInfo.shadow == 0f)
                {
                    int dust = Dust.NewDust(drawInfo.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, mod.DustType("SpectralFlame"), player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, default(Color), 3.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    Main.playerDrawDust.Add(dust);
                }
                r *= 0.48f;
                g *= 0.4f;
                b *= 0.93f;

                fullBright = false;
            }
        }
    }
}