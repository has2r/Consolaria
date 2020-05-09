using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Consolaria.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class WarlockRobe : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.buyPrice(0, 20, 0, 0);
            item.rare = 7;
            item.defense = 9;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Warlock Robe");
            Tooltip.SetDefault("9% increased minion damage\nIncreases your max number of minions" + "\n'Ceremonial armor of a fabled summoner'");
        }

        public override void DrawHands(ref bool drawHands, ref bool drawArms)
        {
            drawHands = true;
        }

        public override bool DrawLegs()
        {
            return false;
        }

        public override void UpdateEquip(Player player)
        {
            player.maxMinions += 1;
            player.minionDamage += 0.09f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedPlateMail, 1);
            recipe.AddRecipeGroup("Consolaria:Adamant", 10);
            recipe.AddIngredient(ItemID.HellstoneBar, 5);
            recipe.AddIngredient(521, 5);
            recipe.AddIngredient(520, 5);
            recipe.AddIngredient(null, "SoulofBlight", 10);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}

