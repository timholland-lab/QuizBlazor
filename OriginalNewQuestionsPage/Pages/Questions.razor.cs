using Newtonsoft.Json;
using Microsoft.AspNetCore.Components;

namespace OriginalNewQuestionsPage.Pages
{
    public partial class Questions
    {
        public List<Questions_Answers> response = new();
        protected int questionIndex = 0;
        protected int score = 0;

        public Questions()
        {
            LoadQuestionsFromJson();
        }

        public async Task LoadQuestionsFromJson()
        {
            await readQuestionsJsonFile();
        }

        private readonly ILogger<Questions> _logger;

        public Questions(ILogger<Questions> logger)
        {
            _logger = logger;
        }

        protected void OptionSelected(string option)
        {
            if (option == response[questionIndex].Answer)
            {
                score++;
            }
            questionIndex++;
        }

        public string questionsJson = "C:/Lab/220910BlazorCallingJSFromComponent/OriginalNewQuestionsPage/OriginalNewQuestionsPage/Pages/questions.json";

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
            public List<string>? Answers { get; set; }
            public string? Answer { get; set; }
        }

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