using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public GameObject Tube;
    public GameObject Cyl;
    public Torus Cream;
    public Material Choclate;
    public Material Strawberry;
    public Material Vanilla;

    public Texture ChocolateTexture;
    public Texture StrawberryTexture;
    public Texture VanillaTexture;

    public void Chocolate()
    {
        Cyl.GetComponent<MeshRenderer>().material = Choclate;
        Tube.GetComponent<MeshRenderer>().material = Choclate;
        Cream.Spawn();
    }
    public void Straw()
    {
        Cyl.GetComponent<MeshRenderer>().material = Strawberry;

        Tube.GetComponent<MeshRenderer>().material = Strawberry;
        Cream.Spawn();
    }
    public void Vani()
    {
        Cyl.GetComponent<MeshRenderer>().material = Vanilla;

        Tube.GetComponent<MeshRenderer>().material = Vanilla;
        Cream.Spawn();
    }

    private void OnGUI()
    {
        if (GUI.RepeatButton(MR(0.80f, 0.10f, 0.10f, 0.20f), ChocolateTexture))
        {
            Cyl.GetComponent<MeshRenderer>().material = Choclate;
            Tube.GetComponent<MeshRenderer>().material = Choclate;
            Cream.Spawn();
            Debug.Log("Clicked the button with an image");

        }
        if (GUI.RepeatButton(MR(0.80f, 0.40f, 0.10f, 0.20f), StrawberryTexture))
        {
            Cyl.GetComponent<MeshRenderer>().material = Strawberry;
            Tube.GetComponent<MeshRenderer>().material = Strawberry;
            Cream.Spawn();
            Debug.Log("Clicked the button with an image");

        }
        if (GUI.RepeatButton(MR(0.80f, 0.70f, 0.10f, 0.20f), VanillaTexture))
        {
            Cyl.GetComponent<MeshRenderer>().material = Vanilla;
            Tube.GetComponent<MeshRenderer>().material = Vanilla;
            Cream.Spawn();
            Debug.Log("Clicked the button with an image");

        }

    }
    Rect MR(float x, float y, float w, float h)
    {
        return new Rect(Screen.width * x, Screen.height * y, Screen.width * w, Screen.height * h);
    }
}

