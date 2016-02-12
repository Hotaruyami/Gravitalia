using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour
{
    public GameObject Coche;
    private float xcunde, ycunde, zcunde;
    public Collider Coch;
    private Collider[] numeros;
    private Vector3 halfexe;

    // Use this for initialization
    void Start()
    {
        Coche = GameObject.FindGameObjectWithTag("cotxe");
        ycunde = transform.position.y - Coche.transform.position.y;
        zcunde = transform.position.z - Coche.transform.position.z;
        xcunde = transform.position.x;
        halfexe = new Vector3(0.3f, 0.15f, 0.6f);
    }
    // Update is called once per frame
    void Update()
    {
       
             numeros = Physics.OverlapBox(Coch.transform.position, halfexe, Coch.transform.rotation, 1 << LayerMask.NameToLayer("Terra"));
             if (numeros.Length > 0)
             {
                 transform.position = new Vector3(numeros[0].gameObject.transform.position.x, transform.position.y, transform.position.z);
             }
             if(numeros.Length==0) {
                 transform.position = new Vector3(Coche.transform.position.x, transform.position.y, transform.position.z);
             }
        //co.OnTriggerEnter(Coch);
       // print(numeros.Length);
   

    }
}