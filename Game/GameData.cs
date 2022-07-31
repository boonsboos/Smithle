namespace Game;

using Raylib_CsLo;
using System.Numerics;

public class GameData
{
	public static GameMenu Menu = GameMenu.MAIN_MENU;
	public static Dictionary<GameMenu, IMenu> GameMenus = new(){
		{ GameMenu.MAIN_MENU,      new MainMenu() },
		{ GameMenu.DASHBOARD, new DashboardMenu() },
		{ GameMenu.ACTION,       new ActionMenu() },
		{ GameMenu.UPGRADE,     new UpgradeMenu() },
		{ GameMenu.CREDITS,     new CreditsMenu() },
		{ GameMenu.INVENTORY, new InventoryMenu() }
	};

	public static Dictionary<GameAge, Age> GameAges = new(){
		{ GameAge.STONE, new StoneAge()}
	};

	public static Dictionary<Material, BigInteger> MaterialInventory = new(){
		{ Material.STONE, new() },
		{ Material.FLINT, new() },
	};
	public static string Materials = getMaterialItems();

	public static List<Product> ProductInventory = new();
	public static string Products = getProducts();

	public static GameAge Age = GameAge.STONE;
	public static Font SmithleFont = Raylib.LoadFont("Assets/FreePixel.ttf");

	// TODO: load from config
	// TODO: add more fields

	private static string getMaterialItems() {
		string buf = "";

		foreach (KeyValuePair<Material, BigInteger> i in MaterialInventory)
			buf += $"{i.Key.ToString()} x {i.Value.ToString()};";
		
		return buf;
	}

	private static string getProducts() {
		string buf = "";
		if (ProductInventory.Count() == 0) return buf;

		Product lastProduct = ProductInventory.Last<Product>();

		foreach (var i in ProductInventory) {
			if (i != lastProduct)
			{
				buf += $"{i.material.ToString()} {i.type.ToString().ToLower()};";
			} else 
			{
				buf += $"{i.material.ToString()} {i.type.ToString().ToLower()}";
			}
		}
		
		return buf;
	}

	public static void RefreshInventory()
	{
		Materials = getMaterialItems();
		Products = getProducts();
	}
}