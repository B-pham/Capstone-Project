using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacedObjectsQuizTrigger : MonoBehaviour
{
    [SerializeField] private GameObject SpawnPoint;
    [SerializeField] private GameObject DisposalPoint;

    [SerializeField] private List<GameObject> SelectedObjects;
    [SerializeField] private List<PlacementAnswer> PossibleAnswers;

    private void SelectObject(GameObject obj, bool? trigger = false)
    {
        PlacementAnswer answer = PossibleAnswer(obj);
        bool runThis = true;

        if ((bool)trigger)
        {
            runThis = answer.TrackTriggers;
        }
        if (runThis && answer != null)
        {
            Debug.Log(obj.name + " Placed");
            SelectedObjects.Add(obj);
            answer.ObjectPlaced(true);
        }
    }

    private PlacementAnswer PossibleAnswer(GameObject obj)
    {
        PlacementAnswer answer = null;

        foreach (PlacementAnswer ans in PossibleAnswers)
        {
            if (ans.ObjectMatch(obj))
            {
                answer = ans;
                break;
            }
        }

        return answer;
    }

    public void RemoveObject(GameObject obj, bool? trigger = false)
    {
        PlacementAnswer answer = PossibleAnswer(obj);

        bool runThis = true;

        if ((bool)trigger)
        {
            runThis = answer.TrackTriggers;
        }
        if (runThis && SelectedObjects.Contains(obj))
        {
            Debug.Log(obj.name + " Removed");
            SelectedObjects.Remove(obj);
            answer.ObjectPlaced(false);
        }
    }

    public void PlaceAtSpawn(GameObject obj)
    {
        obj.transform.position = SpawnPoint.transform.position;
    }

    public void PlaceAtDisposal(GameObject obj)
    {
        obj.transform.position = DisposalPoint.transform.position;
    }

    public void AddPossibleAnswer(PlacementAnswer possibleAnswer)
    {
        PossibleAnswers.Add(possibleAnswer);
    }

    public void RemovePossibleAnswer(PlacementAnswer possibleAnswer)
    {
        PossibleAnswers.Remove(possibleAnswer);
    }

    private void OnTriggerEnter(Collider other)
    {
        SelectObject(other.gameObject, true);
    }

    private void OnTriggerExit(Collider other)
    {
        RemoveObject(other.gameObject, true);
    }
}
