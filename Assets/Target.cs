using DG.Tweening;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Target : MonoBehaviour
{
    private int counter;
    public User user;
    private Target target;
    public bool targetCollision = false;

    List<Knife> knives = new List<Knife>();

    public int KnifeCount => knives.Count;


    void Update()
    {
        // TODO: Do this with DOTween
        this.gameObject.transform.Rotate(new Vector3(0, 90 * Time.deltaTime, 0));
    }


    private void OnKnifeHit(Knife knife)
    {
        counter++;

        if (knife.knifeCollision == false && targetCollision == true)
        {
            knives.Add(knife);
        }


        Debug.Log(counter);

        if (knives.Count == 7)
        {

            AddForceCylinder();
            foreach (var t in knives)
            {
                Destroy(t.gameObject);
            }
        }
    }

    public void AddForceCylinder()
    {

        target = this;

        Transform[] components = transform.GetChild(0).GetComponentsInChildren<Transform>();

        foreach (Transform component in components)
        {
            component.parent = null;
            var rb = component.gameObject.AddComponent<Rigidbody>();
            rb.AddExplosionForce(1000, rb.transform.position, 15);
        }
        user.ShowNextLevel();

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("knife"))
        {


            other.tag = "UsedKnife";
            targetCollision = true;
            Knife knife = other.GetComponent<Knife>();
            knife.transform.parent = this.gameObject.transform;
            knife.transform.DOKill();
            other.GetComponent<Knife>().enabled = false;


            //Destroy(other.GetComponent<Knife>());
            //knife.GetComponent<Collider>().enabled=false;
            OnKnifeHit(knife);

        }
    }



    /* private void OnTriggerEnter(Collider other)
     {
         if (other.CompareTag("knife"))
         {

             var knife = other.GetComponent<Knife>();
             knife.transform.DOKill();

             knife.transform.parent = transform;
         }

     }
     private void OnTriggerEnter(Collider knife)
     {
         if (knife.CompareTag("knife"))
         {
             //StartCoroutine(DisplayGameOver());



         }
     }*/
}

