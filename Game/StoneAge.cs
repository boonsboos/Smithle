namespace Game;

using Raylib_CsLo;

public class StoneAge : Age
{
	// Progress field is inherited.

	public override bool PerformAction()
	{
		if (Progress > 5) {
			Progress = 0;
			return true;
		}

		Progress += Raylib.GetFrameTime();
		return false;
	}
}