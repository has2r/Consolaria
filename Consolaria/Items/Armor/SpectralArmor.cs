using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Consolaria.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class SpectralArmor : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 20, 0, 0);
            item.rare = 7;
            item.defense = 14;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spectral Armor");
            Tooltip.SetDefault("7% increased magical damage"+"\n4% increased magical critical strike chance" + "\nIncreases maximum mana by 50" + "\n'Ceremonial armor of a fabled mystic'");
        }
        public override void UpdateEquip(Player player)
        {
            player.magicCrit += 4;
            player.magicDamage += 0.07f;
            player.statManaMax2 += 50;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedPlateMail, 1);
            recipe.AddRecipeGroup("Consolaria:Adamant", 10);
            recipe.AddIngredient(ItemID.HellstoneBar, 5);
            recipe.AddIngredient(547, 15);
            recipe.AddIngredient(null, "SoulofBlight", 15);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}

