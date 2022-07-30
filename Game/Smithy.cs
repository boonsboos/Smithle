namespace Game;

using Raylib_cs;
using SmUI;

public class Smithy : Menu
{
	private static Rectangle actionButtonRect = new Rectangle(50.0f, 50.0f, 166.0f, 60.0f);
	private static SmButton ActionButton = new SmButton(actionButtonRect, "Action");

	public void Draw() {
		ActionButton.Draw();
	}
}