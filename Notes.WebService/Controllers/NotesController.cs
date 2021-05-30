using JsonFlatFileDataStore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Notes.WebService.Models;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Dynamic;
using System.Threading.Tasks;

namespace Notes.WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly DataStore Store = new DataStore("FlatFileDB\\NoteDB.json");
        public readonly IDocumentCollection<dynamic> collection;

        public NotesController()
        {
            collection = GetNoteCollection();
        }

        [HttpGet]
        public ActionResult GetAllNotes()
        {
            if (collection.Count <= 0)
            {
                return new NotFoundObjectResult("Notes collection is empty. Please add a new note.");
            }

            List<dynamic> noteList = collection.AsQueryable().ToList();

            return Ok(noteList);
        }

        [HttpGet("{noteId}")]
        public ActionResult GetNote(int noteId)
        {
            dynamic results = collection.AsQueryable().FirstOrDefault(p => p.noteId == noteId);

            if (results == null) 
            {
                return new NotFoundObjectResult("NoteId Not Found");
            }

            return Ok(results);
        }

        [HttpPut]
        public async Task<ActionResult> InsertNote([FromBody] Note newNoteValues)
        {
            Note note = new Note();
            note.SetNoteValues(newNoteValues, collection);

            JToken jsonNote = JToken.Parse(JsonConvert.SerializeObject(note));

            await Store.GetCollection("notes").InsertOneAsync(jsonNote);

            return Ok(note);
        }

        [HttpPost]
        public async Task<ActionResult> Update(int noteId, string property, string value)
        {
            if (!NoteExists(noteId))
            {
                return new NotFoundObjectResult("NoteId Not Found");
            }

            IDictionary<string, object> source = new ExpandoObject();
            source.Add(property, value);

            await collection.UpdateOneAsync(e => e.noteId == noteId, source);

            return Ok();
        }

        [HttpDelete("{noteId}")]
        public async Task<ActionResult> Delete(int noteId)
        {
            if (!NoteExists(noteId))
            {
                return new NotFoundObjectResult("NoteId Not Found");
            }

            await collection.DeleteOneAsync(e => e.noteId == noteId);

            return Ok();
        }

        //Utility functions
        private IDocumentCollection<dynamic> GetNoteCollection()
        {
            DataStore Store = new DataStore("FlatFileDB\\NoteDB.json");
            IDocumentCollection<dynamic> collection = Store.GetCollection("notes");

            return collection;
        }

        private bool NoteExists(int noteId)
        {
            bool bExists = false;

            if (collection.AsQueryable().Any(x => x.noteId == noteId))
            {
                return bExists = true;
            }

            return bExists;
        }
    }
}
