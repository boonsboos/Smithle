namespace Game;

using Raylib_CsLo;

public class PrestigeMenu : IMenu
{
	private static Rectangle backButton     = GameUtil.Button(30, 50);
	private static Rectangle prestigeButton = new(500, 300, 300, 200);

	public void Draw()
	{
		GameUtil.DrawText(30, 16, "Prestige", 32);

		if (RayGui.GuiButton(backButton, "Back"))
			GameData.Menu = GameMenu.DASHBOARD;

		if (RayGui.GuiButton(prestigeButton, "Prestige"))
			GameData.Age++;
	}
}