using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class QuizIdentifyManager : MonoBehaviour
{
    private GameObject currentTissue;
    public TextMeshProUGUI descText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI feedbackText;
    private int score;
    public Material boneMaterial;
    public Material softMaterial;
    public Material hardMaterial;
    public Material selectedMaterial;
    MeshRenderer tissueRenderer;
    public GameObject compactButton;
    public GameObject cancellousButton;
    public GameObject newQuestions;

    public GameObject[] tissues;
    private int questionNum;
    public int maxQuestions;
    Dictionary<GameObject, int> duplicateTracker;

    public AudioSource correct;
    public AudioSource incorrect;

    //This will allow the script to call a method from another script
    public QuestionManager questionManager;

    // Start is called before the first frame update
    void Start()
    {

        //initialize values
        questionManager = GameObject.FindObjectOfType(typeof(QuestionManager)) as QuestionManager;

        feedbackText.text = "";

        newQuestions.SetActive(false);
        questionNum = 1;
        score = 0;
        duplicateTracker = new Dictionary<GameObject, int>();

        //Add all tissues to dictionary that will be used for tracking how many times each tissue has been selected. Keys are tissue objects, values are number of times selected
        //This is needed because each tissue can be selected randomly 2 times at most
        for (int i = 0; i < tissues.Length; i++)
        {
            if (!duplicateTracker.ContainsKey(tissues[i]))
            {
                duplicateTracker.Add(tissues[i], 0);
            }
        }


        //Pick a random tissue, add 1 to the number of times it's been selected in the duplicateTracker dictionary
        System.Random r = new System.Random();
        int randIndex = r.Next(0, tissues.Length);
        currentTissue = tissues[randIndex];
        duplicateTracker[currentTissue] += 1;


        //Change material on current tissue to visually show that it's the current tissue
        tissueRenderer = currentTissue.GetComponent<MeshRenderer>();
        tissueRenderer.material = selectedMaterial;

        

        descText.text = "Question " + questionNum + ": " + currentTissue.GetComponent<QuizTissue>().tissueName;
        questionNum++;



    }

    // Update is called once per frame
    void Update()
    {

        //If quiz is complete, hide buttons and display message + score, enable newQuestions button
        if (questionNum > maxQuestions + 1)
        {
            descText.text = "Quiz complete! Your score is " + score + " out of " + maxQuestions;

            compactButton.SetActive(false);
            cancellousButton.SetActive(false);
            newQuestions.SetActive(true);
            if (currentTissue.GetComponent<QuizTissue>().tissueName.Equals("Periosteum"))
            {
                tissueRenderer.material = hardMaterial;
            }
            else if (currentTissue.GetComponent<QuizTissue>().tissueName.Equals("Trabecula"))
            {
                tissueRenderer.material = softMaterial;
            }
            else
            {
                tissueRenderer.material = boneMaterial;
            }

        }
    }

    public void onStart()
    {
        questionManager = GameObject.FindObjectOfType(typeof(QuestionManager)) as QuestionManager;
        feedbackText.text = "";
        questionNum = 1;
        score = 0;
        duplicateTracker = new Dictionary<GameObject, int>();
        compactButton.SetActive(true);
        cancellousButton.SetActive(true);
        //Add all tissues to dictionary that will be used for tracking how many times each tissue has been selected. Keys are tissue objects, values are number of times selected
        //This is needed because each tissue can be selected randomly 2 times at most
        for (int i = 0; i < tissues.Length; i++)
        {
            if (!duplicateTracker.ContainsKey(tissues[i]))
            {
                duplicateTracker.Add(tissues[i], 0);
            }
        }


        //Pick a random tissue, add 1 to the number of times it's been selected in the duplicateTracker dictionary
        System.Random r = new System.Random();
        int randIndex = r.Next(0, tissues.Length);
        currentTissue = tissues[randIndex];
        duplicateTracker[currentTissue] += 1;


        //Change material on current tissue to visually show that it's the current tissue
        tissueRenderer = currentTissue.GetComponent<MeshRenderer>();
        tissueRenderer.material = selectedMaterial;

        

        descText.text = "Question " + questionNum + ": " + currentTissue.GetComponent<QuizTissue>().tissueName;
        questionNum++;


    }

    //Handles highlighting tissue, changing tissue material, and changing text description
    public GameObject processTissue()
    {

        if (currentTissue != null)
        {
            if (currentTissue.GetComponent<QuizTissue>().tissueName.Equals("Periosteum"))
            {
                tissueRenderer.material = hardMaterial;
            }
            else if (currentTissue.GetComponent<QuizTissue>().tissueName.Equals("Trabecula"))
            {
                tissueRenderer.material = softMaterial;
            }
            else
            {
                tissueRenderer.material = boneMaterial;
            }

        }

        //Randomly select a tissue, if it has been selected twice already randomly select another one
        //if the tissue hasn't been selected twice already, use it for the current tissue

        // Known Bug: Due to the nature of this code it is possible that the tissue index required is not drawn causing potential repeats of a tissue.
        // The current quick fix is increasing the number of attempts the system has to draw the number needed, however this does not eliminate the problem.
        bool found = false;
        int count = 0;
        int maxSearchAttempt = 1000;
        while (!found)
        {
            count++;


            System.Random r = new System.Random();
            int randIndex = r.Next(0, tissues.Length);
            currentTissue = tissues[randIndex];
            if (duplicateTracker[currentTissue] == 0)
            {
                found = true;
                duplicateTracker[currentTissue] += 1;
            }

            if (count > maxSearchAttempt)
            {
                break;
            }
        }

        //Highlight the tissue and update text descriptions
        tissueRenderer = currentTissue.GetComponent<MeshRenderer>();
        tissueRenderer.material = selectedMaterial;
        descText.text = "Question " + questionNum + ": " + currentTissue.GetComponent<QuizTissue>().tissueName;
        questionNum++;
        return currentTissue;

    }

    public void compactPressed()
    {
        if (currentTissue.GetComponent<QuizTissue>().tissueType.Equals(QuizTissue.TissueType.compact))
        {
            score += 1;
            scoreText.text = "Score: " + score;
            feedbackText.text = "Correct!";
            correct.Play();

        }
        else
        {
            //incorrect animation
            feedbackText.text = "Incorrect, that tissue was " + currentTissue.GetComponent<QuizTissue>().tissueType;
            incorrect.Play();

        }
        processTissue();
    }

    public void cancellousPressed()
    {
        if (currentTissue.GetComponent<QuizTissue>().tissueType.Equals(QuizTissue.TissueType.cancellous))
        {
            score += 1;
            scoreText.text = "Score: " + score;
            feedbackText.text = "Correct!";
            correct.Play();
        }
        else
        {
            //incorrect animation
            feedbackText.text = "Incorrect, that tissue was " + currentTissue.GetComponent<QuizTissue>().tissueType;
            incorrect.Play();

        }
        processTissue();


    }

    public void SetNewQuestions()
    {
        
        questionNum = 1;
        newQuestions.SetActive(false);
        compactButton.SetActive(false);
        cancellousButton.SetActive(false);
        scoreText.text = "Score: " + score;
        feedbackText.text = "";

        //Goes back to the question type selection
        questionManager.showAll();

    }
}
