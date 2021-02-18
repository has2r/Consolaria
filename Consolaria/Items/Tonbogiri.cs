using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Consolaria.Items
{
    public class Tonbogiri : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tonbogiri");
            Tooltip.SetDefault("Inflicts enemies with Acid Venom");
        }
        public override void SetDefaults()
        {
            item.damage = 55;
            item.width = 70;
            item.height = 70;
            item.noUseGraphic = true;
            item.melee = true;
            item.useTime = 15;
            item.useAnimation = 15;
            item.shoot = mod.ProjectileType("TonbogiriSpear");
            item.shootSpeed = 8f;
            item.useStyle = 5;
            item.knockBack = 14;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = 7;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.noMelee = true;
        }
        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[item.shoot] < 1;
        }

        private float[] rads = new float[]
        {
            0.5f,
            -0.5f      
        };
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            for (int i = 0; i < 2; i++)
            {
                float ai = 1f;
                if (i > 1)
                {
                    ai = 0.5f;
                }
                Vector2 vector = new Vector2(speedX, speedY);
                vector = vector.RotatedBy(rads[i], default(Vector2));
                Projectile.NewProjectile(player.position * 1.2f, vector, mod.ProjectileType("TonbogiriSpiritSpear"), damage, knockBack, player.whoAmI, 0f, ai);
            }
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Gungnir, 1);
            recipe.AddRecipeGroup("Consolaria:Adamant", 10);
            recipe.AddIngredient(ItemID.HellstoneBar, 5);
            recipe.AddIngredient(null, "SoulofBlight", 15);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
