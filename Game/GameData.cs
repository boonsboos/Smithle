namespace Game;

using Raylib_CsLo;

public class GameData
{
	public static GameMenu Menu = GameMenu.MAIN_MENU;
	public static Dictionary<GameMenu, IMenu> GameMenus = new(){
		{ GameMenu.MAIN_MENU,      new MainMenu() },
		{ GameMenu.SMITHY,       new SmithyMenu() },
		{ GameMenu.UPGRADE,     new UpgradeMenu() },
		{ GameMenu.CREDITS,     new CreditsMenu() },
		{ GameMenu.INVENTORY, new InventoryMenu() }
	};

	public static Dictionary<GameAge, Age> GameAges = new(){
		{ GameAge.STONE, new StoneAge()}
	};

	public List<InventoryItem> inventory = new(){
		new Stone(), new Flint(),
	};

	public static GameAge Age = GameAge.STONE;
	public static Font SmithleFont = Raylib.LoadFont("Assets/FreePixel.ttf");

	// TODO: load from config
	// TODO: add more fields
}