using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;

namespace QuizTemplate
{
    public partial class MainPage : ContentPage
    {
        private List<string[]> quizQuestions;
        private int currentQuestionIndex = 0;
        private int score = 0;

        public MainPage()
        {
            InitializeComponent();

            quizQuestions = new List<string[]>
            {
                //              Question Label          Ans1,   Ans2    Ans3    Ans4    Correct Answer
                new string[] { "Pick the colour Red", "Blue", "Yellow", "Red", "Green", "Red" },
                new string[] { "Which one is NOT a car", "Ford", "Monkey", "Holden", "Opel", "Monkey" },
                new string[] { "Which animal is a Carnivore", "Lion", "Deer", "Rabbit", "Kola", "Lion" },
                // Add more questions as needed
            };

            UpdateQuestion();
        }

        private void UpdateQuestion()
        {
            if (currentQuestionIndex < quizQuestions.Count)
            {
                QuestionLabel.Text = quizQuestions[currentQuestionIndex][0];
                AnswerButton1.Text = quizQuestions[currentQuestionIndex][1];
                AnswerButton2.Text = quizQuestions[currentQuestionIndex][2];
                AnswerButton3.Text = quizQuestions[currentQuestionIndex][3];
            }
            else
            {
                QuestionLabel.Text = "Quiz Completed!";
                AnswerButton1.IsVisible = false;
                AnswerButton2.IsVisible = false;
                AnswerButton3.IsVisible = false;
            }
        }

        private void OnAnswerButtonClicked(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            string selectedAnswer = clickedButton.Text;
            string correctAnswer = quizQuestions[currentQuestionIndex][5];

            if (selectedAnswer == correctAnswer)
            {
                score++;
                ScoreLabel.Text = "Score: " + score.ToString();
            }

            currentQuestionIndex++;
            UpdateQuestion();
        }
    }
}
