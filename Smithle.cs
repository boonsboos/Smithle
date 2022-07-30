using Raylib_cs;

using Game;


class Smithle
{
	static void Main(String[] args)
	{
		Raylib.InitWindow(1280, 720, "Smithle");
		Raylib.SetTargetFPS(60);

		while (!Raylib.WindowShouldClose())
		{
			Raylib.BeginDrawing();
			Raylib.ClearBackground(Color.WHITE);

			GameData.Menus[GameData.menu].Draw();

			Raylib.EndDrawing();
		}

		Raylib.CloseWindow();
	}
}
