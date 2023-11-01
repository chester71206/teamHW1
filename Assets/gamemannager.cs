using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Text = TMPro.TextMeshProUGUI;
public class gamemannager : MonoBehaviour
{
    public GameObject loselevelUI;
    private bool endgame = false;
    // Start is called before the first frame update
    public void lose_level()
    {
        loselevelUI.SetActive(true);
        Debug.Log("HI");
        endgame = true;
    }
    public  void pressstart()
    {
        SceneManager.LoadScene(1);
        Debug.Log("2341");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (endgame == true)
        {
            if (Input.GetKey(KeyCode.Return))
            {
                SceneManager.LoadScene(0);
            }
        }
        /*if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene(1);
            Debug.Log("2341");
        }*/
    }
}
