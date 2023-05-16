using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Congrats : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }



    public IEnumerator DisplayCongrats()
    {

        yield return new WaitForSeconds(0.01f);
        gameObject.SetActive(true);
    }

}
