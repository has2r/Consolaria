using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Consolaria.Items
{
    public class CGlobalItem : GlobalItem
    {
        public override bool UseItem(Item item, Player player)
        {
            CPlayer modPlayer = player.GetModPlayer<CPlayer>();
         
            if (modPlayer.spectralGuard)
            {
                if (item.type == ItemID.LesserManaPotion || item.type == ItemID.ManaPotion || item.type == ItemID.GreaterManaPotion || item.type == ItemID.SuperManaPotion)
                {
                    for (int i = 0; i < 5 ; i++)
                    {
                        int z = Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, mod.ProjectileType("SpectralSpirit"), 100, 4f, player.whoAmI);
                        Main.projectile[z].hostile = false;
                        Main.projectile[z].friendly = true;
                    }
                }
            }
            return false;
        }
        public override bool ConsumeAmmo(Item item, Player player)
        {
            if (player.GetModPlayer<CPlayer>().dontConsumeAmmo15)
            {
                if (item.ranged)
                {
                    return Main.rand.NextFloat() >= .15f;
                }
            }
            return true;
        }
    }   
}

