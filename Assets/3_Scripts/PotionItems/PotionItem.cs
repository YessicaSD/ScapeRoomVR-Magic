using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionItem : MonoBehaviour
{
    private Vector3 position;
    private Quaternion rotation;
    [SerializeField] private bool isMainItem = false;

    public bool IsMainItem() { return isMainItem; }
    bool reset = false;
    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        rotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (reset)
        {
            reset = false;

        }
    }
    public void ResetItem()
    {
        transform.position = position;
        transform.rotation = rotation;
        gameObject.SetActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cauldron")
        {
            Debug.Log("trigger with cauldron");
            gameObject.SetActive(false);
        }
    }
}
