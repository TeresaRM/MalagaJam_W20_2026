using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements;

public class CheckPoint : MonoBehaviour
{

    void Awake()
    {

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cinta"))
        {
            if (PointsManager.Instance.GetIsPasted())
            {
                PointsManager.Instance.SetCheckpointPass();

                Destroy(gameObject);
            }
        }

    }


}
