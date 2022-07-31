namespace Game;

using Raylib_CsLo;

public class SmithyMenu : IMenu
{
	private static Rectangle actionButton    = GameUtil.Button(30, 50);
	private static Rectangle gatherButton    = GameUtil.Button(30, 130);
	private static Rectangle tradeButton     = GameUtil.Button(30, 210);
	private static Rectangle upgradeButton   = GameUtil.Button(30, 290);
	private static Rectangle inventoryButton = GameUtil.Button(30, 370);

	private static Rectangle progressBar   = new(30, 660, 1220, 30);

	private bool performingAction;
	private bool gatheringMaterial;

	public void Draw()
	{
		GameUtil.DrawText(30, 16, "Smithy", 32);

		if (RayGui.GuiButton(actionButton, "Work") && GameData.GameAges[GameData.Age].CanPerform())
			performingAction = true;

		if (performingAction)
		{	
			GameUtil.DrawText(30.0f, 636.0f, "you bang STONE together to make FLINT", 24.0f);

			if (GameData.GameAges[GameData.Age].PerformAction()) 
				performingAction = false;
		}

		if (RayGui.GuiButton(gatherButton, "Gather"))
			gatheringMaterial = true;

		if (gatheringMaterial)
		{	
			GameUtil.DrawText(30.0f, 636.0f, "you go to find STONE in the mountains", 24.0f);

			if (GameData.GameAges[GameData.Age].CollectMaterials())
				gatheringMaterial = false;
		}

		RayGui.GuiProgressBar(
			progressBar,
			"", "", 
			performingAction ? GameData.GameAges[GameData.Age].Progress : 
					(gatheringMaterial ? GameData.GameAges[GameData.Age].Gathering : 0.0f),
			0.0f, 5.0f
		);

		RayGui.GuiButton(tradeButton, "Trade"); // TODO trade menu

		if (RayGui.GuiButton(upgradeButton, "Upgrade"))
			GameData.Menu = GameMenu.UPGRADE;

		if (RayGui.GuiButton(inventoryButton, "Inventory")) {
			GameData.Menu = GameMenu.INVENTORY;
			GameData.RefreshInventory();
		}
	}
}