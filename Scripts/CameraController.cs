using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static bool isCollision;
    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D collision)
    {
        isCollision=true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isCollision=false;
    }
}
