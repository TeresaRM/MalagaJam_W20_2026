using UnityEngine;

public class GlueTape : MonoBehaviour
{

    private TrailRenderer _tapeTrail;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Start()
    {
        _tapeTrail = GetComponent<TrailRenderer>();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(1))
        {
            _tapeTrail.emitting = true;
            PointsManager.Instance.SetIsPasted(true);
        }
        else
        {
            _tapeTrail.emitting = false;
            PointsManager.Instance.SetIsPasted(false);
        }
            
    }
}
