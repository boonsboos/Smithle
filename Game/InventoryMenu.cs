namespace Game;

using Raylib_CsLo;
using System.Numerics;

public class InventoryMenu : IMenu
{
	private static Rectangle backButton = GameUtil.Button(30, 50);
	private static Rectangle prodButton = GameUtil.Button(30, 130);

	private static Rectangle invBounds  = new(210, 50, 800, 620);

	private static bool showProducts;

	private int scroll = 0;
	private int select = 0;

	public void Draw()
	{
		int listScroll = scroll;

		GameUtil.DrawText(30, 16, "Inventory", 32);

		if (RayGui.GuiButton(backButton, "Back"))
			GameData.Menu = GameMenu.DASHBOARD;


		if (!showProducts)
		{
			if (RayGui.GuiButton(prodButton, "Products"))
				showProducts = true;

			GameUtil.DrawText(534, 16, "Materials", 32);
			unsafe {
				RayGui.GuiListView(invBounds, GameData.Materials, &listScroll, -1);
			}
		} else {
			if (RayGui.GuiButton(prodButton, "Materials"))
				showProducts = false;
			
			GameUtil.DrawText(534, 16, "Products", 32);

			int a = 0;
			unsafe {
				a = RayGui.GuiListView(invBounds, GameData.Products, &listScroll, -1);
			}

			if (a >= 0) 
				select = a;

			if (select >= 0 && select < GameData.ProductInventory.Count())
				GameUtil.DrawText(1030, 50, GameData.ProductInventory[select].ToString(), 32);
		}

		scroll = listScroll;
	}

	
}