using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connect : MonoBehaviour
{
    [SerializeField] LineRenderer lr;
    [SerializeField] EdgeCollider2D ec;

    Vector2[] MousePos;
    bool isMakeLine = false;

    private void Start()
    {
        MousePos = ec.points;
    }

    private void Update()
    {
        if (isMakeLine)
        {
            MousePos[1] = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lr.SetPosition(1, MousePos[1]);
            ec.points = MousePos;
        }
    }
    public void OnDown() 
    {
        MousePos[0] = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lr.SetPosition(0, MousePos[0]);
        isMakeLine = true;
    }
    public void OnUp() 
    {
        isMakeLine = false;
    }
}
