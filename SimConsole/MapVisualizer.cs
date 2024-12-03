using Simulator.Maps;
using Simulator;
using System.Text;

public class MapVisualizer
{
    private readonly Map _map;

    public MapVisualizer(Map map)
    {
        _map = map;
    }

    public void Draw()
    {
        Console.OutputEncoding = Encoding.UTF8;

        int sizeX = _map.SizeX;
        int sizeY = _map.SizeY;
        StringBuilder mapRepresentation = new StringBuilder();

        AppendBorder(mapRepresentation, Box.TopLeft, Box.TopMid, Box.TopRight, sizeX);

        for (int y = sizeY - 1; y >= 0; y--)
        {
            AppendRow(mapRepresentation, Box.Vertical, Box.Vertical, sizeX, y);

            if (y > 0)
            {
                AppendBorder(mapRepresentation, Box.MidLeft, Box.Cross, Box.MidRight, sizeX);
            }
        }

        AppendBorder(mapRepresentation, Box.BottomLeft, Box.BottomMid, Box.BottomRight, sizeX);

        Console.Write(mapRepresentation.ToString());
    }

    private void AppendRow(StringBuilder sb, char verticalSymbol, char horizontalSymbol, int sizeX, int y)
    {
        sb.Append(verticalSymbol);

        for (int x = 0; x < sizeX; x++)
        {
            var mappablesAtPoint = _map.At(new Point(x, y));

            if (mappablesAtPoint.Count > 1)
            {
                sb.Append('X');
            }
            else if (mappablesAtPoint.Count == 1)
            {
                var mappable = mappablesAtPoint.First();
                sb.Append(mappable.Symbol);
            }
            else
            {
                sb.Append(' ');
            }

            if (x < sizeX - 1)
            {
                sb.Append(horizontalSymbol);
            }
        }

        sb.AppendLine(verticalSymbol.ToString());
    }

    private void AppendBorder(StringBuilder sb, char left, char mid, char right, int sizeX)
    {
        sb.Append(left);
        for (int x = 0; x < sizeX; x++)
        {
            sb.Append(Box.Horizontal);
            if (x < sizeX - 1)
            {
                sb.Append(mid);
            }
        }
        sb.AppendLine(right.ToString());
    }
}
