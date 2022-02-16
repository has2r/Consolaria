using Terraria;
using Terraria.ID;
using ReLogic.Localization.IME;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Consolaria.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class SpectralHeadgear : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.defense = 12;
            item.rare = 7;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spectral Headgear");
            DisplayName.AddTranslation(GameCulture.Spanish, "Tocado de Espectro");
            Tooltip.SetDefault("5% increased magical damage" + "\n5% increased magical critical strike chance" + "\nIncreases maximum mana by 70" + "\n'Ceremonial armor of a fabled mystic'");
            Tooltip.AddTranslation(GameCulture.Spanish, "5% aumento de daño mágico" + "\n5% aumento de probabilidad de golpe crítico mágico" + "\nAumenta el maná máximo en 70" + "\n'Armadura ceremonial de un místico legendario'");
        }
        public override void UpdateEquip(Player player)
        {
            player.magicCrit += 5;
            player.magicDamage += 0.05f;
            player.statManaMax2 += 70;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return (body.type == mod.ItemType("SpectralArmor") || body.type == mod.ItemType("AncientSpectralArmor")) && (legs.type == mod.ItemType("SpectralSubligar") || legs.type == mod.ItemType("AncientSpectralSubligar"));
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Drinking a Mana Potion unleashes a barrage of homing spirit bolts";
            player.GetModPlayer<CPlayer>().spectralGuard = true;
            Lighting.AddLight((int)((player.position.X) / 16.0), (int)((player.position.Y) / 16.0), 0.4f, 0.4f, 0.9f);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedHeadgear, 1);
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
