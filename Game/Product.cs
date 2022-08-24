namespace Game;

using System.Numerics;

public enum ProductType
{
	DAGGER,
	ARROW,
	SPEAR,
	// bronze
	SHORTSWORD,
	AXE,
	BRACELET,
	PICKAXE,
	// iron
	LONGSWORD,
	NECKLACE,
	BATTLEAX,
	HAMMER,
	// classical
}

public class Product
{
	public Material material;
	public ProductType type;
	public float quality;
	public byte tier = 0;

	public Product(Material m, ProductType t, float q) {
		material = m;
		type = t;
		quality = q;
	}

	public Product(Material m, ProductType t, float q, byte tr) {
		material = m;
		type = t;
		quality = q;
		tier = tr;
	}

	public string GetName()
	{
		return material.ToString() + " " + type.ToString().ToLower();
	}

	public string GetQuality()
	{
		return "Quality: " + quality.ToString();
	}

	public string GetTier()
	{
		return "Tier: T" + tier.ToString();
	}
}