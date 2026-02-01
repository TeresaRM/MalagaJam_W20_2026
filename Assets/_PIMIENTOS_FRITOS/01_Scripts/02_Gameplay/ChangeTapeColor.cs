using Unity.VisualScripting;
using UnityEngine;

public class ChangeTapeColor : MonoBehaviour
{

    private TrailRenderer trail;

    [SerializeField] private Color defaultColor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        trail = GetComponent<TrailRenderer>();

        //Interior de la cinta
        trail.startColor = defaultColor;
        trail.endColor = defaultColor;
    }

    public void SetColor()
    {
        Color currentBackground = PointsManager.Instance.GetColorFondo();
        trail.startColor = currentBackground;
        trail.endColor = currentBackground;
        Debug.Log(currentBackground.ToHexString());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SetColor();
            
        }
    }
}
