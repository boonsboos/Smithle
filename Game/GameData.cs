namespace Game;

using Raylib_CsLo;
using System.Numerics;

// ah yes, the singleton pattern
// this class contains all the data the game is operating on
public class GameData
{
	public static GameMenu Menu = GameMenu.MAIN_MENU;
	public static Dictionary<GameMenu, IMenu> GameMenus = new(){
		{ GameMenu.MAIN_MENU,      new MainMenu() },
		{ GameMenu.DASHBOARD, new DashboardMenu() },
		{ GameMenu.ACTION,       new ActionMenu() },
		{ GameMenu.SKILL,         new SkillMenu() },
		{ GameMenu.CREDITS,     new CreditsMenu() },
		{ GameMenu.INVENTORY, new InventoryMenu() },
		{ GameMenu.PRESTIGE,   new PrestigeMenu() }
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

	// Upgradable Skills
	public static float GatherSpeed   = 0;
	public static int   GatherSkill   = 0;
	public static float RefineSpeed   = 0;
	public static int   RefineSkill   = 0;
	public static float ForgingSpeed  = 0;
	public static int   ForgingSkill  = 0;
	public static float PolishSpeed   = 0;
	public static int   PolishSkill   = 0;

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
				buf += $"{i.material.ToString()} {i.type.ToString().ToLower()};";
			else
				buf += $"{i.material.ToString()} {i.type.ToString().ToLower()}";
				// no extra semicolon so there won't be an empty list element
		}
		
		return buf;
	}

	public static async void RefreshInventory()
	{
		await Task.Run(() => {
			Materials = getMaterialItems();
			Products = getProducts();
		});
		
	}

	public static float CalculateQuality()
	{
		float quality = (float) Math.Log(1 * new Random().NextDouble(), .1);

		if (quality > 50) {
			quality -= (50 - ForgingSkill); // apply skill
		}

		return (float) ((int) (quality * 10000)) / 100; // float int cast hack for decimal points
	}
}