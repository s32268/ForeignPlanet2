using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera2 : MonoBehaviour
{
    




    public Transform target;

    public float smoothTime = 0.2f;

    float LookAheadDistance = 2f;

    public float smoothSpeed = 5f;

    private Vector3 velocity = Vector3.zero;

    private void LateUpdate()

    {

        Vector3 pos = transform.position;

        Vector3 diff = target.position - transform.position;

        //roznica pozycji gracza - kamera

        float direction = Input.GetAxis("Horizontal");

        // -1 = lewo, 1 = prawo, 0 = stoi

        //Vector3 targetPos = new Vector3(target.position.x, target.position.y, target.position.z);

        Vector3 targetPos = target.position + new Vector3(LookAheadDistance * direction, 0, -10);

        //przesumiecie kmeki w kierunku ruchu

        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);

    }


 
}

