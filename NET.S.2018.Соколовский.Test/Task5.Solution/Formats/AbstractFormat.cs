namespace Task5.Formats
{
    public abstract class AbstractFormat
    {
        public abstract string Get(BoldText part);

        public abstract string Get(PlainText part);


        public abstract string Get(Hyperlink part);
      
        public string Get(DocumentPart part)
        {
            if (part is BoldText)
            {
                return Get(part as BoldText);
            }

            if (part is PlainText)
            {
                return Get(part as PlainText);
            }

            if (part is Hyperlink)
            {
                return Get(part as Hyperlink);
            }

            return string.Empty;
        }
    }
}