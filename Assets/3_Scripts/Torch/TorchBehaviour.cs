using UnityEngine;

public class TorchBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject fire;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision != null)
        {
            Arrow arrow = collision.gameObject.GetComponent<Arrow>();
            if (arrow != null)
            {
                fire.SetActive(true);
            }
        }
    }
}
