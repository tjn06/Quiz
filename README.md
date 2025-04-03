# Quiz

## 1. Clone the project  
Clone the repository to your local machine:

`git clone [your-repo-url]`

---

## 2. Initialize the database  
Make sure you're inside the project folder (where the `Program.cs` file is located).  
Then run the following commands in your terminal to set up the database:

```
dotnet ef migrations add InitialCreate  
dotnet ef database update
```

---

## 3. Start the project  
Start the application using your preferred method (e.g., `dotnet run` or through your IDE).  
If the startup is successful, the Swagger documentation will automatically open in your browser.

---

## 4. Play the quiz using Swagger

1. Open the `PlayQuiz` endpoint in Swagger.
2. Go to `GET /PlayQuiz`, click **Try it out**, then **Execute**.
3. Copy the `answerId` and `questionId` from the response.
4. Go to `PUT /PlayQuiz/{questionId}`, click **Try it out**.
   - Paste the `questionId` into the path parameter field.
   - Paste the `answerId` into the request body like this:

```
{
  "answerId": "insert id here"
}
```

5. Click **Execute**.  
6. The response will let you know whether the answer was correct or not.
