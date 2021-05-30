using Microsoft.VisualStudio.TestTools.UnitTesting;
using Notes.WebService.Controllers;
using Microsoft.AspNetCore.Mvc;
using JsonFlatFileDataStore;
using System.Linq;
using System.Collections.Generic;
using System;

namespace Notes.WebService.Tests
{
    [TestClass]
    public class NotesControllerTest : ControllerBase
    {
        [TestMethod]
        public void GetAllNotes_ShouldReturnAllNotes()
        {
            //Arrange
            NotesController controller = new NotesController();

            //Act
            JsonResult controllerResponse = controller.GetAllNotes();
            List<dynamic> expectedcollection = GetNoteCollection().AsQueryable().ToList();
            
            //Assert
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)controllerResponse.Value).StatusCode, Ok().StatusCode);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)controllerResponse.Value).Value, expectedcollection.Count);
        }

        private IDocumentCollection<dynamic> GetNoteCollection()
        {
            DataStore Store = new DataStore("FlatFileDB\\NoteDB.json");
            IDocumentCollection<dynamic> collection = Store.GetCollection("notes");

            return collection;
        }
    }
}
