using System.Diagnostics;
using System.Text.Json;
using LegacyDatabaseMigration.CourseEvakData;
using LegacyDatabaseMigration.CourseEvalModels.CourseEvalFormModels;
using VoceaUniversitatiiDataModels;
using VoceaUniversitatiiDataModels.Models;
using Form = LegacyDatabaseMigration.CourseEvalModels.Form;

namespace HttpClientSample;

public class FormsMigration
{
    private CourseevalDrept13122023Context _source;
    private DatabaseContext _target;

    public FormsMigration(CourseevalDrept13122023Context source, DatabaseContext target)
    {
        _source = source;
        _target = target;
    }
    
    public void Migrate()
    {
        Form legacyForm = _source.Forms.First();
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
    }
}