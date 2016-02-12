using UnityEngine;
using System.Collections;

public class Cochi : MonoBehaviour {
	private Rigidbody rgb;
	private float x, y;
	public enemic ene;
	private Vector3 acc;
	public Transform TerraCop;
    public GameObject particules;
	private bool Terras, cuchillas,chek; 
	private float  mdl,angle;
    public HingeJoint cue, cud;
    private JointMotor cuem, cued;
	// Use this for initialization 
	void Start () {
		rgb=GetComponent <Rigidbody> ();
		acc = new Vector3 (0, 0, 0);
		mdl = 70;
		x = 0; y= 0; 
        cuchillas = false;
        cuem=cue.motor;
        cued = cud.motor;
		chek = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        
		Terras = (Physics.Linecast (transform.position,TerraCop.position , 1 << LayerMask.NameToLayer ("Terra"))||Physics.Linecast (transform.position,TerraCop.position , 1 << LayerMask.NameToLayer ("terrasa")) || Physics.Linecast (transform.position,TerraCop.position , 1 << LayerMask.NameToLayer ("terrtot")) );
		acc [0] = acc [2] = 0;
		x = Input.GetAxis ("Horizontal");
		y = Input.GetAxis ("Vertical");
		mdl = Mathf.Sqrt (x * x + y * y);
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            particules.SetActive(true);
        }
        else
        {
            particules.SetActive(false);
        }

     	if(  Input.GetButtonDown("Jump")) 
		{
        	if (cuchillas) 
			{
	             cuem.targetVelocity = -250;
	             cue.motor = cuem;
	             cued.targetVelocity = +250;
	             cud.motor = cued;
				 cuchillas = false;
            
         	}
            else 
			{
                 cuem.targetVelocity = +250;
                 cue.motor = cuem;
                 cued.targetVelocity = -250;
                 cud.motor = cued;
				 cuchillas = true;            
        	}
     	} 

		if (Terras &&  mdl != 0 && Mathf.Sqrt(rgb.velocity.x*rgb.velocity.x + rgb.velocity.z*rgb.velocity.z)<20) {

			acc [2] = 80 * y / mdl*(1f);
			rgb.AddRelativeForce (acc);
			rgb.velocity = new Vector3 (x*10, rgb.velocity.y, rgb.velocity.z);
		}
		if(!Terras)
		{
			rgb.velocity = new Vector3 (x*10, rgb.velocity.y, rgb.velocity.z);
			
		}
		if (!Terras && transform.localEulerAngles.x > 0.5f) {
			transform.Rotate(new Vector3(0.5f,0,0));
		} 




	}

	public void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.CompareTag("CheckBox"))
		{
			ene.strart = true;

		}
	}
	public void OnCollisionExit (Collision col)
	{
		if(col.gameObject.CompareTag("CheckBox"))
		{
			ene.strart = false;

		}
	}
   
}