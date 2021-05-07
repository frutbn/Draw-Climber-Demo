using System.Collections.Generic;
using UnityEngine;

public sealed class Line : MonoBehaviour
{
    [SerializeField] private Vector3 Offset;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Camera targetCamera;
    [SerializeField] private Player player;
    private List<Vector3> linePositions = new List<Vector3>();

    private void Awake()
    {
        this.gameObject.SetActive(lineRenderer);
    }

    private void OnEnable()
    {
        this.gameObject.SetActive(lineRenderer);
    }

    private void Update()
    {
        if (!GameManager.Instance.GetIsGameStarted) return;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            lineRenderer.positionCount = 0;
            linePositions.Clear();
            player.DestroyLegs();
            GameManager.Instance.ChangeGameSpeed(.25f);
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 0f;
            Vector3 newPosition = targetCamera.ScreenToWorldPoint(mousePos);

            newPosition += Offset;

            if (linePositions.Contains(newPosition)) return;

            linePositions.Add(newPosition);
            lineRenderer.positionCount = linePositions.Count;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, newPosition);
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            player.CreateLeg(Leg.Left, lineRenderer, 10f);
            player.CreateLeg(Leg.Right, lineRenderer, 10f);
            GameManager.Instance.ChangeGameSpeed(1f);
        }
    }
}