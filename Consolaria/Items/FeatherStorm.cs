using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System;

namespace Consolaria.Items
{
    class FeatherStorm : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Feather Storm");
            Tooltip.SetDefault("");
        }     
        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 30;
            item.magic = true;
            item.autoReuse = true;
            item.mana = 8;
            item.damage = 20;
            item.crit = 4;
            item.knockBack = 6;
            item.rare = 3;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 5;
            item.UseSound = SoundID.Item42;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.shoot = mod.ProjectileType("Feather");
            item.shootSpeed = 6f;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int ShotAmt = 3;
            int spread = 3;
            float spreadMult = 0.5f;

            Vector2 vector2 = new Vector2();

            for (int i = 0; i < ShotAmt; i++)
            {
                float vX = 2 * speedX + Main.rand.Next(-spread, spread + 1) * spreadMult;
                float vY = 2 * speedY + Main.rand.Next(-spread, spread + 1) * spreadMult;

                float angle = (float)Math.Atan(vY / vX);
                vector2 = new Vector2(position.X + 90f * (float)Math.Cos(angle), position.Y + 90f * (float)Math.Sin(angle));
                float mouseX = Main.mouseX + Main.screenPosition.X;
                if (mouseX < player.position.X)
                {
                    vector2 = new Vector2(position.X - 90f * (float)Math.Cos(angle), position.Y - 90f * (float)Math.Sin(angle));
                }

                Projectile.NewProjectile(vector2.X, vector2.Y, vX, vY, mod.ProjectileType("Feather"), damage, knockBack, Main.myPlayer);

            }
            return false;
        }
    }
}
