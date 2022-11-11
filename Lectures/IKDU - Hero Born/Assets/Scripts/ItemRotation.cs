using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotation : MonoBehaviour
{
    public int rotationSpeed = 100;
    Transform ItemTransform;

    // Start is called before the first frame update
    void Start()
    {
        ItemTransform = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        ItemTransform.Rotate(rotationSpeed * Time.deltaTime, 0, 0);
    }
}
