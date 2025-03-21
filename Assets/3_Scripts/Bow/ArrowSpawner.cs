using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ArrowSpawner : MonoBehaviour
{

    [SerializeField] private GameObject arrow;
    [SerializeField] private XRGrabInteractable bow;
    bool arrowLoaded = false;
    private GameObject currentArrow = null;
    Coroutine spawnCoroutine = null;
    // Start is called before the first frame update
    void Start()
    {
        PullInteraction.pullActionRelease += OnArrowThrown;
    }

    private void OnDestroy()
    {
        PullInteraction.pullActionRelease -= OnArrowThrown;
    }

    // Update is called once per frame
    void Update()
    {
        if (bow.isSelected && !arrowLoaded)
        {
            spawnCoroutine = StartCoroutine(DelayedSpawn());
        }
        if (!bow.isSelected)
        {
            if (spawnCoroutine != null)
                StopCoroutine(spawnCoroutine);
            if (currentArrow)
                Destroy(currentArrow);
        }
    }

    private void OnArrowThrown(float strength)
    {
        arrowLoaded = false;
        currentArrow = null;
    }

    IEnumerator DelayedSpawn()
    {
        arrowLoaded = true;
        yield return new WaitForSeconds(1f);
        currentArrow = Instantiate(arrow, transform);
        spawnCoroutine = null;
    }
}
