using Raylib_CsLo;

using Game;


class Smithle
{
	static void Main(String[] args)
	{
		Raylib.InitWindow(1280, 720, "Smithle");
		RayGui.GuiLoadStyleDefault();

		Raylib.SetTargetFPS(60);

		while (!Raylib.WindowShouldClose())
		{
			Raylib.BeginDrawing();
			Raylib.ClearBackground(Raylib.WHITE);
			RayGui.GuiSetFont(GameData.SmithleFont);

			GameData.GameMenus[GameData.Menu].Draw();

			Raylib.EndDrawing();
		}

		Raylib.CloseWindow();
	}
}
