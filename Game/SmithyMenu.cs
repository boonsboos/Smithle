namespace Game;

using Raylib_CsLo;

public class SmithyMenu : IMenu
{
	private static Rectangle actionButton    = GameUtil.Button(30, 50);
	private static Rectangle tradeButton     = GameUtil.Button(30, 130);
	private static Rectangle upgradeButton   = GameUtil.Button(30, 210);
	private static Rectangle inventoryButton = GameUtil.Button(30, 290);

	private static Rectangle progressBar   = new(30, 660, 1220, 30);

	private bool performingAction;

	public void Draw()
	{
		GameUtil.DrawText(30.0f, 16.0f, "Smithy", 32.0f);

		if (RayGui.GuiButton(actionButton, "Action"))
			performingAction = true;

		if (performingAction)
		{	
			GameUtil.DrawText(30.0f, 636.0f, "you bang rocks together to make flint", 24.0f);

			if (GameData.GameAges[GameData.Age].PerformAction()) 
				performingAction = false;
		}

		RayGui.GuiProgressBar(
			progressBar,
			"", "", 
			GameData.GameAges[GameData.Age].Progress,
			0.0f, 5.0f
		);

		RayGui.GuiButton(tradeButton, "Trade"); // TODO trade menu

		if (RayGui.GuiButton(upgradeButton, "Upgrade"))
			GameData.Menu = GameMenu.UPGRADE;

		if (RayGui.GuiButton(inventoryButton, "Inventory"))
			GameData.Menu = GameMenu.INVENTORY;
	}
}