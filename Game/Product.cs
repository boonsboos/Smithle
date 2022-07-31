namespace Game;

using System.Numerics;

public enum ProductType
{
	DAGGER,
	ARROWHEAD,
	SPEARHEAD,
}

public class Product
{
	public Material material;
	public ProductType type;
	public float quality;
	public byte tier;

	public Product(Material m, ProductType t, float q) {
		material = m;
		type = t;
		quality = q;
	}
}