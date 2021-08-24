using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve : MonoBehaviour
{
    //public GameObject doorTrigger;
    public Material material;
    public ParticleSystem particle;
    public float speed=1.5f;
    float count =0;
    bool pass=false;
    // Start is called before the first frame update
    void Start()
    {
        material.SetFloat("_Dissolve",0);
        pass=false;
        count =0;
        particle.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if(pass){   
            if(count<=1){
                count+=Time.deltaTime*speed;
                material.SetFloat("_Dissolve",count);
                
            }
        }
        Debug.Log(count);
    }

    
    void OnTriggerEnter(Collider other)
    {
        if(other.tag=="player"){
            pass=true;
            particle.Play();
        }
    }
}
