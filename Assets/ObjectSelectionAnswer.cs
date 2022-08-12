using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjectSelectionAnswer : QuizTakingAnswer
{
    [SerializeField] protected Toggle AnswerToggle;

    [Header("Visible for debug purposes")]
    [SerializeField] private GameObject targetObj;
    [SerializeField] private GameObject targetGraphic;
    protected override void AnswerEntry()
    {
        targetAnswer.IsSelected = AnswerToggle.isOn;

        if (targetAnswer.IsSelected)
        {
            HighlightingManager.Instance.AddSelected(targetGraphic);
        } else
        {
            HighlightingManager.Instance.RemoveSelected(targetGraphic);
        }
    }

    protected override void ClassBuilder()
    {
        SetToggleGroup();
        targetObj = PlacedObjectsHandler.Instance.GetObject(targetAnswer.AnswerText);

        SaveablePlacedObject saveablePlacedObject = targetObj.GetComponent<SaveablePlacedObject>();

        if (saveablePlacedObject)
        {
            targetGraphic = saveablePlacedObject.GraphicDataObject;
        } else
        {
            targetGraphic = targetObj;
        }

        if (targetObj)
        {
            AddEventListeners();
        } else if (ErrorText)
        {
            ErrorText.text = "Object not found!";
            ErrorText.gameObject.SetActive(true);
        }
    }

    private void SetToggleGroup()
    {
        ToggleGroup toggleGroup = answerContainer.GetComponent<ToggleGroup>();
        if (toggleGroup != null)
        {
            AnswerToggle.group = toggleGroup;
        }
    }

    private void AddEventListeners()
    {
        XRBaseInteractable[] xrInteractables = targetObj.GetComponentsInChildren<XRBaseInteractable>();

        foreach (XRBaseInteractable interactable in xrInteractables)
        {
            interactable.hoverEntered.AddListener(HoverEntered);
            interactable.hoverExited.AddListener(HoverExited);
            interactable.selectExited.AddListener(SelectEntered);
        }
    }

    private void RemoveEventListeners()
    {
        XRBaseInteractable[] xrInteractables = targetObj.GetComponentsInChildren<XRBaseInteractable>();

        foreach (XRBaseInteractable interactable in xrInteractables)
        {
            interactable.hoverEntered.RemoveListener(HoverEntered);
            interactable.hoverExited.RemoveListener(HoverExited);
            interactable.selectExited.RemoveListener(SelectEntered);
        }
    }

    protected override void LoadSelected()
    {
        AnswerToggle.isOn = targetAnswer.IsSelected;
    }

    public void Toggle()
    {
        AnswerEntry();
    }

    public void HoverEntered(HoverEnterEventArgs args)
    {
        HighlightingManager.Instance.AddHighlight(targetGraphic);
    }

    public void HoverExited(HoverExitEventArgs args)
    {
        HighlightingManager.Instance.RemoveHighlight(targetGraphic);
    }

    public void SelectEntered(SelectExitEventArgs args)
    {
        AnswerToggle.isOn = !AnswerToggle.isOn;
    }

    protected void OnDestroy()
    {
        if (targetObj)
        {
            HighlightingManager.Instance.RemoveSelected(targetGraphic);
            RemoveEventListeners();
        }
    }
}
