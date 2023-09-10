using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame_1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayGame1()
    {
        SceneManager.LoadScene("Game_1 Scene");
    }
    public void Back()
    {
        gameObject.SetActive(false);
    }
}
