using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryCatchMe.Patterns.Design.Creational
{
    public class Builder
    {
        public void Run()
        {
            var builder = new XmlDocumentBuilder();
            builder.AddHeader("...");
            builder.AddChapters(new [] {"...", "...", "..."});
            builder.AddFooter("...");

            XmlDocument document = builder.GetDocument();
        }
    }

    public class XmlDocument
    {
        public string Content;

        //Some documents may not have headers, footers, etc..
        //This can cause a proliferation of constrcutors with varying combinations of parameters,
        //An anti pattern known as telescoping

        public XmlDocument(string header) { }

        public XmlDocument(string[] chapters) { }

        public XmlDocument(string header, string[] chapters) { }

        public XmlDocument(string header, string footer) { }

        public XmlDocument(string header, string [] chapters, string footer) { }
    }

    public abstract class DocumentBuilder
    {
        public abstract void AddHeader(string header);
        public abstract void AddChapters(string[] chapter);
        public abstract void AddFooter(string footer);
    }

    public class XmlDocumentBuilder : DocumentBuilder
    {
        private XmlDocument _document;

        public XmlDocument GetDocument()
        {
            return _document;
        }

        public override void AddHeader(string header)
        {
            _document.Content += ("<head>" + header + "</head>");
        }

        public override void AddChapters(string[] chapters)
        {
            foreach (var c in chapters)
            {
                _document.Content += ("<chapter>" + c + "</chapter>");
            }
        }

        public override void AddFooter(string header)
        {
            _document.Content += ("<head>" + header + "</head>");
        }
    }
}
