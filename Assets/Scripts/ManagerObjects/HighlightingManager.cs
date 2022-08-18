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
        Debug.Log("Highlight Added");
        Outline outline;

        outline = target.GetComponent<Outline>();

        if (!outline)
            outline = target.AddComponent<Outline>();

        outline.OutlineColor = outlineColor;
        outline.OutlineWidth = outlineWidth;
    }

    public void RemoveHighlight(GameObject target)
    {
        Debug.Log("Highlight Removed");
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
        Debug.Log("Select Added");
        if (!MultiSelectOn)
            RemoveAllSelected(target);

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
        Debug.Log("Select Removed");
        if (IsSelected(target))
        {
            Outline outline;

            outline = target.GetComponent<Outline>();

            SelectedObjects.Remove(target);
            Destroy(outline);
        }
    }

    public void RemoveAllSelected(GameObject? exception)
    {
        foreach (GameObject obj in SelectedObjects)
        {
            if (obj != exception)
                RemoveSelected(obj);
        }
    }

    private bool IsSelected(GameObject target)
    {
        return SelectedObjects.Contains(target);
    }

    public void ReloadSelected(GameObject target)
    {
        if (IsSelected(target))
        {
            Outline outline;

            outline = target.GetComponent<Outline>();

            if (!outline)
                outline = target.AddComponent<Outline>();

            outline.OutlineColor = selectedColor;
            outline.OutlineWidth = selectedWidth;
        }
    }
}