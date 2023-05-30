namespace ValueTypeStructs
{
    public struct Point
    {
        public float X;
        public float Y;

        public Point(float x, float y)
        {
            X = x;
            Y = y;
        }

        public void TranslateInSpace(float dx, float dy)
        {
            X += dx;
            Y += dy;
        }

        private static Point _orgin = new Point(0, 0);

        public static ref Point Origin => ref _orgin;

        private static readonly Point _readonlyOrigin = new Point(0, 0);

        public static ref readonly Point ReadOnlyOrigin
        {
            get { return ref _readonlyOrigin; }
        }

    }
}