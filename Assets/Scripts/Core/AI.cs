using UnityEngine;

[RequireComponent(typeof (Rigidbody))]
public class AI : Player
{
    [SerializeField] private float LegCheckTime = 5f;
    [SerializeField] private float MinSpeed = 3f;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Vector2 lineDistance;
    [SerializeField] private Vector2 lineCounts;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        InvokeRepeating("CheckLeg", 0f, LegCheckTime);
    }

    private void CheckLeg()
    {
        if (rb.velocity.x > MinSpeed) return;

        CreateLegProcess();
    }

    private void CreateLegProcess()
    {
        DestroyLegs();
        lineRenderer.positionCount = 0;

        int linePointCount = (int)Random.Range(lineCounts.x, lineCounts.y);
        lineRenderer.positionCount = linePointCount;

        for (int i = 1; i < lineRenderer.positionCount; i++)
        {
            Vector3 linePos = lineRenderer.GetPosition(i - 1);
            linePos.x += Random.Range(-lineDistance.x, lineDistance.x);
            linePos.y += Random.Range(-lineDistance.y, lineDistance.y);
            lineRenderer.SetPosition(i, linePos);
        }

        CreateLeg(Leg.Left, lineRenderer, 0f);
        CreateLeg(Leg.Right, lineRenderer, 0f);
    }
}