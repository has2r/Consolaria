using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Consolaria
{
    public class CGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity { get { return true; } }

        public bool sFlames;
        public bool hotSauce;

        public static int turkeyBoss = -1;

        public override void ResetEffects(NPC npc)
        {
            sFlames = false;
            hotSauce = false;
        }
        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (hotSauce)
            {
                if (npc.HasBuff(BuffID.OnFire) || npc.HasBuff(BuffID.ShadowFlame) || npc.HasBuff(BuffID.CursedInferno) || sFlames)
                {
                    npc.lifeRegen += -20;
                }
            }

            if (sFlames)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 15;
                if (damage < 3)
                {
                    damage = 3;
                }
            }
        }
        public override void HitEffect(NPC npc, int hitDirection, double damage)
        {
            Player player = Main.player[Main.myPlayer];

            if (npc.life <= 0 && player.GetModPlayer<CPlayer>().cursedFang && sFlames)
            {
                player.GetModPlayer<CPlayer>().fangTrigger = true;
            }
        }
        public override void NPCLoot(NPC npc)
        {
            Player player = Main.player[Main.myPlayer];

            if (npc.type == NPCID.TheGroom && Main.rand.Next(4) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Brain"));
            }
            if (npc.type == NPCID.Werewolf && Main.rand.Next(15) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("WolfFang"));
            }
            if (npc.type == NPCID.ToxicSludge && Main.rand.Next(50) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PetriDish"));
            }
            if (npc.type == NPCID.ManEater && Main.rand.Next(30) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Cabbage"));
            }
            if (npc.type == NPCID.FireImp && Main.rand.Next(20) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ShirenHat"));
            }
            if (player.GetModPlayer<CPlayer>().chocolateEgg && Main.rand.Next(4) == 0 && npc.netUpdate)
            {
                NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("ChocolateEgg"));
                npc.netUpdate = true;
            }
            if (npc.type == NPCID.Harpy && Main.rand.Next(20) == 0)
            {
                if (Helper.Thanksgiving)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CursedStuffing"));
                }
                if (!ServerConfig.Instance.SeasonsEnabled)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CursedStuffing"));
                }
            }
            if ((npc.type == NPCID.CorruptBunny || npc.type == NPCID.CrimsonBunny) && Main.rand.Next(18) == 0)
            {
                if (Helper.Easter)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SuspiciousLookingEgg"));
                }
                if (!ServerConfig.Instance.SeasonsEnabled)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SuspiciousLookingEgg"));
                }
                else
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SuspiciousLookingEgg"));
            }
            if (Main.expertMode && Main.rand.Next(10) == 0)
            {
                if (npc.type == NPCID.SkeletronPrime)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("HornedGodMask"));
                }
                if (npc.type == NPCID.TheDestroyer)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("HornedGodBoots"));
                }
                if ((npc.type == NPCID.Retinazer || npc.type == NPCID.Spazmatism))
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("HornedGodRobe"));
                }
            }
        }
        public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            if (sFlames)
            {
                if (Main.rand.Next(5) < 4)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, mod.DustType("SpectralFlame"), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 3.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.Next(4) == 0)
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }
                Lighting.AddLight(npc.position, 0.48f, 0.4f, 0.93f);
            }
            if (hotSauce)
            {
                npc.color = Color.OrangeRed;
                if (Main.rand.Next(15) >= 10)
                {
                    int rotDust = Dust.NewDust(npc.position - new Vector2(1f, 1f), npc.width + 1, npc.height + 1, 5, npc.velocity.X * 0.6f, npc.velocity.Y * 0.4f, 125, Color.Orange, 1f);
                    Main.dust[rotDust].noGravity = true;
                    Main.playerDrawDust.Add(rotDust);
                }
            }
        }
        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            Player player = Main.player[Main.myPlayer];
            if (type == NPCID.Clothier)
            {
                if (Main.moonPhase == 1)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Vanity.ShirenHat>());
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Vanity.ShirenShirt>());
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Vanity.ShirenPants>());
                    nextSlot++;
                }
                if (Main.bloodMoon)
                {
                    if (player.Male)
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Vanity.GeorgesHat>());
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Vanity.GeorgesTuxedoShirt>());
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Vanity.GeorgesTuxedoPants>());
                        nextSlot++;
                    }
                    else
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Vanity.FabulousRibbon>());
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Vanity.FabulousDress>());
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Vanity.FabulousSlippers>());
                        nextSlot++;
                    }
                }

                if (Main.xMas)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Vanity.FestiveHat>());
                    nextSlot++;
                }
            }
            if (type == NPCID.TravellingMerchant)
            {
                if (Main.hardMode)
                {
                    if (Main.moonPhase == 1 || Main.moonPhase == 3)
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Vanity.HornedGodMask>());
                        nextSlot++;
                    }
                    if (Main.moonPhase == 2 || Main.moonPhase == 4)
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Vanity.HornedGodRobe>());
                        nextSlot++;
                    }
                    if (Main.moonPhase == 5 || Main.moonPhase == 6)
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Vanity.HornedGodBoots>());
                        nextSlot++;
                    }
                }
            }
            if (type == NPCID.Merchant)
            {
                if (Helper.Thanksgiving)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Pets.TurkeyFeather>());
                    nextSlot++;
                }
                if (!ServerConfig.Instance.SeasonsEnabled)
                {
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Pets.TurkeyFeather>());
                        nextSlot++;
                    }
                }
            }
        }
    }
}
