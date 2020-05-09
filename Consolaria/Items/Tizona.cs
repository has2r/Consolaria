using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Consolaria.Items
{
    public class Tizona : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 60;
            item.melee = true;
            item.width = 24;
            item.height = 28;
            item.useTime = 26;
            item.useAnimation = 26;
            item.useStyle = 1;
            item.knockBack = 5;
            item.shoot = mod.ProjectileType("TizonaSkull");
            item.shootSpeed = 8f;
            item.value = Item.sellPrice(0, 6, 0, 0);
            item.rare = 7;
            item.UseSound = SoundID.Item79;
            item.autoReuse = true;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tizona");
            Tooltip.SetDefault("Shoots a cursed skull");
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            switch (Main.rand.Next(2))
            {
                case 0:
                    type = 0;
                    break;
                default:
                    type = mod.ProjectileType("TizonaSkull");
                    break;
            }
            return true;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(2) == 0)
            {
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, mod.DustType("TizonaDust"));
            }
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Excalibur, 1);
            recipe.AddRecipeGroup("Consolaria:Adamant", 10);
            recipe.AddIngredient(ItemID.HellstoneBar, 5);
            recipe.AddIngredient(null, "SoulofBlight", 15);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {           
            if (Main.rand.Next(2) == 0)
            {
                target.AddBuff(mod.BuffType("SpectralFlame"), 240);
            }           
        }
    }
}
