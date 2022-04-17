using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follower : MonoBehaviour
{
     public Transform ImageTarget;
    public Canvas CanvasToPlace;

    // set an offset for the canvas e.g. 20cm above
    public Vector3 offset = new Vector3(0, 0.2f, 0);

    private void LateUpdate()
    {
        CanvasToPlace.transform.position = ImageTarget.transform.position + offset;
    }
}
