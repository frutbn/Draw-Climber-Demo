using UnityEngine;

public abstract class InteractiveObject : MonoBehaviour
{
    [SerializeField] private string ObjectTag;

    protected bool CheckTag(string tag)
    {
        if (tag == ObjectTag) return true;
        return false;
    }
}