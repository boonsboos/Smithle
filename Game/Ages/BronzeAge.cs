namespace Game;

using Raylib_CsLo;
using System.Numerics;

public class BronzeAge : Age
{
	// index of allowed to refine, rest is for forging
	private static int allowedR = 3; 
	private static List<Material> allowedM = new(){
		Material.TIN,
		Material.CARBON,
		Material.COPPER,
		Material.BRONZE,
	};

	private static List<ProductType> allowedP = new(){
		ProductType.DAGGER,
		ProductType.SPEAR,
		ProductType.ARROW,
		ProductType.AXE,
		ProductType.SHORTSWORD,
		ProductType.BRACELET,
	};

	private static Material m;
	private static Random r = new();

	public override bool RefineMaterial()
	{
		if (Progress < 5) {
			Progress += Raylib.GetFrameTime() + GameData.RefineSpeed;
			return false;
		}

		Progress = 0;

		GameData.MaterialInventory[Material.STONE]--;
		
		// if the refine skill is >1, use it, otherwise, roll once.
		for (int i = 0; i < (GameData.RefineSkill > 1 ? GameData.RefineSkill : 1); i++) {
			GameData.MaterialInventory[allowedM[r.Next(0, allowedR)]]++;
		}

		return true;
	}

	public override bool CanRefine()
	{
		return GameData.MaterialInventory[Material.STONE] > 0;
	}

	public override bool Forge()
	{
		if (Forging < 8) {
			Forging += Raylib.GetFrameTime() + GameData.ForgingSpeed;
			return false;
		}

		Forging = 0;
		
		// we've prerolled the material we're using in CanForge
		GameData.ProductInventory.Add(new Product(
			m,
			allowedP[r.Next(0, allowedP.Count())],
			GameData.CalculateQuality()
		));
		GameData.MaterialInventory[m]--;
		return true;
	}

	public override bool CanForge()
	{
		foreach (var a in allowedM) {
			m = allowedM[r.Next(0, allowedM.Count())];
			if (GameData.MaterialInventory[m] != 0)
				return true;
		}
		return false;
	}

	public override bool CollectMaterials()
	{
		if (Gathering < 5) {
			Gathering += Raylib.GetFrameTime() + GameData.GatherSpeed;
			return false;
		}

		if (r.NextSingle() > 0.10)
			GameData.MaterialInventory[Material.STONE] += (GameData.GatherSkill > 1 ? r.Next(0, GameData.GatherSkill) : 1);

		Gathering = 0;
		return true;
	}

	public override BigInteger UpgradePrice()
	{
		return new BigInteger(2);
	}
}