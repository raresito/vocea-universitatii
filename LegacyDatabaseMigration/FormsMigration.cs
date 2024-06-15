using System.Diagnostics;
using System.Text.Json;
using LegacyDatabaseMigration.CourseEvakData;
using LegacyDatabaseMigration.CourseEvalModels.CourseEvalFormModels;
using Microsoft.EntityFrameworkCore;
using VoceaUniversitatiiDataModels;
using VoceaUniversitatiiDataModels.Models;
using LegacyForm = LegacyDatabaseMigration.CourseEvalModels.Form;
using VoceaForm = VoceaUniversitatiiDataModels.Models.Form;

public class FormsMigration
{
    private CourseevalDrept13122023Context _source;
    private DatabaseContext _target;

    public FormsMigration(CourseevalDrept13122023Context source, DatabaseContext target)
    {
        _source = source;
        _target = target;
    }
    
    public List<LegacyForm> CollectLegacyForms()
    {
        return _source.Forms.ToList();
    }
    
    public VoceaForm CreateNewForm(LegacyForm legacyForm)
    {
        return new VoceaForm
        {
            FormName = legacyForm.Title,
            CreatedAt = legacyForm.CreatedAt,
            Id = legacyForm.Id
        };
    }
    
    public LegacyFormContentData DeserializeLegacyFormContent(string content)
    {
        return JsonSerializer.Deserialize<LegacyFormContentData>(content);
    }
    
    public void ProcessLegacySectionList(List<LegacyQuestionSection> legacySectionList, VoceaForm newForm, ref int formQuestionsCounter)
    {
        foreach (var legacyQuestionSection in legacySectionList)
        {
            Question question = new Question();
            question.LegacyFormOrderNumber = formQuestionsCounter;
            ProcessLegacyQuestionSection(legacyQuestionSection, question);
            if (newForm.Questions is null)
                newForm.Questions = new List<Question>();
            newForm.Questions.Add(question);
            formQuestionsCounter++;
        }
    }
    
    public void ProcessLegacyQuestionSection(LegacyQuestionSection legacyQuestionSection, Question question)
    {
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
                    QuestionOptions questionOptions = new QuestionOptions
                    {
                        OptionText = questionOrLabel.Rasp,
                        Question = question
                    };
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
        }
    }
    

    public VoceaForm BuildVoceaFormInMemory(LegacyForm legacyForm)
    {
        VoceaForm newForm = CreateNewForm(legacyForm);
        LegacyFormContentData legacyFormContentData = DeserializeLegacyFormContent(legacyForm.Content);
        int formQuestionsCounter = 1;
        
        foreach (var legacySectionList in legacyFormContentData.Chestionar)
        {
            ProcessLegacySectionList(legacySectionList, newForm, ref formQuestionsCounter);
        }

        return newForm;
    }
    
    public void SaveVoceaFormToDatabase(VoceaForm newForm)
    {
        //Set default language - Romanian
        newForm.LanguageId = 4;
    }
    
    public void Migrate()
    {
        List<LegacyForm> legacyForms = CollectLegacyForms();
        List<VoceaForm> newForms = new List<VoceaForm>();
        foreach (var legacyForm in legacyForms)
        {
            VoceaForm newForm = BuildVoceaFormInMemory(legacyForm);
            newForms.Add(newForm);
        }
        foreach(var newForm in newForms)
        {
            SaveVoceaFormToDatabase(newForm);
        }
    }
}