using System;
using System.Collections.Generic;
using System.Text;

namespace Builder
{
    public class HtmlElement
    {
        public string Name, Text;
        private int indentSize = 2;
        public List<HtmlElement> Elements = new List<HtmlElement>();

        public HtmlElement()
        {

        }

        public HtmlElement(string name, string text)
        {
            Name = name;
            Text = text;
        }

        public string ToStringImp(int indent)
        {
            var sb = new StringBuilder();
            var spaces = new string(' ', indentSize * indent);

            sb.AppendLine($"{spaces}<{Name}>");

            if (!string.IsNullOrWhiteSpace(Text))
            {
                sb.Append(new string(' ', indentSize * indent + 1));
                sb.AppendLine(Text);
            }

            foreach (var element in Elements)
            {
                sb.Append(element.ToStringImp(indent + 1));
            }
            sb.AppendLine($"{spaces}</{Name}>");

            return sb.ToString();
        }

        public override string ToString()
        {
            return ToStringImp(0);
        }
    }

    public class HtmlBuilder
    {
        HtmlElement root = new HtmlElement();
        public string RootName { get; }

        public HtmlBuilder(string rootName)
        {
            root.Name = rootName;
            RootName = rootName;
        }

        public void AddChild(string name, string text)
        {
            var el = new HtmlElement(name, text);
            root.Elements.Add(el);
        }

        public void Clear()
        {
            root = new HtmlElement { Name = RootName };
        }

        public override string ToString()
        {
            return root.ToString();
        }
    }

}
