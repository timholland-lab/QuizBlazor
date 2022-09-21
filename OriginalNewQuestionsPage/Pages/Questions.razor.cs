using Newtonsoft.Json;
using Microsoft.AspNetCore.Components;

namespace OriginalNewQuestionsPage.Pages
{
    public partial class Questions
    {
        public List<Questions_Answers> response = new();

        public Questions()
        {
            LoadQuestionsFromJson();
        }

        public async Task LoadQuestionsFromJson()
        {
            await readQuestionsJsonFile();
        }

        protected int questionIndex = 0;
        protected int score = 0;

        private readonly ILogger<Questions> _logger;

        public Questions(ILogger<Questions> logger)
        {
            _logger = logger;
        }

        protected void OptionSelected(string option)
        {
            if (option == response[questionIndex].Answers)
            {
                score++;
            }
            questionIndex++;
        }


        public string myStr = "df";
        // Location of the json file that contains all the questions. Need to change since hard coded.
        public string questionsJson = "C:/Elasta2/src/Web/Pages/questions.json";
      

        // read in questions from json file and store as array.
        private async Task readQuestionsJsonFile()
        {
            string json = String.Empty;

            using (StreamReader r = new StreamReader(questionsJson))
            {
                json = r.ReadToEnd();
                if (JsonConvert.DeserializeObject<List<Questions_Answers>>(json) != null)
                {
                    response = JsonConvert.DeserializeObject<List<Questions_Answers>>(json);
                }
            }
        }

        public class Questions_Answers
        {
            public string? Question { get; set; }
            public int Id { get; set; }
            public List<List<string>>? Answers { get; set; }
        }

        //public class Question
        //{
        //    public string QuestionTitle { get; set; } = string.Empty;
        //    public IEnumerable<string> Options { get; set; } = new List<string>();
        //    public string Answer { get; set; } = string.Empty;
        //}

        public class OptionCardBase : ComponentBase
        {
            [Parameter]
            public string Option { get; set; } = string.Empty;
            [Parameter]
            public EventCallback<string> OnOptionSelected { get; set; }

            protected async void SelectOption()
            {
                await OnOptionSelected.InvokeAsync(Option);
            }
        }

    }
}