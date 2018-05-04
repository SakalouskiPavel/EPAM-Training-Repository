using System.CodeDom;

namespace Task5.Formats
{
    public class LaTeXFromat : AbstractFormat
    {
        public override string Get(BoldText part)
        {
            return "\\textbf{" + part.Text + "}";
        }

        public override string Get(PlainText part)
        {
            return part.Text;
        }

        public override string Get(Hyperlink part)
        {
            return "\\href{" + part.Url + "}{" + part.Text + "}";
        }
    }
}