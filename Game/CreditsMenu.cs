namespace Game;

using Raylib_CsLo;

public class CreditsMenu : IMenu
{
	private static Rectangle backButton = GameUtil.Button(30, 50);

	public void Draw()
	{
		GameUtil.DrawText(30, 16, "Credits", 32);

		if(RayGui.GuiButton(backButton, "Back"))
			GameData.Menu = GameMenu.MAIN_MENU;

		GameUtil.DrawText(30, 130, "Art:         Smertieboi, AMVKage, iLime", 32);
		GameUtil.DrawText(30, 162, "Concept:     Smertieboi", 32);
		GameUtil.DrawText(30, 194, "Programming: boons", 32);
		
	}
}