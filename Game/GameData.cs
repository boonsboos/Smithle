namespace Game;

using Raylib_CsLo;

public class GameData
{
	public static GameMenu Menu = GameMenu.MAIN_MENU;
	public static Dictionary<GameMenu, IMenu> GameMenus = new(){
		{ GameMenu.MAIN_MENU,      new MainMenu() },
		{ GameMenu.SMITHY,       new SmithyMenu() },
		{ GameMenu.ACTION,       new ActionMenu() },
		{ GameMenu.UPGRADE,     new UpgradeMenu() },
		{ GameMenu.CREDITS,     new CreditsMenu() },
		{ GameMenu.INVENTORY, new InventoryMenu() }
	};

	public static Dictionary<GameAge, Age> GameAges = new(){
		{ GameAge.STONE, new StoneAge()}
	};

	public static Dictionary<Material, MaterialItem> MaterialInventory = new(){
		{ Material.STONE, new(Material.STONE) },
		{ Material.FLINT, new(Material.FLINT) },
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

		foreach (KeyValuePair<Material, MaterialItem> i in MaterialInventory) {
			buf += i.Key.ToString() + " x" + i.Value.count.ToString() + ";";
		}

		return buf;
	}

	private static string getProducts() {
		string buf = "";
		foreach (var i in ProductInventory) {
			buf += i.material.ToString() + i.type.ToString() + "(T${i.tier})"+ ";";
		}
		
		return buf;
	}

	public static void RefreshInventory()
	{
		Materials = getMaterialItems();
		Products = getProducts();
	}
}