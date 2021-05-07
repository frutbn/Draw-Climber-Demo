using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform LeftLegPosition;
    [SerializeField] private Transform RightLegPosition;
    [SerializeField] private GameObject LegPrefab;
    [SerializeField] private Vector3 FloorOffset;
    [SerializeField] private Material Mat_Line;

    private List<GameObject> Legs = new List<GameObject>();

    public GameObject CreateLeg(Leg leg, LineRenderer lineRenderer, float zOffset)
    {
        GameObject legObj = Instantiate(LegPrefab);
        lineRenderer.BakeMesh(legObj.GetComponent<MeshFilter>().mesh, true);
        MeshCollider meshCollider = legObj.GetComponent<MeshCollider>();
        meshCollider.sharedMesh = legObj.GetComponent<MeshFilter>().mesh;

        float MaxLineY = 0;
        float MinLineY = 1000f;
        for (int i = 0; i < lineRenderer.positionCount - 1; i++)
        {
            MinLineY = Mathf.Min(MinLineY, lineRenderer.GetPosition(i).y);
        }

        for (int k = 0; k < lineRenderer.positionCount - 1; k++)
        {
            MaxLineY = Mathf.Max(MaxLineY, lineRenderer.GetPosition(k).y);
        }

        float lineHeight = MaxLineY - MinLineY;
        float playerHeight = this.transform.position.y - FloorOffset.y;
        float upCharacterSize = lineHeight - playerHeight;

        if (upCharacterSize > 0f)
        {
            this.transform.SetPositionAndRotation(new Vector3(this.transform.position.x, this.transform.position.y + upCharacterSize, this.transform.position.z), this.transform.rotation);
        }

        Vector3 legPos = new Vector3();

        switch (leg)
        {
            case Leg.Left:
                legPos.x = -lineRenderer.GetPosition(lineRenderer.positionCount - 1).x + transform.position.x;
                legPos.y = -lineRenderer.GetPosition(lineRenderer.positionCount - 1).y + transform.position.y;
                legPos.z = LeftLegPosition.position.z;
                legObj.transform.SetParent(LeftLegPosition);
                legPos.z += zOffset;
                break;
            case Leg.Right:
                legPos.x = -lineRenderer.GetPosition(0).x + transform.position.x;
                legPos.y = -lineRenderer.GetPosition(0).y + transform.position.y;
                legPos.z = RightLegPosition.position.z;
                legObj.transform.SetParent(RightLegPosition);
                legPos.z += zOffset;
                break;
        }

        legObj.transform.position = legPos;
        legObj.GetComponent<MeshRenderer>().material = Mat_Line;
        Legs.Add(legObj);
        return legObj;
    }


    public void DestroyLegs()
    {
        foreach (GameObject leg in Legs)
        {
            Destroy(leg);
        }
    }
}

public enum Leg
{
    Left,
    Right
}