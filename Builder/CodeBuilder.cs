using System;
using System.Collections.Generic;
using System.Text;

namespace Builder
{
    public class CodeBuilder
    {
        private string className;

        private Dictionary<string, string> fields;


        public CodeBuilder(string className)
        {
            this.className = className;
            fields = new Dictionary<string, string>();

        }

        public CodeBuilder AddField(string name, string type)
        {
            fields.Add(name, type);
            return this;
        }


        private string ToStringCode(int indent)
        {
            var sb = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(className))
            {
                sb.AppendLine($"public class {className}");
                sb.AppendLine("{");
            }

            foreach (var item in fields)
            {
                sb.AppendLine($"{new string(' ', indent + 2)}public {item.Value} {item.Key};");
            }

            sb.AppendLine("}");
            return sb.ToString();
        }

        public override string ToString()
        {
            return ToStringCode(0);
        }
    }
}
