using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    void Start()
    {
        gameObject.SetActive(false);
    }




    public IEnumerator ReloadScene()
    {
        //gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public IEnumerator DisplayGameOver()
    {
        yield return new WaitForSeconds(0.10f);
        gameObject.SetActive(true);
    }

}
