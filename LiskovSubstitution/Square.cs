namespace LiskovSubstitution
{
    public class Square : Rectangle
    {
        public override int Height { set => base.Width = base.Height = value; }
        public override int Width { set => base.Width = base.Height = value; }
    }
}
