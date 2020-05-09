using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;

namespace Consolaria.NPCs
{
    class SpectralElemental : ModNPC
    {
        private Player player;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spectral Elemental");
            Main.npcFrameCount[npc.type] = 15;
        }
        public override void SetDefaults()
        {
            npc.height = 44;
            npc.width = 24;
            npc.lifeMax = 400;
            npc.damage = 40;
            npc.defense = 30;
            npc.aiStyle = 3;
            aiType = NPCID.ChaosElemental;
            animationType = NPCID.ChaosElemental;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath6;
            npc.buffImmune[BuffID.Poisoned] = true;
            npc.buffImmune[BuffID.OnFire] = true;
            npc.buffImmune[BuffID.Confused] = true;
            npc.buffImmune[BuffID.CursedInferno] = true;
            npc.buffImmune[BuffID.Venom] = true;
            npc.buffImmune[BuffID.ShadowFlame] = true;
            npc.buffImmune[mod.BuffType("SpectralFlame")] = true;
            banner = npc.type;
            bannerItem = mod.ItemType("SpectralElementalBanner");
        }
        public override void AI()
        {
            npc.ai[0]++;
            player = Main.player[npc.target];
            npc.TargetClosest(true);
            Vector2 playerPos = new Vector2(player.position.X, player.position.Y);
            if (npc.ai[0] >= 240 + Main.rand.Next(0, 120))
            {
                for (int I = 0; I < 20; I++)
                {
                    Dust.NewDust(npc.position, npc.width - (Main.rand.Next(npc.width)), npc.height - (Main.rand.Next(npc.height)), ModContent.DustType<Dusts.SpectralFlame>(), (float)Main.rand.Next(-5, 5), Main.rand.Next(-5, 5), 0);
                }
                Teleport(playerPos);
                npc.ai[0] = 0;
            }
        }
        private void Teleport(Vector2 playerPosition)
        {
            Vector2 teleportTo = new Vector2(playerPosition.X + Main.rand.NextFloat(-80f, 80f), playerPosition.Y - 20f);
            Vector2 teleportFrom = new Vector2(npc.position.X, npc.position.Y);
            Vector2 NormalizedVec = new Vector2(0, -2f);
            NormalizedVec.Normalize();

            if (!Collision.SolidCollision(teleportTo, 16, 16))
            {
                Projectile.NewProjectile(teleportFrom, NormalizedVec * 4f, mod.ProjectileType("SpectralBomb"), 15, 4, 0, player.whoAmI);
                npc.position = teleportTo;
            }
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            Dust.NewDust(npc.position, npc.width, npc.height, 185, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, 11, 1f);
                Gore.NewGore(npc.position, npc.velocity, 12, 1f);
                Gore.NewGore(npc.position, npc.velocity, 13, 1f);
                for (int i = 0; i < 25; i++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, 185, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 1f);
                }
            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            SpriteEffects effects = (npc.spriteDirection == -1) ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            Texture2D texture = mod.GetTexture("NPCs/SpectralElemental");
            Vector2 origin = new Vector2((float)(Main.npcTexture[base.npc.type].Width / 2), (float)(Main.npcTexture[npc.type].Height / Main.npcFrameCount[npc.type] / 2));
            Main.spriteBatch.Draw(texture, new Vector2(base.npc.position.X - Main.screenPosition.X + (float)(npc.width / 2) - (float)Main.npcTexture[npc.type].Width * npc.scale / 2f + origin.X * npc.scale, npc.position.Y - Main.screenPosition.Y + (float)npc.height - (float)Main.npcTexture[npc.type].Height * npc.scale / (float)Main.npcFrameCount[npc.type] + 4f + origin.Y * npc.scale), new Rectangle?(npc.frame), Color.White, npc.rotation, origin, npc.scale, effects, 0f);
            for (int i = 1; i < base.npc.oldPos.Length; i++)
            {
                Color color = Lighting.GetColor((int)((double)npc.position.X + (double)npc.width * 0.5) / 16, (int)(((double)npc.position.Y + (double)npc.height * 0.5) / 16.0));
                Color color2 = color;
                color2 = Color.Lerp(color2, Color.LightSkyBlue, 0.5f);
                color2 = npc.GetAlpha(color2);
                color2 *= (float)(npc.oldPos.Length - i) / 15f;
                Main.spriteBatch.Draw(texture, new Vector2(base.npc.position.X - Main.screenPosition.X + (float)(base.npc.width / 2) - (float)Main.npcTexture[base.npc.type].Width * base.npc.scale / 2f + origin.X * base.npc.scale, base.npc.position.Y - Main.screenPosition.Y + (float)base.npc.height - (float)Main.npcTexture[base.npc.type].Height * base.npc.scale / (float)Main.npcFrameCount[base.npc.type] + 4f + origin.Y * base.npc.scale) - base.npc.velocity * (float)i * 0.5f, new Rectangle?(base.npc.frame), color2, base.npc.rotation, origin, base.npc.scale, effects, 0f);
            }
            return true;
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            var GlowMask = mod.GetTexture("Glow/SpectralElemental_Glow");
            var Effects = npc.direction == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            spriteBatch.Draw(GlowMask, npc.Center - Main.screenPosition + new Vector2(0, npc.gfxOffY), npc.frame, Color.White, npc.rotation, npc.frame.Size() / 2, npc.scale, Effects, 0);
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if ((double)spawnInfo.spawnTileY <= Main.worldSurface || !spawnInfo.player.ZoneHoly)
                return 0.0f;
            return 0.04f;
        }
    }
}
