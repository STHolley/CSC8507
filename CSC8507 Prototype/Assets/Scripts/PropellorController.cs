using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellorController : MonoBehaviour
{

    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.transform.Rotate(Vector3.up * Time.deltaTime * 60);
    }

}
