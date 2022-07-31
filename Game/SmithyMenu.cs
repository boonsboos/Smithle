namespace Game;

using Raylib_CsLo;

public class SmithyMenu : IMenu
{
	private static Rectangle actionButton    = GameUtil.Button(30, 50);
	private static Rectangle tradeButton     = GameUtil.Button(30, 130);
	private static Rectangle upgradeButton   = GameUtil.Button(30, 210);
	private static Rectangle inventoryButton = GameUtil.Button(30, 290);

	public void Draw()
	{
		GameUtil.DrawText(30, 16, "Smithy", 32);
		
		if (RayGui.GuiButton(actionButton, "Action"))
			GameData.Menu = GameMenu.ACTION;

		RayGui.GuiButton(tradeButton, "Trade"); // TODO trade menu

		if (RayGui.GuiButton(upgradeButton, "Upgrade"))
			GameData.Menu = GameMenu.UPGRADE;

		if (RayGui.GuiButton(inventoryButton, "Inventory")) {
			GameData.Menu = GameMenu.INVENTORY;
			GameData.RefreshInventory();
		}
	}
}