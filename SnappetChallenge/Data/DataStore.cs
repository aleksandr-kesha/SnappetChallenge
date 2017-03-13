using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using SnappetChallenge.Models;

namespace SnappetChallenge.Data
{
    public static class DataStore
    {
        public static List<ResponseModel> ResponseData { get; }
        public static List<DataModel> RawData { get; set; }

        static DataStore()
        {
            const string dataFilePath = @"~/App_Data/work.json";

            var path = string.Empty;

            try
            {
                path = System.Web.Hosting.HostingEnvironment.MapPath(dataFilePath);
            }
            catch (Exception ex)
            {
                throw new Exception("Data file does not exists", ex);
            }

            List<DataModel> models;

            // ReSharper disable once AssignNullToNotNullAttribute
            using (var reader = new StreamReader(path))
            {
                using (var jsonReader = new JsonTextReader(reader))
                {
                    models = new JsonSerializer().Deserialize<List<DataModel>>(jsonReader);
                }
            }

            var modelsWithUtcDate = models.Where(m => m.SubmitDateTime.Kind == DateTimeKind.Utc).ToList();
            var modelsWithLocalDate = models.Where(m => m.SubmitDateTime.Kind == DateTimeKind.Local).ToList();
            var modelsWithUnspecifiedDate = models.Where(m => m.SubmitDateTime.Kind == DateTimeKind.Unspecified).ToList();

            var modelsWithRequiredDate =
                models.Where(m => m.SubmitDateTime < new DateTime(2015, 03, 24, 11, 30, 0, DateTimeKind.Utc)).ToList();


            RawData = modelsWithRequiredDate;
            ResponseData = new List<ResponseModel>();

            foreach (var dataModel in modelsWithRequiredDate)
            {
                var response = new ResponseModel
                {
                    AnswerId = dataModel.SubmittedAnswerId,
                    AnswerDateTime = dataModel.SubmitDateTime,
                    ExerciseId = dataModel.ExerciseId,
                    LearningObjective = dataModel.LearningObjective,
                    Domain = dataModel.Domain,
                    Correct = dataModel.Correct,
                    Difficulty = dataModel.Difficulty.Equals("null", StringComparison.InvariantCultureIgnoreCase) ? default(double?) : double.Parse(dataModel.Difficulty, CultureInfo.InvariantCulture),
                    Progress = dataModel.Progress,
                    Subject = dataModel.Subject,
                    UserId = dataModel.UserId
                };

                ResponseData.Add(response);
            }
        }
    }
}