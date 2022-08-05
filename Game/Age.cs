namespace Game;

using System.Numerics;

public abstract class Age
{
	public float Progress  {get;set;}
	public float Gathering {get;set;}
	public float Forging   {get;set;}
	public abstract bool RefineMaterial();
	public abstract bool CanRefine();
	public abstract bool Forge();
	public abstract bool CanForge();
	public abstract bool CollectMaterials();
	public abstract BigInteger UpgradePrice();
}