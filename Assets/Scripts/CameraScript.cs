using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform Slime;

    void Update()
    {
        if (Slime != null)
        {
            Vector3 position = transform.position;
            position.x = Slime.position.x;
            position.y = Slime.position.y + 0.7f;
            transform.position = position;
        }
    }
}
