namespace Game;

using Raylib_CsLo;

public class StoneAge : Age
{
	// Progress field is inherited.

	public override bool PerformAction()
	{
		if (this.locked) return false;

		if (Progress > 5) {
			Progress = 0;

			GameData.MaterialInventory[Material.STONE].count--;
			GameData.MaterialInventory[Material.FLINT].count++;

			return true;
		}

		Progress += Raylib.GetFrameTime();
		return false;
	}

	public override bool CanPerform()
	{
		return GameData.MaterialInventory[Material.STONE].count > 0;
	}

	public override bool CollectMaterials()
	{
		if (this.locked) return false;

		if (Gathering > 5) {
			if (new Random().NextDouble() > 0.75) {
				GameData.MaterialInventory[Material.STONE].count++;
			}
			Gathering = 0;
			return true;
		}

		Gathering += Raylib.GetFrameTime();
		return false;
	}
}