using System.Collections;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private int startingPoint = 0;
    [SerializeField] private Transform[] points;

    private int i;

    private void Start()
    {
        if (points.Length == 0)
        {
            Debug.LogError("Nessun punto assegnato alla piattaforma.");
            enabled = false;
            return;
        }

        transform.position = points[startingPoint].position;
        i = startingPoint;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, points[i].position) < 0.02f)
        {
            i++;
            if (i >= points.Length)
            {
                i = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
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
