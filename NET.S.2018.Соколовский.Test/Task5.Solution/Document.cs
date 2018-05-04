using System;
using System.Collections.Generic;
using Task5.Formats;

namespace Task5
{
    public class Document
    {
        private List<DocumentPart> parts;

        public Document(IEnumerable<DocumentPart> parts)
        {
            if (parts == null)
            {
                throw new ArgumentNullException(nameof(parts));
            }
            this.parts = new List<DocumentPart>(parts);
        }

        public string ToHtml()
        {
            string output = string.Empty;
            HtmlFormat format = new HtmlFormat();

            foreach (DocumentPart part in this.parts)
            {
                output += $"{format.Get(part)}\n";
            }

            return output;
        }

        public string ToPlainText()
        {
            string output = string.Empty;
            PlainTextFormat format = new PlainTextFormat();

            foreach (DocumentPart part in this.parts)
            {
                output += $"{format.Get(part)}\n";
            }

            return output;
        }

        public string ToLaTeX()
        {
            string output = string.Empty;
            LaTeXFromat format = new LaTeXFromat();

            foreach (DocumentPart part in this.parts)
            {
                output += $"{format.Get(part)}\n";
            }

            return output;
        }
    }
}
