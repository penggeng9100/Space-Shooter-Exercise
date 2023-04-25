using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHero : MonoBehaviour
{
    private BoundsCheck bndcheck;

    void Awake(){
        bndcheck = GetComponent<BoundsCheck>();
    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        float posy = transform.position.y;
        if(posy - bndcheck.radius > bndcheck.camHeight){
            Destroy(gameObject);
        }
        
    }
}
