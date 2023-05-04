# Quiz
1. Clone The project.

2. Initiate the DB
Be sure that you do this in the project folder(where the Program.cs file is located)
Execute these commands in your terminal. 

dotnet ef migrations add InitialCreate

dotnet ef database update

3. Start The project
- If the startup was successful
the Swagger docs will open up in your browser.

4. Play the quiz in swagger
- Open up the endpoint PlayQuiz
- Open GET/PlayQuiz -> Try it out -> Execute
- Copy your guessed answerId and questionId from the response.
- Open PUT/PlayQuiz/{questionId} -> Try it out
- Paste questionId into the required questionId-field
- Pate the answerId into the request-body object like this.
{
  "answerId": ”insert id here”
}
- Execute
- The response tells you if the answer is correct or not.
