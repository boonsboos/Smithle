namespace Game;

using Raylib_cs;
using System.Numerics;

using SmUI;

public class MainMenu : Menu
{

	private static Rectangle ButtonRect = new Rectangle(60.0f, 190.0f, 120.0f, 60.0f);
	private static SmButton PlayButton = new SmButton(ButtonRect, "Play");

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
			Console.WriteLine("Clicked!");
		}
		
	}
}