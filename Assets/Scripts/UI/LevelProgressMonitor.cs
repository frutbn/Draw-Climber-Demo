using UnityEngine;
using UnityEngine.UI;

public sealed class LevelProgressMonitor : MonoBehaviour
{
    [SerializeField] private Image image;

    private Vector3 firstPlayerPosRef;
    private Transform PlayerPos;
    private Transform FinishPos;
    private float Distance;

    private void OnEnable()
    {
        PlayerPos = GameObject.FindWithTag("Player").transform;
        FinishPos = GameObject.FindWithTag("Finish").transform;

        firstPlayerPosRef = PlayerPos.position;
        Distance = Vector3.Distance(firstPlayerPosRef, FinishPos.localPosition);
    }

    private void Update()
    {
        image.fillAmount = 1f - ((Vector3.Distance(PlayerPos.position, FinishPos.position)) / Distance);
    }
}