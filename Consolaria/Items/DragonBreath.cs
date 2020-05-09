using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Consolaria.Items
{
    public class DragonBreath : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 45;
            item.ranged = true;
            item.width = 28;
            item.height = 30;
            item.useTime = 3;
            item.useAnimation = 18;
            item.useAmmo = AmmoID.Gel;
            item.shoot = mod.ProjectileType("SpectralFlames");
            item.shootSpeed = 8f;
            item.value = Item.buyPrice(0, 25, 0, 0);
            item.value = Item.sellPrice(0, 15, 50, 0);
            item.useStyle = 5;
            item.knockBack = 4;
            item.rare = 7;
            item.UseSound = SoundID.Item24;
            item.autoReuse = true;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dragon's Breath");
            Tooltip.SetDefault("'Shoots Spectral Flames'\n'70% chance to not consume gel'");
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int num = Main.rand.Next(1, 4);
            for (int i = 0; i < num; i++)
            {
                float speedX2 = speedX + Main.rand.Next(-15, 15) * 0.05f;
                float speedY2 = speedY + Main.rand.Next(-15, 15) * 0.05f;
                Projectile.NewProjectile(position.X, position.Y, speedX2, speedY2, type, damage, knockBack, player.whoAmI, 0f, 0f);
            }
            return false;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2?(new Vector2(-6f, 0f));
        }
        public override bool ConsumeAmmo(Player player)
        {
            if (Main.rand.Next(0, 100) <= 70)
            {
                return false;
            }
            return true;
        }     
    }
} 
