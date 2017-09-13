using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	//direction of player
	//		   2 = up
	//1 = left			3 = right
	//		   0 = down
	public static int direction = 0;
	
	//Public for interaction
	public static bool space = false;
	
	public Vector2 coord = new Vector2 (0f, 0f);
	
	//Initiate animator, rigidbody2d, maincamera and gamecontrol
	private Animator animator;
	private Rigidbody2D rigid;
	private Camera mainCamera;
	private GameControl gameControl;
	private Health health;
	
	private static bool hasStarted = false;
		
	//keyPressed booleans
	private bool down;
	private bool left;
	private bool up;
	private bool right;
	private bool x;
	
	public bool sword;
	
	//For assigning playerWalkSpeed from GameControl
	private float walkSpeed;
	
	public static Vector2 playerPosition;
	
	void Awake(){
		//Finding Animator of Player
		animator = GetComponent<Animator>();
		
		//Finding Rigidbody2D of Player
		rigid = GetComponent<Rigidbody2D>();
		
		//Finding GameControl
		gameControl = GameObject.Find("GameControl").GetComponent<GameControl>();
		
		//Finding Health
		health = transform.GetComponent<Health>();
		
		
		//Don't do this on the first load
		if (hasStarted){
			//Setting the direction then the according animation
			direction = gameControl.playerDirection;
			SetDirection();
		
			//Make the player load in at the right location
			transform.position = gameControl.playerPosition;			
		} else if (!hasStarted){
				
		}
		
		//Assign Walkspeed
		walkSpeed = gameControl.playerWalkSpeed;
		
				
		
		
	}
	
	void Start(){
		hasStarted = true;
	}
	
	// Update is called once per frame
	void Update () {
		//Finding the maincamera
		mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();	
		//Center camera on player
		/*if (gameControl){
			gameControl.currentHealth = health.currentHealth;
			gameControl.maxHealth = health.maxHealth;
		}*/
		if (mainCamera){
			Vector3 cameraPos = new Vector3(this.transform.position.x + coord.x, this.transform.position.y + coord.y, this.transform.position.z -10f);
			mainCamera.transform.position = cameraPos;
		}
		
		//Check which keys are pressed
		CheckKeys();
		
		if(Input.GetKeyDown(KeyCode.B)){
			health.currentHealth -= 10;
		}
		
		//Walking in a single direction
		if (!sword){
			if (down && !right && !left){
				WalkDown();
			}
			if (left && !up && !down){
				WalkLeft();
			}
			if (up && !right && !left){
				WalkUp();
			}
			if (right && !up && !down){
				WalkRight();
			}
		
			//Walkig in two directions
			if (down && left && !right){
				WalkDownLeft();
			}
			if (down && right && !left){
				WalkDownRight();
			}
			if (up && left && !right){
				WalkUpLeft();
			}
			if (up && right && !left){
				WalkUpRight();
			}
		}
		
		if (!up && !down && !left && !right){
			animator.SetBool("isWalking", false);
			if (rigid){
				rigid.velocity = Vector2.zero;
			}
		}
		
		//print (animator.GetBool("isWalking"));
	}
	
	void CheckKeys(){
		//Getting inputs
		if(!sword){
			down = Input.GetKey(KeyCode.DownArrow);
			left = Input.GetKey(KeyCode.LeftArrow);
			up = Input.GetKey(KeyCode.UpArrow);
			right = Input.GetKey(KeyCode.RightArrow);
			space = Input.GetKeyDown(KeyCode.Space);
			x = Input.GetKey(KeyCode.X);
		/* else {
			down = false;
			left = false;
			up = false;
			right = false;
			space = false;
		}*/
		
		if (x){
			if (direction == 0){
				animator.Play("swing_down");
			} else if (direction == 1){
				animator.Play("swing_left");
			} else if (direction == 2){
				animator.Play("swing_up");
			} else if (direction == 3){
				animator.Play("swing_right");
			} else{
				direction = 0;
				SetDirection();
			}
		}
		}
		
		//Making sure you can't walk in opposite directions at the same time
		if (up && down){
			up = false;
			down = false;
		}
		if (left && right){
			left = false;
			right = false;
		}
	}
	
	//Walking in a single direction
	void WalkDown(){
		animator.Play("walk_down");
		animator.SetBool("isWalking", true);
		direction = 0;
		gameControl.playerDirection = direction;
		//rigid.velocity = Vector2.down * walkSpeed * Time.deltaTime;
		rigid.MovePosition(transform.position + (Vector3.down * walkSpeed * Time.deltaTime));
	}	
	void WalkLeft(){
		animator.Play("walk_left");
		animator.SetBool("isWalking", true);
		direction = 1;
		gameControl.playerDirection = direction;
		//rigid.velocity = Vector2.left * walkSpeed * Time.deltaTime;
		rigid.MovePosition(transform.position + (Vector3.left * walkSpeed * Time.deltaTime));
	}	
	void WalkUp(){
		animator.Play("walk_up");
		animator.SetBool("isWalking", true);
		direction = 2;
		gameControl.playerDirection = direction;
		//rigid.velocity = Vector2.up * walkSpeed * Time.deltaTime;
		rigid.MovePosition(transform.position + (Vector3.up * walkSpeed * Time.deltaTime));
	}	
	void WalkRight(){
		animator.Play("walk_right");
		animator.SetBool("isWalking", true);
		direction = 3;
		gameControl.playerDirection = direction;
		//rigid.velocity = Vector2.right * walkSpeed * Time.deltaTime;
		rigid.MovePosition(transform.position + (Vector3.right * walkSpeed * Time.deltaTime));
	}
	
	//Walkig in two directions
	void WalkDownLeft(){
		animator.Play("walk_left");
		animator.SetBool("isWalking", true);
		direction = 3;
		gameControl.playerDirection = direction;
		rigid.MovePosition(transform.position + ((Vector3.down + Vector3.left) * 0.707f * walkSpeed * Time.deltaTime));
	}
	void WalkDownRight(){
		animator.Play("walk_right");
		animator.SetBool("isWalking", true);
		direction = 3;
		gameControl.playerDirection = direction;
		rigid.MovePosition(transform.position + ((Vector3.down + Vector3.right) * 0.707f * walkSpeed * Time.deltaTime));
	}
	void WalkUpLeft(){
		animator.Play("walk_left");
		animator.SetBool("isWalking", true);
		direction = 3;
		gameControl.playerDirection = direction;
		rigid.MovePosition(transform.position + ((Vector3.up + Vector3.left) * 0.707f * walkSpeed * Time.deltaTime));
	}
	void WalkUpRight(){
		animator.Play("walk_right");
		animator.SetBool("isWalking", true);
		direction = 3;
		gameControl.playerDirection = direction;
		rigid.MovePosition(transform.position + ((Vector3.up + Vector3.right) * 0.707f * walkSpeed * Time.deltaTime));
	}
	
	void SetDirection(){
		if (direction == 0){
			animator.Play("facing_down");
		} else if (direction == 1){
			animator.Play("facing_left");
		} else if (direction == 2){
			animator.Play("facing_up");
		} else if (direction == 3){
			animator.Play("facing_right");
		} else{
			direction = 0;
			SetDirection();
		}		
	}
}
