using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private int startingPoint = 0;
    [SerializeField] private Transform[] points;

    private int currentPointIndex;

    private void Start()
    {
        if (points == null || points.Length == 0)
        {
            Debug.LogError("MovingPlatform: nessun punto assegnato!");
            enabled = false;
            return;
        }

        if (startingPoint < 0 || startingPoint >= points.Length)
        {
            Debug.LogWarning("MovingPlatform: startingPoint fuori range, imposto a 0.");
            startingPoint = 0;
        }

        currentPointIndex = startingPoint;
        transform.position = points[currentPointIndex].position;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, points[currentPointIndex].position) < 0.02f)
        {
            currentPointIndex = (currentPointIndex + 1) % points.Length;
        }

        transform.position = Vector3.MoveTowards(transform.position, points[currentPointIndex].position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
