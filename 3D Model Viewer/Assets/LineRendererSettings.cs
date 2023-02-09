[SerializeField] LineRenderer rend;

Vector3[] points;

void Start()
{
    rend = gameObject.getComponent<LineRenderer>();

    points = new Vector3[2];

    points[0] = Vector3.zero;

    points[1] = transform.position + new Vector3(0, 0, 20);

    rend.setPositions(points);
    rend.enabled = true;

}


public LayerMask layermask;

public void AlignLineRenderer(LineRenderer rend)
{
    Ray ray;
    ray = new Ray(transform.position, transform.forward);
    RaycastHit hit;
    
    if (Phyisics.Raycast(ray, out hit, layerMask))
    {
        points[1] = transform.forward + new Vector3(0, 0, hit.distance);
    } else {
        points[1] = transform.forward + new Vector3(0, 0, 20);

    }
    rend.SetPositions(points);
}