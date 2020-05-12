using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Consolaria
{
    public class Consolaria : Mod
    {
        public static Mod instance
        {
            get
            {
                return ModLoader.GetMod("Consolaria");
            }
        }

        public override void Load()
        {
            AddEquipTexture(null, EquipType.Legs, "MythicalSubligar_Legs", "Consolaria/Items/Vanity/MythicalSubligar_Legs");
            if (!Main.dedServ)
            {
                AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/Ocram"), ItemType("OcramMusicBox"), TileType("OcramMusicBox"));
            }

            GlowMask.Load();
            Helper.checkThanksgiving();
            Helper.checkEaster();
        }

        public override void PostSetupContent()
        {
            Mod fargos = ModLoader.GetMod("Fargowiltas");
            if (fargos != null)
            {
                fargos.Call("AddSummon", 9.9f, "Consolaria", "SuspiciousLookingSkull", (Func<bool>)(() => CWorld.downedOcram), 500000);
                fargos.Call("AddSummon", 5.65f, "Consolaria", "StuffedHeart", (Func<bool>)(() => CWorld.downedTurkor), 180000);
                fargos.Call("AddSummon", 1.9f, "Consolaria", "SuspiciousLookingEgg", (Func<bool>)(() => CWorld.downedLepus), 60000);
            }

            Mod bossChecklist = ModLoader.GetMod("BossChecklist");
            if (bossChecklist != null)
            {
                bossChecklist.Call(
                    "AddBoss",
                    1.9f,
                    ModContent.NPCType<NPCs.Lepus.Lepus>(),
                    this,
                    "Lepus",
                    (Func<bool>)(() => CWorld.downedLepus),
                    ModContent.ItemType<Items.SuspiciousLookingEgg>(),
                    new List<int> { ModContent.ItemType<Items.Armor.LepusMask>(), ModContent.ItemType<Items.LepusTrophy>()},
                    new List<int> { ModContent.ItemType<Items.LepusBag>(), ModContent.ItemType<Items.EasterEgg>(), ModContent.ItemType<Items.EggCannon>(), ModContent.ItemType<Items.Armor.OstaraHat>(), ModContent.ItemType<Items.Armor.OstaraChainmail>(), ModContent.ItemType<Items.Armor.OstaraBoots>(), ModContent.ItemType<Items.SuspiciousLookingEgg>(), ItemID.BunnyHood},
                    "Use a [i:" + ModContent.ItemType<Items.SuspiciousLookingEgg>() + "] at day time",
                    "{0} jumps away into sunset!"
                );
                bossChecklist.Call(
                    "AddBoss",
                    5.65f,
                    ModContent.NPCType<NPCs.Turkor.TurkortheUngrateful>(),
                    this,
                    "Turkor The Ungrateful",
                    (Func<bool>)(() => CWorld.downedTurkor),
                    ModContent.ItemType<Items.CursedStuffing>(),
                    new List<int> { ModContent.ItemType<Items.Armor.TurkorMask>(), ModContent.ItemType<Items.TurkorTrophy>() },
                    new List<int> { ModContent.ItemType<Items.TurkorBag>(), ModContent.ItemType<Items.HornoPlenty>(), ModContent.ItemType<Items.GreatDrumstick>(), ModContent.ItemType<Items.SpicySauce>(), ModContent.ItemType<Items.FeatherStorm>(), ModContent.ItemType<Items.TurkeyStuff>(), ItemID.Feather },
                    "Use a [i:" + ModContent.ItemType<Items.CursedStuffing>() + "] after summoning pet turkey",
                    "Turkor the Ungrateful escapes from the dinner plate!"
                );
                bossChecklist.Call(
                   "AddBoss",
                   9.9f,
                   ModContent.NPCType<NPCs.Ocram.Ocram>(),
                   this,
                   "Ocram",
                   (Func<bool>)(() => CWorld.downedOcram),
                   ModContent.ItemType<Items.SuspiciousLookingSkull>(),
                   new List<int> { ModContent.ItemType<Items.Armor.OcramMask>(), ModContent.ItemType<Items.OcramTrophy>() },
                   new List<int> { ModContent.ItemType<Items.OcramBag>(), ModContent.ItemType<Items.CursedFang>(), ModContent.ItemType<Items.EoO>(), ModContent.ItemType<Items.DragonBreath>(), ModContent.ItemType<Items.EternityStaff>(), ModContent.ItemType<Items.SpectralArrow>(), ModContent.ItemType<Items.SoulofBlight>(), ModContent.ItemType<Items.AncientArmor.AncientDragonMask>(), ModContent.ItemType<Items.AncientArmor.AncientDragonBreastplate>(), ModContent.ItemType<Items.AncientArmor.AncientDragonGreaves>(), ModContent.ItemType<Items.AncientArmor.AncientTitanHelmet>(), ModContent.ItemType <Items.AncientArmor.AncientTitanMail>(), ModContent.ItemType <Items.AncientArmor.AncientTitanLeggings>(), ModContent.ItemType<Items.AncientArmor.AncientSpectralHeadgear>(), ModContent.ItemType <Items.AncientArmor.AncientSpectralArmor>(), ModContent.ItemType <Items.AncientArmor.AncientSpectralSubligar>(), ModContent.ItemType <Items.AncientArmor.AncientWarlockHood>(), ModContent.ItemType <Items.AncientArmor.AncientWarlockRobe>(), ModContent.ItemType <Items.AncientArmor.AncientWarlockLeggings>()},
                   "Use a [i:" + ModContent.ItemType<Items.SuspiciousLookingSkull>() + "] at night after all mechanical bosses has been defeated",
                   "Ocram disappears back into shadows!"
               );
            }          
        }
   
        #region RecipeGroups
        public override void AddRecipeGroups()
        {
            RecipeGroup group = new RecipeGroup(() => "Adamantite or Titanium Leggings " + Lang.GetItemNameValue(ItemType("")), new int[]
            {
               ItemID.AdamantiteLeggings,
               ItemID.TitaniumLeggings
            });
            RecipeGroup.RegisterGroup("Consolaria:AltAdamant3", group);

            group = new RecipeGroup(() => "Adamantite or Titanium Breastplate " + Lang.GetItemNameValue(ItemType("")), new int[]
            {
               ItemID.AdamantiteBreastplate,
               ItemID.TitaniumBreastplate
            });
            RecipeGroup.RegisterGroup("Consolaria:AltAdamant2", group);

            group = new RecipeGroup(() => "Adamantite or Titanium Helmet " + Lang.GetItemNameValue(ItemType("")), new int[]
            {
               ItemID.AdamantiteHelmet,
               ItemID.TitaniumHelmet
            });
            RecipeGroup.RegisterGroup("Consolaria:AltAdamant1", group);

            group = new RecipeGroup(() => "Cobalt or Palladium Leggings " + Lang.GetItemNameValue(ItemType("")), new int[]
            {
               ItemID.CobaltLeggings,
               ItemID.PalladiumLeggings
            });
            RecipeGroup.RegisterGroup("Consolaria:AltCobalt3", group);

            group = new RecipeGroup(() => "Cobalt or Palladium Breastplate " + Lang.GetItemNameValue(ItemType("")), new int[]
            {
               ItemID.CobaltBreastplate,
               ItemID.PalladiumBreastplate
            });
            RecipeGroup.RegisterGroup("Consolaria:AltCobalt2", group);

            group = new RecipeGroup(() => "Cobalt or Palladium Helmet" + Lang.GetItemNameValue(ItemType("")), new int[]
            {
               ItemID.CobaltHelmet,
               ItemID.PalladiumHelmet
            });
            RecipeGroup.RegisterGroup("Consolaria:AltCobalt1", group);

            group = new RecipeGroup(() => "Mythril or Orichalcum Greaves" + Lang.GetItemNameValue(ItemType("")), new int[]
            {
               ItemID.MythrilGreaves,
               ItemID.OrichalcumLeggings
            });
            RecipeGroup.RegisterGroup("Consolaria:AltMy3", group);

            group = new RecipeGroup(() => "Mythril or Orichalcum Chainmail" + Lang.GetItemNameValue(ItemType("")), new int[]
            {
               ItemID.MythrilChainmail,
               ItemID.OrichalcumBreastplate
            });
            RecipeGroup.RegisterGroup("Consolaria:AltMy2", group);

            group = new RecipeGroup(() => "Mythril or Orichalcum Helmet" + Lang.GetItemNameValue(ItemType("")), new int[]
            {
               ItemID.MythrilHelmet,
               ItemID.OrichalcumHelmet
            });
            RecipeGroup.RegisterGroup("Consolaria:AltMy1", group);

            group = new RecipeGroup(() => "Mythril or Orichalcum Helmet" + Lang.GetItemNameValue(ItemType("")), new int[]
            {
               ItemID.MythrilHat,
               ItemID.OrichalcumHelmet
            });
            RecipeGroup.RegisterGroup("Consolaria:ranged2", group);

            group = new RecipeGroup(() => "Adamantite or Titanium Helmet" + Lang.GetItemNameValue(ItemType("")), new int[]
            {
               ItemID.AdamantiteMask,
               ItemID.TitaniumHelmet
            });
            RecipeGroup.RegisterGroup("Consolaria:ranged3", group);

            group = new RecipeGroup(() => "Cobalt or Palladium Mask" + Lang.GetItemNameValue(ItemType("")), new int[]
            {
               ItemID.CobaltMask,
               ItemID.PalladiumMask
            });
            RecipeGroup.RegisterGroup("Consolaria:ranged1", group);

            group = new RecipeGroup(() => "Mythril or Orichalcum Headgear" + Lang.GetItemNameValue(ItemType("")), new int[]
           {
               ItemID.MythrilHood,
               ItemID.OrichalcumHeadgear
           });
            RecipeGroup.RegisterGroup("Consolaria:mag2", group);

            group = new RecipeGroup(() => "Adamantite or Titanium Headgear" + Lang.GetItemNameValue(ItemType("")), new int[]
            {
               ItemID.AdamantiteHeadgear,
               ItemID.TitaniumHeadgear
            });
            RecipeGroup.RegisterGroup("Consolaria:mag3", group);

            group = new RecipeGroup(() => "Cobalt or Palladium Headgear" + Lang.GetItemNameValue(ItemType("")), new int[]
            {
               ItemID.CobaltHat,
               ItemID.PalladiumHeadgear
            });
            RecipeGroup.RegisterGroup("Consolaria:mag1", group);

            group = new RecipeGroup(() => "Adamantite or Titanium Bar" + Lang.GetItemNameValue(ItemType("")), new int[]
           {
               ItemID.AdamantiteBar,
               ItemID.TitaniumBar
           });
            RecipeGroup.RegisterGroup("Consolaria:Adamant", group);
            #endregion

        }     

        #region Spawn
        public static bool NoInvasion(NPCSpawnInfo spawnInfo)
        {
            return !spawnInfo.invasion && ((!Main.pumpkinMoon && !Main.snowMoon) || spawnInfo.spawnTileY > Main.worldSurface || Main.dayTime) && (!Main.eclipse || spawnInfo.spawnTileY > Main.worldSurface || !Main.dayTime);
        }

        public static bool NoBiome(NPCSpawnInfo spawnInfo)
        {
            Player player = spawnInfo.player;
            return !player.ZoneJungle && !player.ZoneDungeon && !player.ZoneCorrupt && !player.ZoneCrimson && !player.ZoneHoly && !player.ZoneSnow && !player.ZoneUndergroundDesert;
        }

        public static bool NoZoneAllowWater(NPCSpawnInfo spawnInfo)
        {
            return !spawnInfo.sky && !spawnInfo.player.ZoneMeteor && !spawnInfo.spiderCave;
        }

        public static bool NoZone(NPCSpawnInfo spawnInfo)
        {
            return NoZoneAllowWater(spawnInfo) && !spawnInfo.water;
        }

        public static bool NormalSpawn(NPCSpawnInfo spawnInfo)
        {
            return !spawnInfo.playerInTown && NoInvasion(spawnInfo);
        }

        public static bool NoZoneNormalSpawn(NPCSpawnInfo spawnInfo)
        {
            return NormalSpawn(spawnInfo) && NoZone(spawnInfo);
        }

        public static bool NoZoneNormalSpawnAllowWater(NPCSpawnInfo spawnInfo)
        {
            return NormalSpawn(spawnInfo) && NoZoneAllowWater(spawnInfo);
        }

        public static bool NoBiomeNormalSpawn(NPCSpawnInfo spawnInfo)
        {
            return NormalSpawn(spawnInfo) && NoBiome(spawnInfo) && NoZone(spawnInfo);
        }
        #endregion
 
    }
}






