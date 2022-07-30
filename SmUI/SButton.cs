namespace SmUI;

using Raylib_cs;
using System.Numerics;

using Game;

public class SmButton
{
	private Rectangle r;
	private String text;
	private bool clicked;

	public SmButton(Rectangle r, String text)
	{
		this.r = r;
		this.text = text;
	}

	public void Draw()
	{

		Raylib.DrawRectangleRoundedLines(this.r, 0.5f, 1, 5f, Color.BLACK);

		if(this.clicked) {
			Raylib.DrawRectangleRounded(this.r, .5f, 1, Color.LIGHTGRAY);
		}

		Raylib.DrawTextEx(
			GameData.SmithleFont,
			this.text,
			new Vector2{X = this.r.x + 4, Y = this.r.y + 4 },
			this.r.height - 4.0f,
			0.5f,
			Color.BLACK
		);
	}

	public bool IsClicked(Vector2 pos)
	{
		this.clicked = Raylib.CheckCollisionPointRec(pos, this.r);
		return this.clicked;
	}
}