using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {


	public float velocidade;

	public Transform player;
	private Animator animator;


	public bool isGrounded;
	public float force; 
	
	public float jumpTime = 0.10f;
	public float jumpDelay = 0.10f;
	public bool jumped;
	public Transform ground;
	
	public Rigidbody2D rgd2;

	// Use this for initialization
	void Start () {

		rgd2 = GetComponent<Rigidbody2D> ();
		animator = player.GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {
	
		Movimentar();
	}

	void Movimentar()
	{

		isGrounded = Physics2D.Linecast (transform.position, ground.position, 1 << LayerMask.NameToLayer ("Plataforma"));

		animator.SetFloat("run",Mathf.Abs(Input.GetAxisRaw("Horizontal")));

		if (Input.GetAxisRaw ("Horizontal") > 0) {
		

			transform.Translate(Vector2.right * velocidade * Time.deltaTime);
			transform.eulerAngles = new Vector2(0,0);
		}

		if (Input.GetAxisRaw ("Horizontal") < 0) {
			
			transform.Translate(Vector2.right * velocidade * Time.deltaTime);
			transform.eulerAngles = new Vector2(0,180);
		}
						

		if (Input.GetButtonDown ("Jump") && isGrounded && !jumped) {
				
			
			rgd2.AddForce(transform.up * force);
			jumpTime = jumpDelay;
			animator.SetTrigger("jump");
			jumped = true;

		
		}

		jumpTime -= Time.deltaTime;


		if (jumpTime <= 0 && isGrounded && jumped) {
				
			animator.SetTrigger("ground");
			jumped = false;
		}
	
	

	}


/*	void OnCollisionEnter2D(Collision2D colisor)
	{

		if (colisor.gameObject.name == "Porta") {

			if(gerenciador.IsColetado())
			{
		
				gerenciador.ProximoLevel(gerenciador.proximoLevel);
			}else
			{
				// indicando que nao coletou a quantidade satisfatoria
				Debug.Log ("Nao coletou a quantidade maxima");
			}
		
		}

	}

*/


}

