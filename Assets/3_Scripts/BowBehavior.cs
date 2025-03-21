using UnityEngine;

public class BowBehavior : MonoBehaviour
{
    [SerializeField] private GameObject arrow;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private Transform string_transform;
    private Vector3 initialStringPosition;
    // Start is called before the first frame update
    void Start()
    {
        initialStringPosition = string_transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FireArror()
    {
        Debug.Log("Let go the string");
        string_transform.localPosition = initialStringPosition;
        GameObject spawnBullet = Instantiate(arrow, spawnPoint.position, spawnPoint.rotation);
        //spawnBullet.transform.position = spawnPoint.position;
        spawnBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * bulletSpeed;
        Destroy(spawnBullet, 5);
    }
}
