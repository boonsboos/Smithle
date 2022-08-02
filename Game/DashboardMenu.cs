namespace Game;

using Raylib_CsLo;

public class DashboardMenu : IMenu
{
	private static Rectangle actionButton    = GameUtil.Button(30, 50);
	private static Rectangle tradeButton     = GameUtil.Button(30, 130);
	private static Rectangle skillButton     = GameUtil.Button(30, 210);
	private static Rectangle inventoryButton = GameUtil.Button(30, 290);

	public void Draw()
	{
		GameUtil.DrawText(30, 16, "Dashboard", 32);
		
		if (RayGui.GuiButton(actionButton, "Smithy"))
			GameData.Menu = GameMenu.ACTION;

		RayGui.GuiButton(tradeButton, "Trade"); // TODO trade menu

		if (RayGui.GuiButton(skillButton, "Skills") /*&& GameData.Age != GameAge.STONE*/) // FIXME: uncomment for release!
			GameData.Menu = GameMenu.SKILL;

		if (RayGui.GuiButton(inventoryButton, "Inventory")) {
			GameData.Menu = GameMenu.INVENTORY;
			GameData.RefreshInventory();
		}
	}
}