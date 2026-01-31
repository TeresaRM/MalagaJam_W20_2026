
using System.Collections.Generic;
using System.Drawing;
using UnityEditor;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    public int numberOfObjects = 20;

    public float radius = 5f;

    public GameObject checkpoint;

    // public PolygonCollider2D col
    public float offset = 0.5f;

    public int checkpointpass = 0;

    public float time = 0;

    public float totalPoints = 0;
    public static PointsManager Instance { get; private set; }

    public bool isPasted = false;
    public List<PolygonCollider2D> polis = new List<PolygonCollider2D>();
    private void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    void Start()
    {
        foreach (PolygonCollider2D childCol in polis)
        {
            var points = childCol.points;
            numberOfObjects += points.Length;
            for (int i = 0; i < points.Length; i++)
            {
                var positionWorld = childCol.transform.TransformPoint(points[i] * offset);
                Instantiate(checkpoint, positionWorld, Quaternion.identity);
            }
        }
    }

    void Update()
    {
        time += 1 * Time.deltaTime;
    }

    public void SetCheckpointPass()
    {
        checkpointpass++;

        totalPoints = (float)checkpointpass / (float)numberOfObjects * 1000f - time;
    }

    public float GetTotalPoints()
    {
        return totalPoints;
    }
    public bool GetIsPasted()
    {
        return isPasted;
    }

    public void SetIsPasted(bool pasted)
    {
        isPasted = pasted;
    }


}
