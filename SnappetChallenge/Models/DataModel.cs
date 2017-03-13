using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SnappetChallenge.Models
{
    public class DataModel
    {
        // subject (аналог учебника) - domain (глава) - sub-domain (раздел) - learning objective (тема) 

        public long SubmittedAnswerId { get; set; }
        public DateTime SubmitDateTime { get; set; }
        public bool Correct { get; set; }
        public int Progress { get; set; }
        public long UserId { get; set; }
        public long ExerciseId { get; set; }
        public string Difficulty { get; set; }
        public string Subject { get; set; }
        public string Domain { get; set; }
        public string LearningObjective { get; set; }

        public override string ToString()
        {
            return Subject + "; " + Domain + "; " + LearningObjective;
        }
    }
}