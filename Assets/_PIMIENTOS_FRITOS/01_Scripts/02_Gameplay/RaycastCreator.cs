using UnityEditor;
using UnityEngine;

public class RaycastCreator : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CreateRaycast();
    }

    void CreateRaycast()
    {

        Physics2D.Raycast(transform.position, Vector2.down);
        Debug.DrawRay(transform.position, Vector2.down * 10, Color.red);
    }
}
