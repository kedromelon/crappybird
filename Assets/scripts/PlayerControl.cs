using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	CharacterController controller; 
	Vector3 velocity;

	bool isDead;
	bool running;

	public float gravity = 10f;
	public float jumpSpeed = 10f;
	public float moveSpeed = 2f;
	public TextMesh score;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
		isDead = false;
		running = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (!running){
			if (Input.GetKeyDown(KeyCode.Space)){
				velocity.y = jumpSpeed;
				running = true;
			}
		}else{
			velocity = controller.velocity;
			
			if (!isDead){
				if (Input.GetKeyDown(KeyCode.Space))
					velocity.y = jumpSpeed;
				
				velocity.x = moveSpeed;
			}else{
				velocity.x = 0f;
				if (Input.GetKeyDown(KeyCode.Space)){
					Application.LoadLevel(Application.loadedLevel);
				}
			}
			
			velocity.y -= gravity * Time.deltaTime;
			controller.Move(velocity * Time.deltaTime);
		}
	
	}

	void OnControllerColliderHit(ControllerColliderHit c){
		if (c.gameObject.tag == "hurt"){
			if (!isDead){
				ScreenShake2D.Shake(.2f,.4f);
				Debug.Log("OUCH");
				isDead = true;
			}
		}
	}

	void OnTriggerEnter(){
		int n = int.Parse(score.text);
		n++;
		score.text = n.ToString();

	}
}
