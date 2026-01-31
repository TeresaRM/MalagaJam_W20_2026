using System.Drawing;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{


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
            Debug.Log("Checkpoint reached!");
            PointsManager.Instance.SetCheckpointPass();


            Destroy(gameObject);
        }
    }
}
