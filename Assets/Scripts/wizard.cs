using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wizard : MonoBehaviour
{

    public Animator anim;
    public float health;
    public GameObject rage, dead, gameover;
    public Text pontuation, life;
    public Image heart;
    public Sprite skull_Death, death;

    // Start is called before the first frame update
    void Start()
    {
        pontuation.text = "0";
        life.text = health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal"), v= Input.GetAxis("Vertical");
        if (h < 0)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        else if (h > 0)
        {
            transform.rotation = new Quaternion(0, 180, 0, 0);
        }

        if (Input.GetKey(KeyCode.X))
        {
            anim.SetBool("attack", true);
            enableRage();
        }
        else
        {
            anim.SetBool("attack", false);
            disableRage();
        }

        if (Input.GetKey(KeyCode.Z))
        {
            anim.SetBool("defend", true);
        }
        else
        {
            anim.SetBool("defend", false);
        }

        if (Input.GetKey(KeyCode.C))
        {
            anim.SetBool("fire", true);
        }
        else
        {
            anim.SetBool("fire", false);
        }

    }


    public void Damage(float damage)
    {
        health -= damage;
        if (health <= 0) Death();
        else life.text = health.ToString();
    }

     public void enableRage()
    {
        rage.SetActive(true);
    }

    public void disableRage()
    {
        rage.SetActive(false);
    }

    public void earn(int points)
    {
        print(points);
        pontuation.text=(int.Parse(pontuation.text)+points).ToString();
    }

    void Death()
    {
        life.text = "0";
        heart.sprite = skull_Death;
        Destroy(gameObject);
        Instantiate(dead, new Vector3(0, -0.18f, 0), new Quaternion(0, 0, 0, 0));
        gameover.SetActive(true);
    }

}
