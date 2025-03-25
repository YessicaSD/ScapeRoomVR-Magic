using System.Collections;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 25f;
    public Transform tip;
    private Rigidbody rb;
    private bool inAir = false;
    private Vector3 lastPosition = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        PullInteraction.pullActionRelease += Release;
        SetPhysics(false);
    }
    private void OnDestroy()
    {
        PullInteraction.pullActionRelease -= Release;
    }

    private void Release(float strenght)
    {
        PullInteraction.pullActionRelease -= Release;
        gameObject.transform.parent = null;
        inAir = true;
        SetPhysics(true);
        Vector3 force = transform.forward * strenght * speed;
        rb.velocity = force;
        lastPosition = tip.position;
        StartCoroutine(DestroyDelayed());
    }

    IEnumerator DestroyDelayed()
    {
        yield return new WaitForSeconds(5.0f);
        Destroy(gameObject);
    }

    private void SetPhysics(bool usePhysics)
    {
        rb.useGravity = usePhysics;
        rb.isKinematic = !usePhysics;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
