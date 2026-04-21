//using UnityEngine;

//public class Projectile : MonoBehaviour
//{
//    public float speed = 10f;
//    public float lifeTime = 2f;
//    public int damage = 20;

//    void Start()
//    {
//        Destroy(gameObject, lifeTime);
//    }

//    void Update()
//    {
//        transform.Translate(Vector3.forward * speed * Time.deltaTime);
//    }

//    private void OnTriggerEnter(Collider other)
//    {

//        EnemyHealth enemy = other.GetComponent<EnemyHealth>();

//        if (enemy != null)
//        {
//            enemy.TakeDamage(damage);
//            Destroy(gameObject); 
//        }
//    }
//}
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 2f;
    public int damage = 20;
    public float hitDistance = 0.5f; // distancia para detectar impacto

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {

        transform.Translate(Vector3.forward * speed * Time.deltaTime);

       
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, hitDistance))
        {
            Debug.Log("Bola golpeó: " + hit.collider.name);

            EnemyHealth enemy = hit.collider.GetComponentInParent<EnemyHealth>();

            if (enemy != null)
            {
                Debug.Log("Daño aplicado con bola");
                enemy.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}