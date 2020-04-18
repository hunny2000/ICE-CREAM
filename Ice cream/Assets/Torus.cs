using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Torus : MonoBehaviour
{
    public Material Choclate;
    public Material Strawberry;
    public Material Vanilla;

    private static float Pi = 3.14159f;
    public GameObject Cyl;
    public float segmentRadius = 1f;
    public float tubeRadius = 0.1f;
    public int segments = 32;
    public int tubes = 12;
    public bool Pressed = false;

    public List<Vector3> Pos;
    public int Counter;
    public int CurPos = 0;

    //Create float for X Y Z coordinayes
    float x = 0;
    float y = 0;
    float z = 0;
    float Z = 0;
    float X = 0;

    private void Awake()
    {
        torus();
        Counter = Pos.Count;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Cyl.GetComponent<MeshRenderer>().material = Choclate;
            Spawn();
        }
        if (Input.GetKey(KeyCode.S))
        {
            Cyl.GetComponent<MeshRenderer>().material = Strawberry;
            Spawn();
        }
        if (Input.GetKey(KeyCode.D))
        {
            Cyl.GetComponent<MeshRenderer>().material = Vanilla;
            Spawn();
        }
    }
    public void Spawn()
    {
        Pos[CurPos] = new Vector3(Pos[CurPos].x, Pos[CurPos].y, X + Pos[CurPos].z);

        GameObject C = GameObject.Instantiate(Cyl, Pos[CurPos], Quaternion.Euler(0, 0, Z), this.transform);
        
        Z += 3f;
        X += 0.007f;

        CurPos += 1;
    }

    public void torus()
    {

        // Calculate size of segment and tube
        float segmentSize = 2 * Pi / segments;
        float tubeSize = 2 * Pi / tubes;

        // Loop through number of tubes
        for (int H = 0; H < 7; H++)
        {
            {
                for (int i = 0; i < segments; i++)
                {
                    for (int j = 0; j < tubes; j++)
                    {
                        // Calculate X, Y, Z coordinates.
                        x = (segmentRadius + tubeRadius * Mathf.Cos(j * tubeSize)) * Mathf.Cos(i * segmentSize);
                        y = (segmentRadius + tubeRadius * Mathf.Cos(j * tubeSize)) * Mathf.Sin(i * segmentSize);
                        z = tubeRadius * Mathf.Sin(j * tubeSize);

                    }
                    Pos.Add(new Vector3(x, y, z));
                }
            }
            segmentRadius -= 0.3f;
        }
        //this.transform.Rotate(Vector3.right, -90f);
    }
}