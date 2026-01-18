using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class M_GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Reload()
    {
        SceneManager.LoadScene(0);
        PublicAttribute.Instance.isHaveAKey = false;
    }
}
