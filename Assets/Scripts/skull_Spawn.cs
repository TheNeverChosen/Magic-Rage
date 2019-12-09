using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skull_Spawn : MonoBehaviour
{

    public GameObject skull;
    [Range(2f, 20f)] public float spawnRate;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void criar()
    {
        gameObject.SetActive(true);
        StartCoroutine(Generator());
    }

    IEnumerator Generator()
    {
        float time = Random.Range(0.5f, spawnRate);
        yield return new WaitForSeconds(time);

        Vector3 pos = transform.position;
        Quaternion rot = transform.rotation;

        if (Random.Range(0f, 1f) < 0.5)
        {
            pos.x = -transform.position.x;
            rot= new Quaternion(0, 180, 0, 0);
        }
        else rot= new Quaternion(0, 0, 0, 0);

        GameObject aux = Instantiate(skull, pos, rot);

        StartCoroutine(Generator());

    }

}
