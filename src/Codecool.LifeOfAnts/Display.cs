using System;
using System.Text;

namespace Codecool.LifeOfAnts
{
    public class Display
    {
        public void Colony(Colony Colony)
        {
            Console.Clear();
            int fullWidth = Colony.Width * 2 + 1;
            StringBuilder stringBuilder = new StringBuilder(GetTopBorder(fullWidth))
                .Append(GetColony(Colony))
                .Append(GetBottomBorder(fullWidth));
            Console.WriteLine(stringBuilder);
        }

        private string GetTopBorder(int fullWidth)
        {
            StringBuilder stringBuilder = new StringBuilder(String.Format("{0, 2}", $"{(char)Border.TopLeft}"))
                .Append($"{new String((char)Border.TopBottom, fullWidth)}")
                .AppendLine($"{(char)Border.TopRight}");
            return stringBuilder.ToString();
        }

        private string GetColony(Colony Colony)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < Colony.Width; i++)
            {
                stringBuilder.Append(String.Format("{0, 2}", $"{(char)Border.LeftRight}"));
                for (int j = 0; j < Colony.Width; j++)
                {
                    if (Colony.AntColony[i, j] != null)
                    {
                        stringBuilder.Append(String.Format("{0, 2}", $"{(char)Colony.AntColony[i, j].Type}"));
                    }
                    else
                    {
                        stringBuilder.Append(String.Format("{0, 2}", ' '));
                    }
                }
                stringBuilder.AppendLine(String.Format("{0, 2}", $"{(char)Border.LeftRight}"));
            }

            return stringBuilder.ToString();
        }

        private string GetBottomBorder(int fullWidth)
        {
            StringBuilder stringBuilder = new StringBuilder(String.Format("{0, 2}", $"{(char)Border.BottomLeft}"))
                .Append($"{new String((char)Border.TopBottom, fullWidth)}")
                .AppendLine($"{(char)Border.BottomRight}");
            return stringBuilder.ToString();
        }

        public void Message(string message)
        {
            Console.Write(message);
        }
    }
}
