using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectSelectionQuestion : QuizTakingQuestion
{
    protected override void ClearAnswers()
    {
        foreach (Transform child in answerContainer.transform)
        {
            Destroy(child.gameObject);
        }
    }

    protected override void LoadChooseMultiple()
    {
        bool multi = targetQuestion.ChooseMultiple;
        chooseMultipleText.gameObject.SetActive(multi);
        HighlightingManager.Instance.MultiSelectOn = multi;
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        HighlightingManager.Instance.MultiSelectOn = false;
    }
}
