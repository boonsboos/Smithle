namespace Game;

using Raylib_CsLo;
using System.Numerics;

public static class GameUtil
{
	public static Rectangle Button(float x, float y)
	{
		return new(x, y, 160, 60);
	}

	public static void DrawText(float x, float y, string text, float textSize)
	{
		Raylib.DrawTextEx(
			GameData.SmithleFont,
			text,
			new Vector2(x, y),
			textSize,
			.5f,
			Raylib.BLACK
		);
	}

	public static void DrawTextColored(float x, float y, string text, float textSize, Color c)
	{
		Raylib.DrawTextEx(
			GameData.SmithleFont,
			text,
			new Vector2(x, y),
			textSize,
			.5f,
			c
		);
	}
}