using Raylib_cs;

class Smithle
{
	static void Main(String[] args)
	{
		Raylib.InitWindow(600, 480, "Smithle");

		while (!Raylib.WindowShouldClose())
		{
			Raylib.BeginDrawing();
			Raylib.ClearBackground(Color.WHITE);

			Raylib.DrawText("Hello, world!", 12, 12, 20, Color.BLACK);

			Raylib.EndDrawing();
		}

		Raylib.CloseWindow();
	}
}
