namespace Game;

using Raylib_CsLo;

public class MainMenu : IMenu
{
	private static Rectangle playButton = GameUtil.Button(30, 210);
	private static Rectangle credButton = GameUtil.Button(30, 290);

	public void Draw() 
	{
		GameUtil.DrawText(30, 50, "Smithle", 72);

		GameUtil.DrawText(30, 120, "by monkegame", 32);

		if (RayGui.GuiButton(playButton, "Play"))
			GameData.Menu = GameMenu.DASHBOARD;
		
		if (RayGui.GuiButton(credButton, "Credits"))
			GameData.Menu = GameMenu.CREDITS;
	}
}