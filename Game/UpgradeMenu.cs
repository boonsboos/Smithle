namespace Game;

using Raylib_CsLo;

public class UpgradeMenu : IMenu
{
	private static Rectangle backButton = new(30, 50, 160, 60);

	public void Draw()
	{
		if (RayGui.GuiButton(backButton, "Back"))
			GameData.Menu = GameMenu.SMITHY;
		
		// TODO upgrades.
	}
}