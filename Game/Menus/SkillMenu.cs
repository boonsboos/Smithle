namespace Game;

using Raylib_CsLo;

public class SkillMenu : IMenu
{
	private static Rectangle backButton = GameUtil.Button(30, 50);

	private static int panelHeight = 300;
	private static int panelWidth  = 245; 

	public void Draw()
	{
		GameUtil.DrawText(30, 16, "Skills", 32);

		if (RayGui.GuiButton(backButton, "Back"))
			GameData.Menu = GameMenu.DASHBOARD;
		
		DrawUpgrade(210, 50,  "Gather Speed",  GameData.GatherSpeed);
		DrawUpgrade(475, 50,  "Refine Speed",  GameData.RefineSpeed);
		DrawUpgrade(735, 50,  "Forge Speed",  GameData.ForgingSpeed);
		DrawUpgrade(995, 50,  "Polish Speed",  GameData.PolishSpeed);

		DrawUpgrade(210, 370, "Hire Gatherer", GameData.GatherSkill);
		DrawUpgrade(475, 370, "Refine Yield",  GameData.RefineSkill);
		DrawUpgrade(735, 370, "Forge Luck",   GameData.ForgingSkill);
		DrawUpgrade(995, 370, "Finer Cloths",  GameData.PolishSkill);
	}

	void DrawUpgrade(int x, int y, string upgrade, float Upgradable)
	{
		Raylib.DrawRectangleLines(x, y, panelWidth, panelHeight, Raylib.BLACK);
		GameUtil.DrawText(x + 5, y + 5, upgrade, 32);
		GameUtil.DrawText(x + 5, y + 40, $"Lvl: {Upgradable}", 28);
	}

	void DrawUpgrade(int x, int y, string upgrade, int Upgradable)
	{
		Raylib.DrawRectangleLines(x, y, panelWidth, panelHeight, Raylib.BLACK);
		GameUtil.DrawText(x + 5, y + 5, upgrade, 32);
		GameUtil.DrawText(x + 5, y + 40, $"Lvl: {Upgradable}", 28);
	}
}