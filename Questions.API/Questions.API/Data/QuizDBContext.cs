using System;
using Microsoft.EntityFrameworkCore;
using Questions.API.Models.Domain;

namespace Questions.API.Data
{

    public class QuizDBContext : DbContext
	{
        readonly Guid question1Id = Guid.NewGuid();
        readonly Guid question2Id = Guid.NewGuid();
        readonly Guid answer1Id = Guid.NewGuid();
        readonly Guid answer2Id = Guid.NewGuid();
        readonly Guid answer3Id = Guid.NewGuid();
        readonly Guid answer4Id = Guid.NewGuid();
        readonly Guid answer5Id = Guid.NewGuid();
        readonly Guid answer6Id = Guid.NewGuid();


        public QuizDBContext(DbContextOptions<QuizDBContext> options): base(options)
		{
            
        }
		public DbSet<Qn> Qns { get; set; }
        public DbSet<Ans> Answers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            CreateQuestionModel(modelBuilder);
            CreateAnswersModel(modelBuilder);
        }


        private void CreateQuestionModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Qn>(entity =>
            {
                entity.HasData(
                    new Qn
                    {
                        Id = question1Id,
                        Category = "Sport",
                        Question = "Best forballplayer?",
                        Language = "Svenska"

                    },
                    new Qn
                    {
                        Id = question2Id,
                        Category = "Movies",
                        Question = "Best movie?",
                        Language = "Eng"

                    }
                );
            });
        }


        private void CreateAnswersModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ans>(entity =>
            {
                entity.HasData(
                    new Ans
                    {
                        Id = answer1Id,
                        QuestionId = question1Id,
                        Answer = "Maradona",
                        IsCorrectAnswer = false
                    },
                    new Ans
                    {
                        Id = answer2Id,
                        QuestionId = question1Id,
                        Answer = "Pele",
                        IsCorrectAnswer = false,
                    },
                    new Ans
                    {
                        Id = answer3Id,
                        QuestionId = question1Id,
                        Answer = "Messi",
                        IsCorrectAnswer = true
                    },

                    new Ans
                    {
                        Id = answer4Id,
                        QuestionId = question2Id,
                        Answer = "Avatar",
                        IsCorrectAnswer = true,
                    },
                    new Ans
                    {
                        Id = answer5Id,
                        QuestionId = question2Id,
                        Answer = "Titanic",
                        IsCorrectAnswer = true,
                    }, new Ans
                    {
                        Id = answer6Id,
                        QuestionId = question2Id,
                        Answer = "Lionking",
                        IsCorrectAnswer = true,
                    }
                );
            });
        }

    }
}

