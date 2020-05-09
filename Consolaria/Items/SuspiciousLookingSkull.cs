using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Consolaria.Items
{
    public class SuspiciousLookingSkull : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Suspicious Looking Skull");
            Tooltip.SetDefault("Summons Ocram");
        }
        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 28;
            item.maxStack = 20;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = 6;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useStyle = 4;
            item.consumable = true;
        }
        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime && !NPC.AnyNPCs(mod.NPCType("Ocram"));
        }
        public override bool UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("Ocram"));
            Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/OcramRoar"), player.position);
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("Consolaria:Adamant", 5);
            recipe.AddIngredient(ItemID.HellstoneBar, 5);
            recipe.AddIngredient(ItemID.Bone, 10);
            recipe.AddIngredient(ItemID.SoulofFright, 5);
            recipe.AddIngredient(ItemID.SoulofMight, 5);
            recipe.AddIngredient(ItemID.SoulofSight, 5);
            recipe.AddTile(26);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}