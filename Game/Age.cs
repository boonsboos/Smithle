namespace Game;

public abstract class Age
{
	public float Progress  {get;set;}
	public float Gathering {get;set;}
	public float Forging   {get;set;}
	public abstract bool RefineMaterial();
	public abstract bool CanPerform();
	public abstract bool Forge();
	public abstract bool CollectMaterials();
}