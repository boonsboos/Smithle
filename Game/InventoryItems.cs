namespace Game;

using System.Numerics;

public abstract class InventoryItem
{
	public const string name = "";
	public BigInteger count {get; set;}
}

public class Stone : InventoryItem
{
	new public const string name = "Stone";
}

public class Flint : InventoryItem
{
	new public const string name = "Flint";
}