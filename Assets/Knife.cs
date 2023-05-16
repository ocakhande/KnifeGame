using DG.Tweening;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;


class Knife : MonoBehaviour
{
    [HideInInspector] public User User;
    [HideInInspector] public Target target;
    [SerializeField] private GameObject smokePrefab;

    public bool knifeCollision = false;
    //public bool isTrigger = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("UsedKnife"))
        {
            knifeCollision = true;
            if (knifeCollision == true)
            {

                var smoke = Instantiate(smokePrefab, other.gameObject.transform.position, other.gameObject.transform.rotation);
                ParticleSystem ps = smoke.GetComponent<ParticleSystem>();
                var main = ps.main;

                Destroy(gameObject);

            }
            // other.tag = "UsedKnife";

            User.GetComponent<User>().GetKnifeProcess();


        }

    }




}



