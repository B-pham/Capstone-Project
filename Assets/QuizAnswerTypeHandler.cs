using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class QuizAnswerTypeHandler
{
    public static QuizAnswer BuildAnswerOfType(QuizQuestion.QuestionTypes questionType, string answerText, string correctText = "false")
    {
        QuizAnswer quizAnswer;

        switch (questionType)
        {
            case QuizQuestion.QuestionTypes.MultipleChoice:
                quizAnswer = BuildMultipleChoiceAnswer(answerText, Convert.ToBoolean(correctText));
                return quizAnswer;

            case QuizQuestion.QuestionTypes.ObjectSelection:
                return null;

            case QuizQuestion.QuestionTypes.Placement:
                return null;

            case QuizQuestion.QuestionTypes.Sequence:
                quizAnswer = BuildSequenceAnswer(answerText, Convert.ToInt16(correctText));
                return quizAnswer;

            default:
                return null;
        }
    }

    public static List<QuizAnswer> BuildAnswersOfType(QuizQuestion.QuestionTypes questionType, string[] answersArray, string[] correctAnswersArray)
    {
        List<QuizAnswer> quizAnswerList = new List<QuizAnswer>(); ;

        switch (questionType)
        {
            case QuizQuestion.QuestionTypes.MultipleChoice:
                BuildMultipleChoiceAnswers(quizAnswerList, answersArray, correctAnswersArray);
                break;

            case QuizQuestion.QuestionTypes.ObjectSelection:
                break;

            case QuizQuestion.QuestionTypes.Placement:
                break;

            case QuizQuestion.QuestionTypes.Sequence:
                BuildSequenceAnswers(quizAnswerList, answersArray, correctAnswersArray);
                break;

            default:
                break;
        }

        return quizAnswerList;
    }

    private static QuizAnswer BuildMultipleChoiceAnswer(string answerText, bool isCorrect)
    {
        QuizAnswer quizAnswer = new QuizMCAnswer(answerText, isCorrect);

        return quizAnswer;
    }

    private static void BuildMultipleChoiceAnswers(List<QuizAnswer> answerList, string[] answersArray, string[] correctAnswersArray)
    {
        for (int i = 0; i < answersArray.Length; i++)
        {
            //Remove starting and ending whitespace
            answersArray[i] = answersArray[i].TrimStart(' ');
            answersArray[i] = answersArray[i].TrimEnd(' ');
        }

        for (int i = 0; i < correctAnswersArray.Length; i++)
        {
            //Remove starting and ending whitespace
            correctAnswersArray[i] = correctAnswersArray[i].TrimStart(' ');
            correctAnswersArray[i] = correctAnswersArray[i].TrimEnd(' ');
        }

        foreach (string answer in answersArray)
        {
            bool isCorrect = false;

            if (correctAnswersArray.Contains(answer))
            {
                isCorrect = true;
            }

            QuizAnswer quizAnswer = BuildMultipleChoiceAnswer(answer, isCorrect);
            answerList.Add(quizAnswer);
        }
    }

    private static QuizAnswer BuildSequenceAnswer(string answerText, int seqValue)
    {
        QuizAnswer quizAnswer = new QuizSeqAnswer(answerText, seqValue);

        return quizAnswer;
    }

    private static void BuildSequenceAnswers(List<QuizAnswer> answerList, string[] answersArray, string[] correctAnswersArray)
    {
        for (int i = 0; i < answersArray.Length; i++)
        {
            //Remove starting and ending whitespace
            answersArray[i] = answersArray[i].TrimStart(' ');
            answersArray[i] = answersArray[i].TrimEnd(' ');
        }

        for (int i = 0; i < correctAnswersArray.Length; i++)
        {
            //Remove starting and ending whitespace
            correctAnswersArray[i] = correctAnswersArray[i].TrimStart(' ');
            correctAnswersArray[i] = correctAnswersArray[i].TrimEnd(' ');
        }

        foreach (var answer in answersArray.Select((value, index) => (value, index)))
        {
            int seqValue = 0;

            if (answer.index < correctAnswersArray.Length)
            {
                seqValue = Convert.ToInt32(correctAnswersArray[answer.index]);
            }

            QuizAnswer quizAnswer = BuildSequenceAnswer(answer.value, seqValue);
            answerList.Add(quizAnswer);
        }
    }

    public static List<QuizAnswer> SwapTypes(List<QuizAnswer> answers, QuizQuestion.QuestionTypes type)
    {
        QuizAnswer newAnswer;

        List<QuizAnswer> newAnswers = new List<QuizAnswer>();

        foreach (QuizAnswer answer in answers)
        {
            switch (type)
            {
                case QuizQuestion.QuestionTypes.MultipleChoice:
                    newAnswer = new QuizMCAnswer("", false);
                    break;

                case QuizQuestion.QuestionTypes.ObjectSelection:
                    newAnswer = new QuizMCAnswer("", false);
                    break;

                case QuizQuestion.QuestionTypes.Placement:
                    newAnswer = new QuizMCAnswer("", false);
                    break;

                case QuizQuestion.QuestionTypes.Sequence:
                    newAnswer = new QuizSeqAnswer("", 1);
                    break;

                default:
                    newAnswer = new QuizMCAnswer("", false);
                    break;
            }

            MoveValues(answer, newAnswer);

            newAnswers.Add(newAnswer);
        }

        answers.Clear();

        return newAnswers;
    }

    private static void MoveValues(QuizAnswer oldAnswer, QuizAnswer newAnswer)
    {
        newAnswer.AnswerText = oldAnswer.AnswerText;
        newAnswer.CorrectAnswer = oldAnswer.CorrectAnswer;
    }
}
