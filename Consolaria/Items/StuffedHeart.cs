using Microsoft.Xna.Framework;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Consolaria.Items
{
    public class StuffedHeart : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stuffed Heart");
            Tooltip.SetDefault("Summons Turkor the Ungrateful \nNo Turkey Feather needed");
        }

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 28;
            item.maxStack = 20;
            item.value = Item.sellPrice(0, 0, 1, 0);
            item.rare = 3;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useStyle = 4;
            item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(mod.NPCType("TurkortheUngrateful"));
        }

        public override bool UseItem(Player player)
        {
            Main.PlaySound(SoundID.Roar, player.position, 0);
            int SpawnPoint = Main.rand.Next(-250, 250);
            if (Main.netMode != 1)
            {
                Helper.NewNPC(player.Center + new Vector2(SpawnPoint, -35f), "TurkortheUngrateful").netUpdate = true;
            }
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "CursedStuffing", 1);
            recipe.AddIngredient(ItemID.Cobweb, 5);
            recipe.AddIngredient(ItemID.Feather, 1);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}