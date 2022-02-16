using Terraria.ID;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using ReLogic.Localization.IME;
using Terraria.Localization;
using Microsoft.Xna.Framework;

namespace Consolaria.Items
{
    public class HolyHandgrenade : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 600;
            item.width = 26;
            item.height = 30;
            item.maxStack = 99;
            item.consumable = true;
            item.useStyle = 1;
            item.rare = 7;
            item.UseSound = SoundID.Item1;
            item.useAnimation = 50;
            item.useTime = 50;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.noUseGraphic = true;
            item.noMelee = true;
            item.shoot = mod.ProjectileType("HolyHandgrenade");
            item.shootSpeed = 4f;
        }
     
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Holy Hand Grenade");
            DisplayName.AddTranslation(GameCulture.Spanish, "Granada de mano sagrada");
            Tooltip.SetDefault("The Lord's chosen weapon");
            Tooltip.AddTranslation(GameCulture.Spanish, "El arma elegida del Señor");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Dynamite, 5);
            recipe.AddIngredient(ItemID.GoldBar, 2);
            recipe.AddIngredient(ItemID.BottledWater, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
