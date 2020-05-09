using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Consolaria.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class DragonBreastplate : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.defense = 26;
            item.value = Item.sellPrice(0, 20, 0, 0);
            item.rare = 7;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dragon Breastplate");
            Tooltip.SetDefault("10% increased melee critical strike chance" + "\n5% increased melee damage" + "\n'Ceremonial armor of a fabled warrior'");
        }

        public override void UpdateEquip(Player player)
        {
            player.meleeCrit += 10;
            player.meleeDamage += 0.05f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedPlateMail, 1);
            recipe.AddRecipeGroup("Consolaria:Adamant", 10);
            recipe.AddIngredient(ItemID.HellstoneBar, 5);
            recipe.AddIngredient(548, 15);
            recipe.AddIngredient(null, "SoulofBlight", 15);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}

