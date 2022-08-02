namespace Game;

using System.Numerics;
using Raylib_CsLo;

public class StoneAge : Age
{
	private static List<ProductType> allowed = new() {
		ProductType.DAGGER,
		ProductType.ARROW,
		ProductType.SPEAR
	};

	private static int randomType()
	{
		return new Random().Next(0, 3);
	}

	public override bool RefineMaterial()
	{
		if (Progress < 5) {
			Progress += Raylib.GetFrameTime() + GameData.RefineSpeed;
			return false;
		}

		Progress = 0;

		GameData.MaterialInventory[Material.STONE]--;
		GameData.MaterialInventory[Material.FLINT]++;
		return true;
	}

	public override bool Forge()
	{
		if (Forging < 8) {
			Forging += Raylib.GetFrameTime() + GameData.ForgingSpeed;
			return false;
		}

		Forging = 0;

		GameData.ProductInventory.Add(new Product(
			Material.FLINT,
			allowed[randomType()],
			GameData.CalculateQuality()
		));
		GameData.MaterialInventory[Material.FLINT]--;
		return true;
	}

	public override bool CanRefine()
	{
		return GameData.MaterialInventory[Material.STONE] > 0;
	}

	public override bool CanForge()
	{
		return GameData.MaterialInventory[Material.FLINT] > 0;
	}

	public override bool CollectMaterials()
	{
		if (Gathering < 5) {
			Gathering += Raylib.GetFrameTime() + GameData.GatherSpeed;
			return false;
		}

		if (new Random().NextSingle() > 0.10)
			GameData.MaterialInventory[Material.STONE]++;

		Gathering = 0;
		return true;
	}

	public override BigInteger UpgradePrice()
	{
		return BigInteger.Zero;
	}
}