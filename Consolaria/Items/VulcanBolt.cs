using Terraria.ID;
using Terraria.ModLoader;
using ReLogic.Localization.IME;
using Terraria.Localization;


namespace Consolaria.Items
{
    public class VulcanBolt : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 12;
            item.ranged = true;
            item.width = 26;
            item.maxStack = 999;
            item.consumable = true;
            item.height = 30;
            item.shoot = mod.ProjectileType("VulcanBoltPro");
            item.shootSpeed = 22f;
            item.knockBack = 9;
            item.value = 50;
            item.rare = 7;
            item.ammo = AmmoID.Arrow;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vulcan Bolt");
            DisplayName.AddTranslation(GameCulture.Spanish, "Relámpago volcánico");
            Tooltip.SetDefault("");
            Tooltip.AddTranslation(GameCulture.Spanish, "");
        }
    }
}
