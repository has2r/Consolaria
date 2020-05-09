using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Consolaria.Items
{
    public class EoO : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 60;
            item.crit = 10;
            item.magic = true;
            item.width = 34;
            item.height = 34;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 5;
            item.knockBack = 2;
            item.value = Item.buyPrice(0, 5, 0, 0);
            item.rare = 7;
            item.mana = 8;
            item.useStyle = 5;
            item.UseSound = SoundID.Item33;
            item.noMelee = true;
            item.autoReuse = true;
            item.shoot = ProjectileID.PurpleLaser;
            item.shootSpeed = 20f;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            switch (Main.rand.Next(2))
            {
                case 0:
                    type = ProjectileID.PurpleLaser;
                    break;
                default:
                    item.shootSpeed = 5f;
                    type = ProjectileID.DemonScythe;
                    break;
            }
            return true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eye of Ocram");
            Tooltip.SetDefault("");
        }
    }
}
