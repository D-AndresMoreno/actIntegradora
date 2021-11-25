using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointActorDer : MonoBehaviour
{
    float speed = 5f;
    public Transform target;
    public GameObject caja1;
    public GameObject cajaEstante1;

    public GameObject caja2;
    public GameObject cajaEstante2;

    public GameObject caja3;
    public GameObject cajaEstante3;

    public GameObject cajaEntregada1;
    public GameObject cajaEntregada2;
    public GameObject cajaEntregada3;
    

    bool regreso = false;
    bool firstLoop = true;
    // Start is called before the first frame update
    void Start()
    {
        caja1.GetComponent<Renderer>().enabled = false;
        caja2.GetComponent<Renderer>().enabled = false;
        caja3.GetComponent<Renderer>().enabled = false;

        cajaEntregada1.GetComponent<Renderer>().enabled = false;
        cajaEntregada2.GetComponent<Renderer>().enabled = false;
        cajaEntregada3.GetComponent<Renderer>().enabled = false;
    }

    void Update()
    {
        if(firstLoop){
            transform.Translate(new Vector3(speed*Time.deltaTime,0,0));
        }else{
            transform.Translate(new Vector3((2.5f*Time.deltaTime),0,0));
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.tag == "WaypointIzq" && !regreso){
            transform.LookAt(new Vector3(-60,0,0));
        }else if(other.tag == "WaypointDer"&& !regreso){
            transform.LookAt(new Vector3(180,0,0));
        }else if(other.tag == "WaypointArr"&& !regreso){
            transform.LookAt(new Vector3(0,0,300));
            transform.Translate(new Vector3(speed*Time.deltaTime*-1,0,0));
        }else if(other.tag == "Waypointaba"&& !regreso){
            transform.LookAt(new Vector3(0,0,-300));
        }else if(other.tag == "final"){
            transform.LookAt(new Vector3(100,0,-300));
            regreso = true;
        }else if(other.tag == "inicio"){
            transform.LookAt(new Vector3(-260,0,0));
            regreso = false;     
            firstLoop = false;
        }


        if(other.tag == "addCaja"){
            caja1.GetComponent<Renderer>().enabled = true;
            cajaEstante1.GetComponent<Renderer>().enabled = false;
        }else if(other.tag == "addCaja1"){
            caja2.GetComponent<Renderer>().enabled = true;
            cajaEstante2.GetComponent<Renderer>().enabled = false;
        }else if(other.tag == "addCaja2"){
            caja3.GetComponent<Renderer>().enabled = true;
            cajaEstante3.GetComponent<Renderer>().enabled = false;
        }else if(other.tag == "elimCajas"){

            caja1.GetComponent<Renderer>().enabled = false;
            caja2.GetComponent<Renderer>().enabled = false;
            caja3.GetComponent<Renderer>().enabled = false;
            
            cajaEntregada1.GetComponent<Renderer>().enabled = true;
            cajaEntregada2.GetComponent<Renderer>().enabled = true;
            cajaEntregada3.GetComponent<Renderer>().enabled = true;
        }
    }

    void EvitaCoallision(Collider robot){
       if(robot.tag == "robot" ){
            transform.Translate(new Vector3(0,0,0));
        }
    }
}
