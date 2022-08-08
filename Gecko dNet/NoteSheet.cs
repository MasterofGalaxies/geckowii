using System;
using System.Collections.Generic;
using System.Text;

namespace GeckoApp
{
    public class Sheet
    {
        private string PTitle;
        private string PContent;
        private NotePage PControl = null;

        public string title
        {
            get { return PTitle; }
            set { PTitle = value; }
        }

        public string content
        {
            get { return PContent; }
            set { PContent = value; }
        }

        public NotePage control
        {
            get { return PControl; }
            set { PControl = value; }
        }

        public override string ToString()
        {
            return PTitle;
        }

        public Sheet(string title, string content)
        {
            PTitle = title;
            PContent = content;
        }

        public Sheet(string title)
            : this(title, "")
        { }

        public Sheet()
            : this("New sheet", "")
        { }
    }
}
