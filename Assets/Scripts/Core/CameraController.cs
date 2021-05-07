using UnityEngine;

public sealed class CameraController : MonoBehaviour
{
    [SerializeField] private Transform Target;
    [SerializeField] private Vector3 Offset;
    [SerializeField] private float Speed = 15f;

    private Quaternion FirstRotation;

    private void Awake()
    {
        FirstRotation = transform.rotation;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target.position + Offset, Speed * Time.deltaTime);
    }

    public void BackOrigin()
    {
        transform.position = Vector3.zero + Offset;
        transform.rotation = FirstRotation;
    }
}