using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    public float fireForce = 20f;

    public void Fire(GameObject carrying)
    {
        carrying.transform.position = firePoint.transform.position;
        carrying.transform.rotation = firePoint.transform.rotation;
        carrying.GetComponent<Rigidbody2D>().simulated = true;
        carrying.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }
}
