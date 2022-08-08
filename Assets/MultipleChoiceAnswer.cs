using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultipleChoiceAnswer : QuizTakingAnswer
{
    public void Toggle()
    {
        OnSelected();
    } 

    protected override void OnSelected()
    {
        targetAnswer.IsSelected = AnswerToggle.isOn;
    }

    protected override void SetToggleGroup()
    {
        ToggleGroup toggleGroup = answerContainer.GetComponent<ToggleGroup>();
        if (toggleGroup != null)
        {
            AnswerToggle.group = toggleGroup;
        }
    }

    protected override void LoadSelected()
    {
        AnswerToggle.isOn = targetAnswer.IsSelected;
    }

}
