namespace Game;

using Raylib_CsLo;
using System.Numerics;

public class MainMenu : IMenu
{
	private static Rectangle playButton = GameUtil.Button(30, 210);
	private static Rectangle credButton = GameUtil.Button(30, 290);

	public void Draw() 
	{
		GameUtil.DrawText(30, 50, "Smithle", 72);

		GameUtil.DrawText(30, 120,
			"a game by boons and Smertieboi", 32.0f);

		if (RayGui.GuiButton(playButton, "Play"))
			GameData.Menu = GameMenu.SMITHY;
		
		if (RayGui.GuiButton(credButton, "Credits"))
			GameData.Menu = GameMenu.CREDITS;
	}
}