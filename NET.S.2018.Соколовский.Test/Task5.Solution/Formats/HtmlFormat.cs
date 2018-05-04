namespace Task5.Formats
{
    public class HtmlFormat : AbstractFormat
    {
        public override string Get(BoldText part)
        {
            return "<b>" + part.Text + "</b>";
        }

        public override string Get(PlainText part)
        {
            return part.Text;
        }

        public override string Get(Hyperlink part)
        {
            return "<a href=\"" + part.Url + "\">" + part.Text + "</a>";
        }
    }
}