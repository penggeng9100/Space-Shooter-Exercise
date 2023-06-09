using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
     [Header("Inscribed")]
    public float speed = 10f;
    public float pitchMult = 5f;
    
    private BoundsCheck bndcheck;

    void Awake(){
        bndcheck = GetComponent<BoundsCheck>();

    }
    public Vector3 pos{
        get{
            return this.transform.position;
        }
        set{
            this.transform.position =value;
        }
    }

    public Quaternion rot{
        get{
            return this.transform.rotation;
        }
        set{
            this.transform.rotation =value;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        // float ypos = pos.y;
        if(pos.y + bndcheck.radius < -bndcheck.camHeight){
           Vector3 tempPos = pos;
            Destroy(gameObject);
           //tempPos.y =bndcheck.camHeight + 2.5f * bndcheck.radius;
           //pos = tempPos;
        }
    }

    void OnCollisionEnter(Collision other){
        GameObject ohterGo = other.gameObject;
        if(ohterGo.GetComponent<ProjectileHero>()!=null){
            Destroy(ohterGo);
            Destroy(gameObject);
        }
    }
    public virtual void Move(){
        Vector3 tempPos = pos;
        tempPos.y -= speed * Time.deltaTime;
        pos = tempPos;
        //rot = Quaternion.Euler(-speed * pitchMult,0 ,0);
    }
}
