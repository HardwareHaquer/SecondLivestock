using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]

public class ChickenScript : MonoBehaviour
{
	protected CharacterController 	Controller 		 = null;
	protected Animator animator;
	protected float time = 0;
	protected float stuckTime = 0;

	void Awake () {
		Controller = GetComponent<CharacterController> ();
		animator = GetComponent<Animator> ();
	}
	private float Acceleration 	   = 0.1f;
	private float Damping 		   = 0.15f;
	private float   FallSpeed 	   = 0.0f;
	private float GravityModifier   = 100f;//0.379f;
	private Vector3 MoveThrottle   = Vector3.zero;
	protected float rotate = 1;
	// Update is called once per frame
	void Update () {
		RaycastHit ray;
		//LayerMask lm;
		//lm += LayerMask.NameToLayer ("terrain");
		Vector3 moveDirection = Vector3.zero;
		
		// Compute this for key movement
		//float moveInfluence = Acceleration * 0.1f * MoveScale;
		//Handle X,Z Movement
		if(Physics.Raycast (this.transform.position,this.transform.TransformDirection(Vector3.forward),out ray,3f)&&!ray.transform.CompareTag("terrain"))
		{
			animator.SetFloat("speed",0);
			if(ray.transform.CompareTag("Food")&&time<20&stuckTime<3)
			{
				if(ray.distance>0.5f)
				{
					stuckTime+=Time.deltaTime;
					animator.SetFloat("speed",1);
					moveDirection += this.transform.TransformDirection(new Vector3(0,0,1*Time.deltaTime));
				}
				else
				{
					stuckTime = 0;
					animator.SetFloat("speed",0);
					print (time);
					time += Time.deltaTime;
				}
			}
			else
			{
				if(time>=20&&time<25)
					time += Time.deltaTime;
				else
					time = 0;
				if(stuckTime>=3&&stuckTime<5)
					stuckTime+=Time.deltaTime;
				else
					stuckTime = 0;
				rotate = 0;			
				//print (ray.distance + " " + ray.transform.name);
				gameObject.transform.eulerAngles += new Vector3 (0, 90 * Time.deltaTime, 0);
			}
		}
		else
		{
			time = 0;
			if(rotate<1)
			{
				rotate += Time.deltaTime;
				gameObject.transform.eulerAngles += new Vector3 (0, 90 * Time.deltaTime, 0);
			}
			animator.SetFloat("speed",1);
			moveDirection += this.transform.TransformDirection(new Vector3(0,0,1*Time.deltaTime));
		}
		//Handle Y Direction
		float motorDamp = (1.0f + (Damping * Time.deltaTime));
		//MoveThrottle.x /= motorDamp;
		//MoveThrottle.y = (MoveThrottle.y > 0.0f) ? (MoveThrottle.y / motorDamp) : MoveThrottle.y;
		//MoveThrottle.z /= motorDamp; 
		
		//moveDirection += MoveThrottle * Time.deltaTime;

		// Gravity
		if (Controller.isGrounded && FallSpeed <= 0)
			FallSpeed = ((Physics.gravity.y * (GravityModifier * 0.002f)));	
		else
			FallSpeed += ((Physics.gravity.y * (GravityModifier * 0.002f)) * Time.deltaTime);	
		
		moveDirection.y += FallSpeed * Time.deltaTime;
		
		// Offset correction for uneven ground
		float bumpUpOffset = 0.0f;
		
		if (Controller.isGrounded)// && MoveThrottle.y <= 0.001f)
		{
			bumpUpOffset = Mathf.Max(Controller.stepOffset, 
			                         new Vector3(moveDirection.x, 0, moveDirection.z).magnitude); 
			moveDirection -= bumpUpOffset * Vector3.up;
		}			
		
		//Vector3 predictedXZ = Vector3.Scale((Controller.transform.localPosition + moveDirection), 
		//                                    new Vector3(1, 0, 1));	
		// Move contoller
		Controller.Move(moveDirection);
		
		//Vector3 actualXZ = Vector3.Scale(Controller.transform.localPosition, new Vector3(1, 0, 1));
		
		//if (predictedXZ != actualXZ)
		//	MoveThrottle += (actualXZ - predictedXZ) / Time.deltaTime; 

	}
}
