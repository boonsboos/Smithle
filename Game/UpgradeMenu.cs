namespace Game;

using Raylib_CsLo;

public class UpgradeMenu : IMenu
{
	private static Rectangle backButton = new(30, 50, 160, 60);

	public void Draw()
	{
		GameUtil.DrawText(30, 16, "Upgrade", 32);

		if (RayGui.GuiButton(backButton, "Back"))
			GameData.Menu = GameMenu.SMITHY;
		
		// TODO upgrades.
	}
}