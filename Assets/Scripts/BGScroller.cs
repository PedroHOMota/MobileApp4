using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour {

    public float scrollSpeed = 0;
    public float tileSize;
    public Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }
    void Update ()
    {
        float newPos = Mathf.Repeat(Time.time * scrollSpeed, tileSize);
        transform.position = startPosition + Vector3.forward * newPos;
	}
}
