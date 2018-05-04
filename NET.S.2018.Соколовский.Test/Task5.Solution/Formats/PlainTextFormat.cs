namespace Task5.Formats
{
    public class PlainTextFormat : AbstractFormat
    {
        public override string Get(BoldText part)
        {
            return "**" + part.Text + "**";
        }

        public override string Get(PlainText part)
        {
            return part.Text;
        }

        public override string Get(Hyperlink part)
        {
            return part.Text + " [" + part.Url + "]";
        }
    }
}