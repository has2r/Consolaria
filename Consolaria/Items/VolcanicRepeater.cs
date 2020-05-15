using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Consolaria.Items
{
	public class VolcanicRepeater : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 45;
			item.width = 18;
			item.height = 56;
			item.ranged = true;
			item.useTime = 4;
			item.useAnimation = 12;
			item.reuseDelay = 18;
			item.shoot = 1;
			item.shootSpeed = 15;
			item.useStyle = 5;
			item.knockBack = 2.5f;
			item.value = Item.sellPrice(0, 5, 0, 0);
			item.useAmmo = AmmoID.Arrow;
			item.rare = 7;
			item.UseSound = SoundID.Item70;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Vulcan Repeater");
			Tooltip.SetDefault("Transforms any suitable ammo into Vulcan Bolts");
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = mod.ProjectileType("VulcanBoltPro");
			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-5, 0);
		}

		public override bool ConsumeAmmo(Player player)
		{           
			return (player.itemAnimation < item.useAnimation - 2);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HallowedRepeater, 1);
			recipe.AddRecipeGroup("Consolaria:Adamant", 10);
			recipe.AddIngredient(ItemID.HellstoneBar, 5);
			recipe.AddIngredient(null, "SoulofBlight", 15);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();          
		}
	}
}
