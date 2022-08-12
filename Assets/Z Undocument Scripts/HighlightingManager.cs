using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightingManager : MonoBehaviour
{
    public static HighlightingManager Instance;

    [SerializeField]
    private Color outlineColor = Color.red;

    [SerializeField, Range(0f, 10f)]
    private float outlineWidth = 10f;

    [SerializeField]
    private Color selectedColor = Color.green;

    [SerializeField, Range(0f, 10f)]
    private float selectedWidth = 10f;

    [SerializeField]
    private List<GameObject> SelectedObjects;

    public bool MultiSelectOn
    {
        get;
        set;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void AddHighlight(GameObject target)
    {
        Outline outline;

        outline = target.GetComponent<Outline>();

        if (!outline)
            outline = target.AddComponent<Outline>();

        outline.OutlineColor = outlineColor;
        outline.OutlineWidth = outlineWidth;
    }

    public void RemoveHighlight(GameObject target)
    {
        Outline outline = target.GetComponent<Outline>();


        if (outline != null)
        {
            if (IsSelected(target))
            {
                outline.OutlineColor = selectedColor;
                outline.OutlineWidth = selectedWidth;
            } else
                Destroy(outline);
        }
    }

    public void AddSelected(GameObject target)
    {
        if (!MultiSelectOn)
            RemoveAllSelected();

        Outline outline;

        outline = target.GetComponent<Outline>();

        if (!outline)
            outline = target.AddComponent<Outline>();

        outline.OutlineColor = selectedColor;
        outline.OutlineWidth = selectedWidth;

        if(!IsSelected(target))
            SelectedObjects.Add(target);
    }

    public void RemoveSelected(GameObject target)
    {
        if(IsSelected(target))
            SelectedObjects.Remove(target);
        RemoveHighlight(target);
    }

    public void RemoveAllSelected()
    {
        foreach (GameObject obj in SelectedObjects)
        {
            RemoveSelected(obj);
        }
    }

    private bool IsSelected(GameObject target)
    {
        return SelectedObjects.Contains(target);
    }
}