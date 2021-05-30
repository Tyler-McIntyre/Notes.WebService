using JsonFlatFileDataStore;
using System;
using System.Linq;

namespace Notes.WebService.Models
{
    public class Note
    {
        public int NoteId { get; private set; }
        public string Message { get; set; }
        public string CreatedBy { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public DateTime CreatedDate { get; private set; }
        public void SetNoteValues(Note noteProps, IDocumentCollection<dynamic> collection)
        {
            NoteId = SetNoteID(collection);
            Message = noteProps.Message;
            CreatedBy = noteProps.CreatedBy;
            ClientId = noteProps.ClientId;
            ClientName = noteProps.ClientName;
            CreatedDate = DateTime.Now.ToLocalTime();
        }

        private int SetNoteID(IDocumentCollection<dynamic> collection)
        {
            return collection.AsQueryable().AsEnumerable().ToList().Count() + 1;
        }
    }
}
