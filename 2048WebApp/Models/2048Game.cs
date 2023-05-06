namespace _2048WebApp.Models
{
    public class _2048Game
    {
        public int[][] Board { get; set; } = new int[4][];
        public int MaxTile { get; set; }
    }
    [Flags]
    public enum Moves
    {
        None = 0,
        Up = 1,
        Right = 2,
        Down = 4,
        Left = 8
    }
}