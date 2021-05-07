using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    private Vector3 FirstPos;

    private void Awake()
    {
        FirstPos = this.transform.position;
    }

    public void GoFirstPosition()
    {
        this.transform.position = FirstPos;
    }
}