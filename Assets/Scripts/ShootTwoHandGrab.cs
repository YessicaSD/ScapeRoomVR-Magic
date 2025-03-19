using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;

public class ShootTwoHandGrab : MonoBehaviour
{
    private int numberOfBullets = 30;
    [SerializeField] private GameObject bullet, charger;
    [SerializeField] private TextMeshProUGUI textMeshPro;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float bulletSpeed = 25;


    public void Fire(ActivateEventArgs arg)
    {
        if (numberOfBullets > 0)
        {
            GameObject spawnBullet = Instantiate(bullet, spawnPoint.position, transform.rotation);
            //spawnBullet.transform.position = spawnPoint.position;
            spawnBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * bulletSpeed;
            Destroy(spawnBullet, 5);
            numberOfBullets--;
            textMeshPro.text = numberOfBullets.ToString();
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject == charger)
    //    {
    //        numberOfBullets = 30;
    //        textMeshPro.text = numberOfBullets.ToString();
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == charger)
        {
            numberOfBullets = 30;
            textMeshPro.text = numberOfBullets.ToString();
        }
    }
}
