using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Consolaria.Items
{
    public class GreatDrumstick : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 30;
            item.melee = true;
            item.autoReuse = false;
            item.width = 38;
            item.height = 42;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = 1;
            item.knockBack = 8;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = 3;
            item.UseSound = SoundID.Item95;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Great Drumstick");
            Tooltip.SetDefault("'I just want those crunchies'" + "\nCan hit enemies with spicy sauce");
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(2) == 0)
            {
                target.AddBuff(mod.BuffType("HotSauce"), 300);
            }
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(2) == 0)
            {
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 5, 0, 0, 0, default);
            }
        }      
    }
}
