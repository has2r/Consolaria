using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Consolaria.Items
{
    public class SpicySauce : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 38;
            item.thrown = true;
            item.width = 32;
            item.height = 32;
            item.maxStack = 999;
            item.noUseGraphic = true;
            item.consumable = true;
            item.autoReuse = false;
            item.useTime = 20;
            item.useAnimation = 20;
            item.shoot = mod.ProjectileType("SpicySauce");
            item.shootSpeed = 10f;
            item.useStyle = 1;
            item.knockBack = 1;
            item.UseSound = SoundID.Item87;
            item.value = Item.sellPrice(0, 0, 20, 0);
            item.rare = 3;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spicy Sauce");
            Tooltip.SetDefault("Affected enemies take additional damage from fire");
        }
    }
}
