using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Consolaria.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class WarlockLeggings : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.rare = 7;
            item.value = Item.buyPrice(0, 15, 0, 0);
            item.defense = 9;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Warlock Leggings");
            Tooltip.SetDefault("8% increased movement speed and summon damage"+ "\nIncreases your max number of minions" + "\n'Ceremonial armor of a fabled summoner'");
        }
  
        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.08f;
            player.maxMinions += 1;
            player.minionDamage += 0.08f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedGreaves, 1);
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
