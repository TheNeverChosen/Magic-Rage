using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Events : MonoBehaviour
{

    public GameObject wizard, spawn, hud, gameover, menu;

    // Start is called before the first frame update
    void Start()
    {
        wizard.SetActive(false); spawn.SetActive(false); hud.SetActive(false); gameover.SetActive(false); menu.SetActive(true);
    }

    public void play()
    {
        wizard.SetActive(true); spawn.GetComponent<skull_Spawn>().criar();
        menu.SetActive(false); hud.SetActive(true);
    }

    public void back()
    {
        SceneManager.LoadScene("Main");
    }

}
