namespace Game;

public abstract class Age
{
	public float Progress {get; set;}
	public float Gathering {get;set;}
	protected bool locked {get;set;}
	public abstract bool PerformAction();
	public abstract bool CanPerform();
	public abstract bool CollectMaterials();
}