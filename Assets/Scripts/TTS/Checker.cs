using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class Checker : MonoBehaviour
{
    [SerializeField] private List<GameObject> gameObjects = new List<GameObject>();

    [SerializeField] private GameObject markerLine;

    [SerializeField] private string Text;

    public bool isDone = false;
    public bool isFinished = false;

    public delegate void CheckCallback(string data);
    public static event CheckCallback OnConditionFullfiled;

    private void Start()
    {
        int childCount = gameObject.transform.childCount;

        for (int i = 0; i < childCount; i++)
        {
            gameObjects.Add(transform.GetChild(i).gameObject);
        }
    }

    private void Update()
    {
        isDone = AreObjectiveDone();

        if (isDone && !isFinished)
        {
            OnConditionFullfiled?.Invoke(Text);
            markerLine.SetActive(true);
            isFinished = true;
        }
    }

    private bool AreObjectiveDone()
    {
        foreach (GameObject obj in gameObjects)
        {
            if (obj.activeSelf)
            {
                return false;
            }
        }

        return true;
    }
}
