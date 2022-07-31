namespace Game;

using Raylib_CsLo;

public class ActionMenu : IMenu
{

	private static Rectangle backButton = GameUtil.Button(30, 50);
	private static Rectangle workButton = GameUtil.Button(30, 130);
	private static Rectangle gathButton = GameUtil.Button(30, 210);

	private static Rectangle progressBar = new(30, 660, 1220, 30);

	private bool performingAction;
	private bool gatheringMaterial;

	public void Draw()
	{
		if (RayGui.GuiButton(backButton, "Back"))
			GameData.Menu = GameMenu.SMITHY;

		if (RayGui.GuiButton(workButton, "Work") && GameData.GameAges[GameData.Age].CanPerform())
			performingAction = true;

		if (performingAction)
		{	
			GameUtil.DrawText(30.0f, 636.0f, "you bang STONE together to make FLINT", 24.0f);

			if (GameData.GameAges[GameData.Age].PerformAction()) 
				performingAction = false;
		}

		if (RayGui.GuiButton(gathButton, "Gather"))
			gatheringMaterial = true;

		if (gatheringMaterial)
		{	
			GameUtil.DrawText(30.0f, 636.0f, "you head to the mountains to find Materials", 24.0f);

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
	}
}