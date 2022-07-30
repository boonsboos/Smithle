namespace Game;

using Raylib_cs;
using System.Numerics;

using SmUI;

public class MainMenu : Menu
{

	private static Rectangle buttonRect = new Rectangle(60.0f, 190.0f, 124.0f, 64.0f);
	private static SmButton PlayButton = new SmButton(buttonRect, "Play");

	public void Draw() {
		//Raylib.DrawRectangle(10, 10, 30, 50, Color.BLACK);
		Raylib.DrawTextEx(
			GameData.SmithleFont,
			"Smithle",
			new Vector2{X = 50.0f, Y = 50.0f},
			56.0f,
			.5f,
			Color.BLACK
		);

		PlayButton.Draw();

		if (Raylib.IsMouseButtonDown(MouseButton.MOUSE_BUTTON_LEFT) 
				&& PlayButton.IsClicked(Raylib.GetMousePosition())) {
			GameData.menu = GameMenu.SMITHY;
		} else if (PlayButton.IsClicked(Raylib.GetMousePosition())) {
			PlayButton.SetClicked(false);
		}
		
	}
}