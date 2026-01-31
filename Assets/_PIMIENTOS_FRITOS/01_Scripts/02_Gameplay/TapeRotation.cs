using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UIElements;

public class TapeRotation : MonoBehaviour
{
    private Vector3 mousePos;
    private float previousLocation;
    private float currentLocation;
    [SerializeField] private float _errorMargin = 0.5f;
    [SerializeField] private float _rotationSpeed = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        previousLocation = mousePos.x;
    }

    // Update is called once per frame
    void Update()
    {
        currentLocation = mousePos.x;

        if (currentLocation < previousLocation - _errorMargin)
        {

        } else if (currentLocation > previousLocation + _errorMargin)
        {

        }
    }
}
