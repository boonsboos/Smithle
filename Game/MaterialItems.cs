namespace Game;

using System.Numerics;

public enum Material
{
	STONE,
	FLINT,
}

public class MaterialItem
{
	public Material mat;
	public BigInteger count;

	public MaterialItem(Material mat)
	{
		this.mat = mat;
	}
}