using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Consolaria.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class TitanHelmet : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.defense = 14;
            item.rare = 7;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Titan Helmet");
            Tooltip.SetDefault("15% increased ranged damage and critical strike chance" + "\n25% chance to not consume ammo" + "\n'Ceremonial armor of a fabled archer'");
        }

        public override void DrawArmorColor(Player drawPlayer, float shadow, ref Color color, ref int glowMask, ref Color glowMaskColor)
        {
            glowMask = GlowMask.TitanHelmet;
            glowMaskColor = Color.White;
        }

        public override void UpdateEquip(Player player)
        {
            player.rangedDamage += 0.15f;
            player.rangedCrit += 15;        
            player.ammoCost75 = true;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return (body.type == mod.ItemType("TitanMail") || body.type == mod.ItemType("AncientTitanMail")) && (legs.type == mod.ItemType("TitanLeggings") || legs.type == mod.ItemType("AncientTitanLeggings"));
        }

        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawOutlines = true;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Ranged damage crits cause stars to fall";
            player.GetModPlayer<CPlayer>().titanPower = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedHelmet, 1);
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
