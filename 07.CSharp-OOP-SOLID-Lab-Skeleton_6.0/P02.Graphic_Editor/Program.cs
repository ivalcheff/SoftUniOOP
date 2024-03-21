namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            GraphicEditor graphicEditor = new GraphicEditor();
            IShape shape = new Circle();

            graphicEditor.DrawShape(shape);
        }
    }
}
