namespace Game;

using Raylib_CsLo;

public class ActionMenu : IMenu
{

	private static Rectangle backButton   = GameUtil.Button(30, 50);
	private static Rectangle gatherButton = GameUtil.Button(30, 130);
	private static Rectangle refineButton = GameUtil.Button(30, 210);
	private static Rectangle forgeButton  = GameUtil.Button(30, 290);

	private static Rectangle progressBar = new(30, 660, 1220, 30);

	private bool refiningMaterial;
	private bool gatheringMaterial;
	private bool forgingProduct;

	public void Draw()
	{
		GameUtil.DrawText(30, 16, "Smithy", 32);

		if (RayGui.GuiButton(backButton, "Back"))
			GameData.Menu = GameMenu.DASHBOARD;

		// Gather button
		DrawGather();

		// Refine button
		DrawRefine();

		// Forge button
		DrawForge();

		RayGui.GuiProgressBar(
			progressBar,
			"", "", 
			refiningMaterial ? GameData.GameAges[GameData.Age].Progress : 
				(gatheringMaterial ? GameData.GameAges[GameData.Age].Gathering : 
					(forgingProduct ? GameData.GameAges[GameData.Age].Forging : 0.0f)),
			0.0f, forgingProduct ? 8.0f : 5.0f
		);
	}

	void DrawGather()
	{
		if (RayGui.GuiButton(gatherButton, "Gather"))
			gatheringMaterial = true;

		if (gatheringMaterial)
		{	
			GameUtil.DrawText(30.0f, 636.0f, "you head to the mountains to find STONE", 24.0f);

			if (GameData.GameAges[GameData.Age].CollectMaterials())
				gatheringMaterial = false;
		}
	}

	void DrawRefine()
	{
		if (RayGui.GuiButton(refineButton, "Refine") && GameData.GameAges[GameData.Age].CanRefine())
			refiningMaterial = true;

		if (refiningMaterial)
		{	
			GameUtil.DrawText(30.0f, 636.0f, "you crack open the STONE for Materials", 24.0f);

			if (GameData.GameAges[GameData.Age].RefineMaterial()) 
				refiningMaterial = false;
		}
	}

	void DrawForge()
	{
		
		if (RayGui.GuiButton(forgeButton, "Forge") && GameData.GameAges[GameData.Age].CanForge())
			forgingProduct = true;

		if (forgingProduct)
		{	
			GameUtil.DrawText(30.0f, 636.0f, "you forge a new Product", 24.0f);

			if (GameData.GameAges[GameData.Age].Forge())
				forgingProduct = false;
		}
	}
}