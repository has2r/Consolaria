using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using ReLogic.Localization.IME;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Consolaria.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class TitanLeggings : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 18;
            item.rare = 7;
            item.defense = 13;
            item.value = Item.sellPrice(0, 15, 0, 0);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Titan Leggings");
            DisplayName.AddTranslation(GameCulture.Spanish, "Grebas de Titán");
            Tooltip.SetDefault("10% increased movement speed and ranged damage" + "\n15% chance to not consume ammo" + "\n'Ceremonial armor of a fabled archer'");
            Tooltip.AddTranslation(GameCulture.Spanish, "10% Incrementado la Velocidad de movimiento y rango de Daño" + "\n15% de Probabilidad de No Consumir Munición" + "\n'Armadura ceremonial de un arquero legendario'");
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.1f;
            player.rangedDamage += 0.1f;
            player.GetModPlayer<CPlayer>().dontConsumeAmmo15 = true;
        }

        public override void DrawArmorColor(Player drawPlayer, float shadow, ref Color color, ref int glowMask, ref Color glowMaskColor)
        {
            glowMask = GlowMask.TitanLeggings;
            glowMaskColor = Color.White;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedGreaves, 1);
            recipe.AddRecipeGroup("Consolaria:Adamant", 10);
            recipe.AddIngredient(ItemID.HellstoneBar, 5);
            recipe.AddIngredient(549, 10);
            recipe.AddIngredient(null, "SoulofBlight", 10);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
