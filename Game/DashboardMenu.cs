namespace Game;

using Raylib_CsLo;

public class DashboardMenu : IMenu
{
	private static Rectangle actionButton    = GameUtil.Button(30, 50);
	private static Rectangle tradeButton     = GameUtil.Button(30, 130);
	private static Rectangle skillButton     = GameUtil.Button(30, 210);
	private static Rectangle inventoryButton = GameUtil.Button(30, 290);
	private static Rectangle prestigeButton  = GameUtil.Button(30, 370);

	private static bool errorFlag;
	private static byte errorLen;

	public void Draw()
	{
		GameUtil.DrawText(30, 16, "Dashboard", 32);
		
		if (RayGui.GuiButton(actionButton, "Smithy")) {
			GameData.Menu = GameMenu.ACTION;
			errorFlag = false;
		}

		RayGui.GuiButton(tradeButton, "Trade"); // TODO trade menu

		if (RayGui.GuiButton(skillButton, "Skills")) {
			if (GameData.Age == GameAge.STONE) {
				errorFlag = true;
			} else {
				GameData.Menu = GameMenu.SKILL;
				errorFlag = false;
			}
		}

		if (errorFlag && errorLen != 128) {
			errorLen++;
			GameUtil.DrawTextColored(210, 225, "Skills will be unlocked in the Bronze Age", 32, Raylib.RED);
		}
		
		if (errorLen == 128) { 
			errorLen = 0;
			errorFlag = false;
		}

		if (RayGui.GuiButton(inventoryButton, "Inventory")) {
			GameData.Menu = GameMenu.INVENTORY;
			GameData.RefreshInventory();
			errorFlag = false;
		}

		if (RayGui.GuiButton(prestigeButton, "Prestige")) {
			GameData.Menu = GameMenu.PRESTIGE;
			errorFlag = false;
		}
	}
}