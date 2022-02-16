using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using ReLogic.Localization.IME;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Consolaria.Items
{
	public class Sharanga : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 36;
			item.width = 18;
			item.height = 56;
			item.ranged = true;
			item.useTime = 20;
			item.useAnimation = 20;
			item.shoot = 1;
			item.shootSpeed = 8f;
			item.useStyle = 5;
			item.knockBack = 2;
			item.value = Item.sellPrice(0, 0, 80, 0);
			item.useAmmo = AmmoID.Arrow;
			item.rare = 3;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sharanga");
			DisplayName.AddTranslation(GameCulture.Spanish, "Sharanga");
			Tooltip.SetDefault("Transforms any suitable ammo into Spectral Arrows");
			Tooltip.AddTranslation(GameCulture.Spanish, "Transforma cualquier munición adecuada en flechas espectrales");
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = mod.ProjectileType("SpectralArrowPro");
			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MoltenFury, 1);
			recipe.AddIngredient(ItemID.DemonBow, 1);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MoltenFury, 1);
			recipe.AddIngredient(ItemID.TendonBow, 1);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
