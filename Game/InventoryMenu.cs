namespace Game;

using Raylib_CsLo;
using System.Numerics;

public class InventoryMenu : IMenu
{
	private static Rectangle backButton = GameUtil.Button(30, 50);

	public void Draw()
	{
		if (RayGui.GuiButton(backButton, "Back"))
			GameData.Menu = GameMenu.SMITHY;

		RayGui.GuiScrollPanel(GameUtil.Button(30, 130), new Rectangle(30, 130, 500, 500), new* Vector2(30, 40));
		// TODO: render it dynamically
	}
}