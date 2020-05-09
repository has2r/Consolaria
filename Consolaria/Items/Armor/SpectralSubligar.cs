using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Consolaria.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class SpectralSubligar : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.rare = 7;
            item.value = Item.sellPrice(0, 15, 0, 0);
            item.defense = 10;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spectral Subligar");
            Tooltip.SetDefault("12% increased movement speed" + "\n6% increased magical damage" + "\nIncreases maximum mana by 30" + "\n'Ceremonial armor of a fabled mystic'");
        }
        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.12f;
            player.magicDamage += 0.06f;
            player.statManaMax2 += 30;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedGreaves, 1);
            recipe.AddRecipeGroup("Consolaria:Adamant", 10);
            recipe.AddIngredient(ItemID.HellstoneBar, 5);
            recipe.AddIngredient(547, 10);
            recipe.AddIngredient(null, "SoulofBlight", 10);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
