# Notes.WebService
### A .Net Core 3.1 web application API using a JSON flat file DB and Swagger

Pull and build this application is Visual Studio/VS Code. This application will require you to have .Net Core v3.1 installed in order to run the application.

This web api was built using [json-flatfile-datastore](https://github.com/ttu/json-flatfile-datastore) and [swagger](https://github.com/swagger-api)

## **Notes.WebService Swagger**
```
http://localhost:2293/index.html
```
![Swagger page](https://github.com/Tmc802/Notes.WebService/blob/master/Notes.WebService%20Images/Swagger.JPG?raw=true)

## **GET All Notes**
```
http://localhost:2293/api/Notes
```
![PostMan All Notes](https://github.com/Tmc802/Notes.WebService/blob/master/Notes.WebService%20Images/GetAllNotes.JPG?raw=true)

## **PUT Insert Note**
```
http://localhost:2293/api/Notes
```
```
    {
      "noteId": 1,
      "message": "Follow up with Tom on 4/5",
      "createdBy": "Bill Gates",
      "clientId": 1564,
      "clientName": "Tom Brady"
    }
 ```
![PostMan PUT](https://github.com/Tmc802/Notes.WebService/blob/master/Notes.WebService%20Images/PUT.JPG?raw=true)
   

## **POST Update Note**
```
http://localhost:2293/api/Notes
```
```
{
    "noteId": 1,
    "property": "message",
    "value": "Reminder to send email"
}
```
![PostMan Update](https://github.com/Tmc802/Notes.WebService/blob/master/Notes.WebService%20Images/Post.JPG?raw=true)


## **GET Retrieve Note**
```
http://localhost:2293/api/Notes/{NoteId}
```
![PostMan Retrieve](https://github.com/Tmc802/Notes.WebService/blob/master/Notes.WebService%20Images/GetRetieveNote.JPG?raw=true)


## **DELETE Note**
```
http://localhost:2293/api/Notes/{NoteId}
```
![PostMan Delete](https://github.com/Tmc802/Notes.WebService/blob/master/Notes.WebService%20Images/Delete.JPG?raw=true)


