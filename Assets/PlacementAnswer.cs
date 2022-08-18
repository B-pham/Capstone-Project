using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class PlacementAnswer : QuizTakingAnswer
{
    [SerializeField] private string placementContainerName;
    [SerializeField] protected Toggle AnswerToggle;

    [Header("Visible for debug purposes")]
    [SerializeField] private GameObject targetObj;
    [SerializeField] private GameObject targetGraphic;

    private GameObject ContainerObject;
    private PlacedObjectsQuizTrigger placedObjectsQuizTrigger;

    public bool DisposeOnDeselect
    {
        get;
        private set;
    }

    public bool TrackTriggers
    {
        get;
        private set;
    }
    public void PlacementBuildMe(QuizAnswer answer, GameObject container, string placementContainerName)
    {
        BuildMe(answer, container);
        this.placementContainerName = placementContainerName;
        DisposeOnDeselect = true;
        TrackTriggers = false;
    }

    private void GetContainerObject()
    {
        ContainerObject = GameObject.Find(placementContainerName);
        placedObjectsQuizTrigger = ContainerObject.transform.Find("PlacedObjectsBox").gameObject.GetComponent<PlacedObjectsQuizTrigger>();

        placedObjectsQuizTrigger.AddPossibleAnswer(this);
    }
    protected override void AnswerEntry()
    {
        targetAnswer.IsSelected = AnswerToggle.isOn;

        if (targetAnswer.IsSelected)
        {
            HighlightingManager.Instance.AddSelected(targetGraphic);
        }
        else
        {
            HighlightingManager.Instance.RemoveSelected(targetGraphic);

            if (DisposeOnDeselect)
            {
                placedObjectsQuizTrigger.PlaceAtDisposal(targetGraphic);
            }
        }
    }

    public void Toggle()
    {
        AnswerEntry();
    }

    protected override void ClassBuilder()
    {
        GetContainerObject();
        SetToggleGroup();

        targetObj = PlacedObjectsHandler.Instance.GetObject(targetAnswer.AnswerText);

        SaveablePlacedObject saveablePlacedObject = targetObj.GetComponent<SaveablePlacedObject>();

        if (saveablePlacedObject)
        {
            targetGraphic = saveablePlacedObject.GraphicDataObject;
        }
        else
        {
            targetGraphic = targetObj;
        }

        if (targetObj)
        {
            AddEventListeners();
        }
        else if (ErrorText)
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

    protected override void LoadSelected()
    {
        AnswerToggle.isOn = targetAnswer.IsSelected;
        if (AnswerToggle.isOn)
            placedObjectsQuizTrigger.PlaceAtSpawn(targetGraphic);
    }

    private void AddEventListeners()
    {
        XRBaseInteractable[] xrInteractables = targetObj.GetComponentsInChildren<XRBaseInteractable>();

        foreach (XRBaseInteractable interactable in xrInteractables)
        {
            interactable.hoverEntered.AddListener(HoverEntered);
            interactable.hoverExited.AddListener(HoverExited);
            interactable.selectEntered.AddListener(SelectEntered);
            interactable.selectExited.AddListener(SelectExited);
        }
    }

    private void RemoveEventListeners()
    {
        XRBaseInteractable[] xrInteractables = targetObj.GetComponentsInChildren<XRBaseInteractable>();

        foreach (XRBaseInteractable interactable in xrInteractables)
        {
            interactable.hoverEntered.RemoveListener(HoverEntered);
            interactable.hoverExited.RemoveListener(HoverExited);
            interactable.selectEntered.RemoveListener(SelectEntered);
            interactable.selectExited.RemoveListener(SelectExited);
        }
    }

    public void HoverEntered(HoverEnterEventArgs args)
    {
        HighlightingManager.Instance.AddHighlight(targetGraphic);
    }

    public void HoverExited(HoverExitEventArgs args)
    {
        HighlightingManager.Instance.RemoveHighlight(targetGraphic);
    }

    public void SelectEntered(SelectEnterEventArgs args)
    {
        placedObjectsQuizTrigger.RemoveObject(targetGraphic);
        DisposeOnDeselect = false;
        TrackTriggers = true;
    }

    public void SelectExited(SelectExitEventArgs args)
    {
        DisposeOnDeselect = true;
        TrackTriggers = false;
    }

    public bool ObjectMatch(GameObject obj)
    {
        bool match = false;

        if (obj == targetGraphic)
        {
            match = true;
        }

        return match;
    }

    public void ObjectPlaced(bool value)
    {
        AnswerToggle.isOn = value;
    }

    private void OnDestroy()
    {
        if (targetObj)
        {
            HighlightingManager.Instance.RemoveSelected(targetGraphic);
            RemoveEventListeners();
        }
        if (placedObjectsQuizTrigger != null)
            placedObjectsQuizTrigger.RemovePossibleAnswer(this);
    }
}
