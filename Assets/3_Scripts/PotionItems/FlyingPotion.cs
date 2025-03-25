using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingPotion : MonoBehaviour
{
    public Fly flyingScript;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            flyingScript.enabled = true;
            gameObject.SetActive(false);
        }
    }
}
