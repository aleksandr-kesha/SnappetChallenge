using System;

namespace SnappetChallenge.Models
{
    public class ResponseModel
    {
        public long AnswerId { get; set; }
        public long ExerciseId { get; set; }

        public long UserId { get; set; }

        public bool Correct { get; set; }
        public DateTime AnswerDateTime { get; set; }
       
        public int Progress { get; set; }
        public double? Difficulty { get; set; }

        public string Subject { get; set; } // аналог учебника
        public string Domain { get; set; } // глава
        //  sub-domain (раздел) 
        public string LearningObjective { get; set; } // тема

        public override string ToString()
        {
            return Subject + "; " + Domain + "; " + LearningObjective;
        }
    }
}