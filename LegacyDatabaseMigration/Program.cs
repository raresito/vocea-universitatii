using System.Data.Common;
using System.Diagnostics;
using System.Net;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using LegacyDatabaseMigration.CourseEvakData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using VoceaUniversitatiiDataModels;
using VoceaUniversitatiiDataModels.Models;
using Form = LegacyDatabaseMigration.CourseEvalModels.Form;

namespace HttpClientSample;

public class LegacyFormConentData
{
    [JsonPropertyName("chestionar")]
    public List<List<LegacyQuestionSection>> Chestionar { get; set; }
}

public class LegacyQuestionSection
{
    [JsonPropertyName("intrebare")]
    public List<QuestionOrLabel> Intrebare { get; set; }
    
    [JsonPropertyName("label")]
    public string Label { get; set; }
}

public class QuestionOrLabel
{
    [JsonPropertyName("enunt")]
    public string Enunt { get; set; }
    
    [JsonPropertyName("rasp")]
    public string Rasp { get; set; }
    
    [JsonPropertyName("label")]
    public string Label { get; set; }
}

public class Program
{
    public static IConfigurationRoot GetConfiguration()
    {
        var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        return builder.Build();
    }
    
    public 
    
    static void Main()
    {
        
        var configuration = GetConfiguration();
        var connectionString = configuration.GetConnectionString("CourseEvalDatabase");

        var optionsBuilder1 = new DbContextOptionsBuilder<CourseevalDrept13122023Context>();
        optionsBuilder1.UseNpgsql(connectionString);
        using (var legacyDataBaseContext = new CourseevalDrept13122023Context(optionsBuilder1.Options))
        {
            Form legacyForm = legacyDataBaseContext.Forms.First();
            VoceaUniversitatiiDataModels.Models.Form newForm = new VoceaUniversitatiiDataModels.Models.Form();
            newForm.FormName = legacyForm.Title;
            newForm.CreatedAt = legacyForm.CreatedAt;
            newForm.Id = legacyForm.Id;
            
            LegacyFormConentData legacyFormContentData = JsonSerializer.Deserialize<LegacyFormConentData>(legacyForm.Content);
            
            int formQuestionsCounter = 1;
            
            foreach (var legacySectionList in legacyFormContentData.Chestionar)
            {
                foreach (var legacyQuestionSection in legacySectionList)
                {
                    Question question = new Question();
                    question.LegacyFormOrderNumber = formQuestionsCounter;
                    if (legacyQuestionSection.Intrebare is not null)
                    {
                        foreach (var questionOrLabel in legacyQuestionSection.Intrebare)
                        {
                            if (questionOrLabel.Label is null && questionOrLabel.Rasp is null &&
                                questionOrLabel.Enunt is not null)
                            {
                                question.Title = questionOrLabel.Enunt;
                            }
                            else if (questionOrLabel.Label is null && questionOrLabel.Rasp is not null &&
                                     questionOrLabel.Enunt is null)
                            {
                                QuestionOptions questionOptions = new QuestionOptions();
                                questionOptions.OptionText = questionOrLabel.Rasp;
                                questionOptions.Question = question;
                                if (question.QuestionOptions is null)
                                    question.QuestionOptions = new List<QuestionOptions>();
                                question.QuestionOptions.Add(questionOptions);
                                question.QuestionType = QuestionType.Options;
                            }
                            else
                            {
                                Console.WriteLine("Invalid question or label");
                                Debugger.Launch();
                            }
                        }
                        if(question.QuestionOptions is null)
                            question.QuestionType = QuestionType.Text;
                        if (newForm.Questions is null)
                            newForm.Questions = new List<Question>();
                        newForm.Questions.Add(question);
                        formQuestionsCounter++;
                    }
                }
            }
            Console.WriteLine("");
        }

        var optionsBuilder2 = new DbContextOptionsBuilder<DatabaseContext>();
        optionsBuilder2.UseNpgsql(connectionString);
        using (var context2 = new DatabaseContext(optionsBuilder2.Options, null))
        {
            // Use context2 here
        }
    }
}