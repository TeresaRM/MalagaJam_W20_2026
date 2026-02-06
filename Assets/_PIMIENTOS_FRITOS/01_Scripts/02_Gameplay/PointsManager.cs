
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PointsManager : MonoBehaviour
{
    [SerializeField] private GameObject checkPointLimit;
    [SerializeField] private CanvasGroup fadeCanvasGroup;

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

    public GameObject LevelUIManager;

    public RawImage imageFondo;

    public GameObject fondo;

    public TextMeshProUGUI timer;

    public TextMeshProUGUI percentText;

    public int level;
    public float percent;
    private int timerLeft = 360;
    private void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(gameObject);

        Instance = this;

    }
    void Start()
    {

        percentText.text = Mathf.RoundToInt(0 * 100f).ToString() + "%";
        foreach (PolygonCollider2D childCol in polis)
        {
            for (int j = 0; j < childCol.pathCount; j++)
            {
                var points = childCol.GetPath(j);
                numberOfObjects += points.Length;

                for (int i = 0; i < points.Length; i++)
                {
                    if (i % 3 == 0)
                    {
                        var positionWorld = childCol.transform.TransformPoint(points[i] * offset);

                        if (positionWorld.y > checkPointLimit.transform.position.y)
                        {

                            Instantiate(checkpoint, positionWorld, Quaternion.identity);
                        }
                        else
                        {
                            numberOfObjects--;
                        }


                    }
                    else
                    {

                        numberOfObjects--;
                    }
                }
            }


        }
    }

    void Update()
    {
        timerLeft = 240 - Mathf.RoundToInt(time);

        if (timerLeft <= 0 || GetPercentageCompleted() >= 100f)
        {
            fadeCanvasGroup.DOFade(1, 1f)
                .OnComplete(() => SceneManager.LoadScene(4));   // cargar pantalla de resultados
            // mainCamera.DOOrthoSize(5f, 2f);
            // LevelUIManager.GetComponent<LvlUIManager>().OpenResultsPanel();
        }
        else
        {
            time += 1 * Time.deltaTime;

            timer.text = timerLeft.ToString() + "s";
        }
    }

    public void SetCheckpointPass()
    {
        checkpointpass++;
        float percent = (float)checkpointpass / (float)numberOfObjects;
        totalPoints = percent * 1000f - time;

        percentText.text = Mathf.RoundToInt(percent * 100f).ToString() + "%";
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

    public float GetTime()
    {
        return time;
    }

    public float GetPercentageCompleted()
    {
        percent = (float)checkpointpass / (float)numberOfObjects * 100f;

        return percent;
    }


    public Color GetColorFondo()
    {
        SpriteRenderer sr = fondo.GetComponent<SpriteRenderer>();
        return sr.color;
    }

    public int GetLevel()
    {
        return level;
    }

    public void SetLevel(int lvl)
    {
        level = lvl;
    }


}
