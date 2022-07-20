using Hablamos;
using System.Runtime.CompilerServices;

namespace Maui
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        private QuestionsFactory _questionsFactory;

        private Question _currentQuestion;

        private Button _answerButton;

        private Color _originalBackground;

        private Button _currentSelectedOption;

        public MainPage()
        {
            InitializeComponent();
            _questionsFactory = new QuestionsFactory();
            _originalBackground = Option1.BackgroundColor;
            RefreshOptions();
           
        }

        private void RefreshOptions()
        {
            Option1.BackgroundColor = Option2.BackgroundColor = Option3.BackgroundColor = Option4.BackgroundColor = _originalBackground;
            _currentQuestion = _questionsFactory.GetNextQuestion();
            var options = _currentQuestion.GetOptions();
            Verb.Text = _currentQuestion.Verb;

            Option1.Text = options[0];
            Option2.Text = options[1];
            Option3.Text = options[2];
            Option4.Text = options[3];

            if (Option1.Text == _currentQuestion.Translation)
            {
                _answerButton = Option1;
            }
            else if (Option2.Text == _currentQuestion.Translation)
            {
                _answerButton = Option2;
            }
            else if (Option3.Text == _currentQuestion.Translation)
            {
                _answerButton = Option3;
            }
            else
            {
                _answerButton = Option4;
            }
        }

        private void OnOptionClicked (object sender, EventArgs e)
        {            
            Button clickedButton = sender as Button;
            _currentSelectedOption = clickedButton;
            
        }

        private void OnConfirm(object sender, EventArgs e)
        {
            Option1.Clicked -= OnOptionClicked;
            Option2.Clicked -= OnOptionClicked;
            Option3.Clicked -= OnOptionClicked;
            Option4.Clicked -= OnOptionClicked;
            if (_currentSelectedOption.Text.Equals(_currentQuestion.Translation))
            {
                _currentSelectedOption.BackgroundColor = Colors.Green;
            }
            else
            {
                _currentSelectedOption.BackgroundColor = Colors.Red;
                _answerButton.BackgroundColor = Colors.LightGreen;
            }

            Confirm.Text = "Next";
            Confirm.Clicked -= OnConfirm;
            Confirm.Clicked += OnNext;
        }

        private void OnNext(object sender, EventArgs e)
        {
            Confirm.Text = "Confirm";
            Confirm.Clicked -= OnNext;
            Confirm.Clicked += OnConfirm;

            Option1.Clicked += OnOptionClicked;
            Option2.Clicked += OnOptionClicked;
            Option3.Clicked += OnOptionClicked;
            Option4.Clicked += OnOptionClicked;

            RefreshOptions();
        }
    }
}