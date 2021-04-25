using System.Collections.Generic;

namespace MementoPattern
{
    public class DocumentMemento
    {
        private readonly string _content;

        public DocumentMemento(string content) => _content = content;

        public string GetContent() => _content;
    }

    public class History
    {
        private readonly Stack<DocumentMemento> _states = new();

        public void Save(DocumentMemento documentMemento) =>
            _states.Push(documentMemento);

        public DocumentMemento Retrieve() =>
            _states.Pop();
    }

    public class Document
    {
        private string _content;
        
        public void SetContent(string newContent) => 
            _content = newContent;

        public string GetContent() => _content;

        public DocumentMemento CreateState() =>
            new (_content);

        public void Restore(DocumentMemento documentMemento) =>
            _content = documentMemento.GetContent();
    }
}
