using UnityEngine;
using UnityEngine.UI;

public class skull : MonoBehaviour
{

    public float damage, health, vel;
    public int points;

    // Start is called before the first frame update
    void Start()
    {
        if (transform.rotation.y != 0) vel *= -1f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += Time.deltaTime * vel;
        transform.position = pos;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject);
        if (col.gameObject.CompareTag("wizard"))
        {
            GameObject obj = col.gameObject;
            wizard wiz = obj.GetComponent<wizard>();
            if (!wiz.anim.GetBool("defend") || obj.transform.rotation.y == transform.rotation.y)
            {
                wiz.Damage(damage);
            }
        }
    }

    private void OnParticleCollision(GameObject col)
    {
        float hurt = col.GetComponent<rage>().damage;
        health -= hurt;
        if (health <= 0)
        {
            Destroy(gameObject);
            GameObject obj = col.gameObject;
            wizard wiz = obj.GetComponentInParent<wizard>();
            wiz.earn(points);
        }
    }

}
