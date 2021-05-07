using UnityEngine;

public sealed class FinishObject : InteractiveObject
{
    private void OnTriggerEnter(Collider obj)
    {
        if (!CheckTag(obj.gameObject.tag)) return;
        Finish(obj.gameObject.tag);
    }

    private void OnCollisionEnter(Collision obj)
    {
        if (!CheckTag(obj.gameObject.tag)) return;
        Finish(obj.gameObject.tag);
    }

    private void Finish(string tag)
    {
        GameManager.Instance.ChangeGameSpeed(0f);
        UIManager.Instance.SetFinishPanel(tag);
    }
}