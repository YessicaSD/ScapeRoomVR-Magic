using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TorchesManager : MonoBehaviour
{
    static private TorchesManager instance;
    public List<TorchBehaviour> torches;
    private List<TorchBehaviour> activeTorches = new List<TorchBehaviour>();
    public PlayableDirector correctSequence;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }
    bool CheckCorrectSolution()
    {
        for (int i = 0; i < instance.torches.Count; ++i)
        {
            if (instance.torches[i] != instance.activeTorches[i])
            {
                return false;
            }
        }
        return true;
    }

    void ResetTorches()
    {
        instance.activeTorches.Clear();
        foreach (var torch in torches)
        {
            torch.Unlit();
        }
    }
    public static void OnTorchLighten(TorchBehaviour torch)
    {
        instance.activeTorches.Add(torch);
        if (instance.activeTorches.Count == instance.torches.Count)
        {
            if (instance.CheckCorrectSolution())
            {
                instance.correctSequence.Play();
            }
            else
            {
                instance.ResetTorches();
            }
        }
    }
}
