namespace LiskovSubstitution
{
    public class Rectangle
    {
        public Rectangle()
        {

        }

        public Rectangle(int height, int width)
        {
            Height = height;
            Width = width;
        }

        /// Virtual means that when we create child of this class, we refer to child implementation of this property
        public virtual int Height { get; set; }
        public virtual int Width { get; set; }

        public override string ToString()
        {
            return $"{nameof(Width)} : {Width}, {nameof(Height)} - {Height}";
        }
    }
}
