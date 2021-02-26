using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public Rigidbody rb;
    float elapsed = Mathf.PI;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        elapsed -= Time.deltaTime;
        if (elapsed <= 0.0f)
        {
            elapsed += Mathf.PI;
        }
        rb.transform.position = new Vector3(Mathf.Sin(elapsed), 2, 0);
    }
}
