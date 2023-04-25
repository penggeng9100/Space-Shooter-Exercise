using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hero : MonoBehaviour
{
    // Start is called before the first frame update
    static public Hero S{ get; private set;}

    [Header("Inscribed")]
    public float speed = 30;
    public float rollMult = -45;
    public float pitchMult = 30;
    public GameObject projectilePrefab;
    public float projectileSpeed = 40f;

    [Header("Dynamic")]
    [Range(0,4)]
    public float shieldLevel = 1;
    

    void Awake(){
        if(S == null){
             S = this;
        }
        else {
           UnityEngine.Debug.LogError("Here.Awake()");
        }
       

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        Vector3 pos =transform.position;
        pos.x += hAxis * speed * Time.deltaTime;
        pos.y += vAxis * speed * Time.deltaTime;
        transform.position = pos;

        transform.rotation = Quaternion.Euler(vAxis * pitchMult, hAxis * rollMult, 0);

        if(Input.GetKeyDown(KeyCode.Space)){
            Fire();
        }
        
    }

    void Fire(){
        GameObject projGo = Instantiate<GameObject>(projectilePrefab);
        projGo.transform.position = transform.position;
        Rigidbody rb = projGo.GetComponent<Rigidbody>();
        rb.velocity = Vector3.up *projectileSpeed;

    }
    void OnTriggerEnter(Collider other){
        Transform rootT = other.gameObject.transform.root;
        GameObject go = rootT.gameObject;
        // UnityEngine.Debug.Log(go.gameObject.name);
        Destroy(go);
        shieldLevel--;
        if(shieldLevel<0){
            Main.HERO_DIED();
            Destroy(this.gameObject);
        }
    }
    
}
