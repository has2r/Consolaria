using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Consolaria.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class DragonMask : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.defense = 20;
            item.rare = 7;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dragon Mask");
            Tooltip.SetDefault("10% increased melee speed and damage" + "\n15% increased melee critical strike chance" + "\n'Ceremonial armor of a fabled warrior'");
        }

        public override void UpdateEquip(Player player)
        {
            player.meleeCrit += 15;
            player.meleeDamage += 0.1f;
            player.meleeSpeed += 0.1f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return (body.type == mod.ItemType("DragonBreastplate") || body.type == mod.ItemType("AncientDragonBreastplate")) && (legs.type == mod.ItemType("DragonGreaves") || legs.type == mod.ItemType("AncientDragonGreaves"));
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Creates a burst of flames when injured";
            player.GetModPlayer<CPlayer>().dragonExplosion = true;
            Lighting.AddLight((int)((player.position.X) / 16.0), (int)((player.position.Y) / 16.0), 0.4f, 0.4f, 0.9f);
        }

        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawShadow = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedMask, 1);
            recipe.AddRecipeGroup("Consolaria:Adamant", 10);
            recipe.AddIngredient(ItemID.HellstoneBar, 5);
            recipe.AddIngredient(548, 10);
            recipe.AddIngredient(null, "SoulofBlight", 10);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
