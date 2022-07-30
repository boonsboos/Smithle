namespace Game;

using Raylib_cs;

public class GameData
{
	public static GameMenu menu = GameMenu.MAIN_MENU;
	public static Dictionary<GameMenu, Menu> Menus = new(){
		{ GameMenu.MAIN_MENU, new MainMenu() } ,
		{ GameMenu.SMITHY,    new Smithy() }
	};
	public static GameAge Age = GameAge.STONE;

	public static Font SmithleFont = Raylib.LoadFont("Assets/FreePixel.ttf");

	// TODO: load from config
	// TODO: add more fields
}