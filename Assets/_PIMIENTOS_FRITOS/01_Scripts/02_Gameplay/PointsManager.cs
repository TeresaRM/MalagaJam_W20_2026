
using System.Drawing;
using UnityEditor;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    public int numberOfObjects = 20;

    public float radius = 5f;

    public GameObject checkpoint;

    public PolygonCollider2D col;

    public Vector2[] Points;
    public float offset = 0.5f;

    public int checkpointpass = 0;

    public float time = 0;

    public float totalPoints = 0;
    public static PointsManager Instance { get; private set; }

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
        // var r = GetComponent<Renderer>();
        // if (r == null)
        //     return;
        // var bounds = r.bounds;

        // Debug.Log(bounds);

        var points = col.points;
        numberOfObjects = points.Length;
        Debug.Log(points);

        // for (int i = 0; i < col.pathCount; ++i)
        // {
        //     Debug.Log(col.GetPath(i).Length);
        // }
        for (int i = 0; i < points.Length; i++)
        {
            var positionWorld = col.transform.TransformPoint(points[i] * offset);

            Instantiate(checkpoint, positionWorld, Quaternion.identity);
        }


    }

    // Update is called once per frame
    void Update()
    {

        time += 1 * Time.deltaTime;

    }

    public void SetCheckpointPass()
    {
        checkpointpass++;

        totalPoints = (float)checkpointpass / (float)numberOfObjects * 1000f - time;
    }



}
