using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuizMCAnswer : QuizAnswer
{
    public QuizMCAnswer(string answerText, bool isCorrect){
        AnswerText = answerText;
        IsSelected = false;
        CorrectAnswer = isCorrect.ToString();
    }

    public override string EnteredAnswer { get => GetEnteredValue(); set => throw new NotImplementedException(); }

    private string GetEnteredValue()
    {
        string returnString = "";
        if (IsSelected)
        {
            returnString += AnswerText;
        }
        return returnString;
    }

    public override string CorrectTextValue()
    {
        if (CorrectAnswer.ToLower() == "true")
            return AnswerText + "|";
        else
            return "";
    }

    public override QuizAnswer DefaultAnswer()
    {
        AnswerText = "New Answer";
        IsSelected = false;
        CorrectAnswer = "false";

        return this;
    }

    public override bool ValidateAnswer(string value)
    {
        bool conversionBool = false;
        bool canConvert = Boolean.TryParse(value, out conversionBool);

        if (canConvert)
        {
            return true;
        } else
        {
            ErrorManager.Instance.ThrowError("Invalid value: '" + value +"'. Answer value must be true or false!", true);
        }

        return false;
    }
}
