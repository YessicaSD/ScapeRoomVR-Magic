using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Cauldron : MonoBehaviour
{
    private List<PotionItem> potionItems = new List<PotionItem>();
    public PlayableDirector errorSequence;
    public PlayableDirector correctSequence;

    bool resetItems = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (resetItems)
        {
            resetItems = false;
            foreach (var item in potionItems)
            {
                item.ResetItem();
            }
            potionItems.Clear();
        }
    }
    private IEnumerator ShowPotionError()
    {

        yield return new WaitForSeconds(5.0f);
    }

    void ShowPotionCorrect()
    {

    }

    void CheckPotionCorrect()
    {
        bool correct = true;
        foreach (var item in potionItems)
        {
            if (!item.IsMainItem())
            {
                correct = false;
                break;
            }
        }
        if (correct)
        {
            correctSequence.Play();
        }
        else
        {
            errorSequence.Play();
            resetItems = true;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PotionItem")
        {
            PotionItem cmpItem = other.GetComponent<PotionItem>();
            potionItems.Add(cmpItem);
            if (potionItems.Count == 3)
            {
                CheckPotionCorrect();
            }
        }
    }
}
