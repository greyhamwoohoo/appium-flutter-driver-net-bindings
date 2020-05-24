namespace GreyhamWooHoo.Flutter.Models
{
    public class Position
    {
        public Position(double dx, double dy)
        {
            Dx = dx;
            Dy = dy;
        }

        public double Dx { get; }
        public double Dy { get; }
    }
}
