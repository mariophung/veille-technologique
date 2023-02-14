using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

Vector3[] points;

GameObject panel;
Image img;
Button btn;

LayerMask layermask;

bool AlignLineRenderer(LineRenderer rend)
{
    Ray ray;
    ray = new Ray(transform.position, transform.forward);
    RaycastHit hit;
    bool hitBtn = false;

    if (Physics.Raycast(ray, out hit, layerMask))
    {
        points[1] = Vector3.zero + new Vector3(0, 0, hit.distance);
        rend.startColor = Color.red;
        rend.endColor = Color.red;
        btn = hit.collider.gameObject.GetComponent<Button>();
        hitBtn = true;
    }
    else
    {
        points[1] = Vector3.zero + new Vector3(0, 0, 50);
        rend.startColor = Color.green;
        rend.endColor = Color.green;
        hitBtn = false;
    }
    rend.SetPositions(points);
    rend.material.color = rend.startColor;
    return hitBtn;
}

void EventChangeOnClick()
{
    if (btn != null)
    {
        if (btn.name == "red_btn")
        {
            img.color = Color.red;
        }
        else if (btn.name == "blue_btn")
        {
            img.color = Color.blue;
        }
        else if (btn.name == "green_btn")
        {
            img.color = Color.green;
        }
    }
}


[SerializeField] LineRenderer rend;
void Start()
{
    rend = gameObject.getComponent<LineRenderer>();
    img = panel.GetComponent<Image>();
    points = new Vector3[2];

    points[0] = Vector3.zero;

    points[1] = transform.position + new Vector3(0, 0, 20);

    rend.SetPositions(points);
    rend.enabled = true;

}

void Update ()
{
    AlignLineRenderer(rend);
    
    if (AlignLineRenderer(rend) && Input.GetAxis("Submit") > 0)
       {
           btn.onClick.Invoke();
    }
}
