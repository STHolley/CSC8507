using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSwitcher : MonoBehaviour
{

    public PhysicMaterial[] physMats;
    public Material[] rendMats;
    public float[] masses;
    public int iter = 0;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Collider>().material = physMats[0];
        GetComponent<Renderer>().material = rendMats[0];
        GetComponent<Rigidbody>().mass = masses[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("l"))
        {
            iter++;
            if (iter >= physMats.Length)
            {
                iter = 0;
            }
            GetComponent<Collider>().material = physMats[iter];
            GetComponent<Renderer>().material = rendMats[iter];
            GetComponent<Rigidbody>().mass = masses[iter];
        }
    }
}
