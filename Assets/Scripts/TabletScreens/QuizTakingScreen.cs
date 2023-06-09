using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;

public class QuizTakingScreen : QuizScreen
{
    //Use this variable to interact with the active question that is currently meant to be visible.
    private QuizQuestion activeQuestion;

    [SerializeField] private TMPro.TMP_Text TitleText;
    [SerializeField] private AssessmentHandler assessmentHandler;

    //Prefabs for each quiz type
    [SerializeField] private QuizAnswerPrefabLoader QuizPrefabLoader;

    private int CurrentQuestionNum = 0;
    private int TotalQuestionsCount;

    [SerializeField] private TMPro.TMP_Text QuestionProgress;

    [SerializeField] private TMPro.TMP_Text AnswerProgress;

    [SerializeField]private string professorEmail;
    [SerializeField]private TMPro.TMP_Text testName;
    [SerializeField]private TMPro.TMP_Text userName;
    [SerializeField]private string testScore;

    private void Awake()
    {
        quizObj = activeQuiz.GetComponent<QuizObj>();

        LoadTitle();
        QuestionCount();
        assessmentHandler.Setup(quizObj);
    }

    protected override void Reload()
    {
        //Base Clear
        base.Clear();

        //Enter additional methods you want to have run on reload here. 
        QuestionProgressTextUpdate();
        AnswerProgressTextUpdate();
        LoadQuestion();

        //Base Reload
        base.Reload();
    }

    //Additional methods below
    private void LoadTitle()
    {
        TitleText.text = base.quizObj.Name;
    }

    private void LoadQuestion()
    {
        Debug.Log("Loading " + base.quizObj.Name);
        activeQuestion = base.quizObj.GetQuestion(CurrentQuestionNum);

        GameObject newQuestion;

        GameObject questionPrefab = GetQuestionTypePrefab();

        if (questionPrefab != null) { 
            newQuestion = Instantiate(questionPrefab, base.ContentField.transform);
            newQuestion.GetComponent<QuizTakingQuestion>().BuildMe(activeQuestion, this); //Create a component in your Answer prefab and include a public BuildMe script that takes data from QuizQuestion.cs
        }
    }

    private void QuestionCount()
    {
        TotalQuestionsCount = base.quizObj.QuestionsList.Count;
    }

    private void QuestionProgressTextUpdate()
    {
        string QuestionProgressText;
        QuestionProgressText = "Question ";
        QuestionProgressText += (CurrentQuestionNum + 1).ToString();
        QuestionProgressText += " of " + TotalQuestionsCount;

        QuestionProgress.text = QuestionProgressText;
    }

    private void AnswerProgressTextUpdate()
    {
        string AnswerProgressText;
        AnswerProgressText = assessmentHandler.QuestionsAnsweredCount.ToString();
        AnswerProgressText += " of " + TotalQuestionsCount;
        AnswerProgressText += " Questions Answered";

        AnswerProgress.text = AnswerProgressText;
    }

    private GameObject GetQuestionTypePrefab()
    {
        Type enumType = typeof(QuizQuestion.QuestionTypes);
        string questionTypeString = activeQuestion.Type;

        if (Enum.IsDefined(enumType, questionTypeString))
        {
            QuizQuestion.QuestionTypes quizType = (QuizQuestion.QuestionTypes)Enum.Parse(enumType, questionTypeString);

            return QuizPrefabLoader.GetPrefabType(quizType);
        }

        return null;
    }

    public void BackButton()
    {
        QuizQuestion question = base.quizObj.GetQuestion(CurrentQuestionNum);
        assessmentHandler.AddQuestion(question);

        if (CurrentQuestionNum > 0)
        {
            CurrentQuestionNum--;
            Reload();
        }
    }

    public void NextButton()
    {
        QuizQuestion question = base.quizObj.GetQuestion(CurrentQuestionNum);
        assessmentHandler.AddQuestion(question);

        if (CurrentQuestionNum < (TotalQuestionsCount -1))
        {
            CurrentQuestionNum++;
            Reload();
        }
    }

    public void SubmitButton()
    {
        QuizQuestion question = base.quizObj.GetQuestion(CurrentQuestionNum);
        assessmentHandler.AddQuestion(question);
        Reload();

        if (assessmentHandler.QuestionsAnsweredCount == TotalQuestionsCount)
        {
            Debug.Log("Quiz Complete");
        } else
        {
            Debug.Log("Quiz Incomplete! Throw warning!");
        }

        assessmentHandler.SaveQuizForSubmission();
    }

    #region QuizSubmission Functions
    //Submit Quiz Score Functions
    public void sendScore()
    {
        StartCoroutine(submitScore(professorEmail, testName.text, userName.text, testScore));
    }
    IEnumerator submitScore(string professorEmail, string testName, string userName, string testScore)
    {

        WWWForm form = new WWWForm();
        form.AddField("professorEmailPost", professorEmail);
        form.AddField("testNamePost", testName);
        form.AddField("userNamePost", userName);
        form.AddField("testScorePost", testScore);

        using (UnityWebRequest www = UnityWebRequest.Post("https://kvrconnect.azurewebsites.net/App/sendScore.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
                //LoginMenuTextboxMessage.text = (www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                //LoginMenuTextboxMessage.text = (www.downloadHandler.text);
            }

        }
    }
    #endregion

}
