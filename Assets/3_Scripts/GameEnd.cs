using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class GameEnd : MonoBehaviour
{
    public Fly flyScript;
    public PlayableDirector endSequence;
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
            flyScript.SetCanFlyFalse();
            endSequence.Play();
        }
    }
}
