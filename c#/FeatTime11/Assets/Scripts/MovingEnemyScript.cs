using UnityEngine;
using System.Collections;
namespace RoleGame{
	public class MovingEnemyScript : MonoBehaviour {
		public float speed=2f;
		private float direction = 1f;
		public int takeHP = 5;
		private Animator anim;
		private float Timer =0.8f;
		// Use this for initialization
		void Start () {
			anim = GetComponent<Animator>();
		}
		// Update is called once per frame
		void Update () {
			GetComponent<Rigidbody2D>().velocity = new Vector2((float)(direction * speed), (float)(GetComponent<Rigidbody2D>().velocity.y));
			transform.localScale = new Vector3 (direction * Mathf.Abs(transform.localScale.x), transform.localScale.y, 1);
			if (speed == 0) {
				Timer-=Time.deltaTime;
			}

			if(Timer<=0.0f)
				Destroy (gameObject);
			
		}
		void OnCollisionEnter2D(Collision2D col){
			if ((col.gameObject.tag == "Wall")||(col.gameObject.tag == "MovingEnemy")||(col.gameObject.tag == "Player"))
				direction *= -1f;
			if (col.gameObject.tag == "Player") {
				if (speed!= 0)
				{
					Settings.currentPlayer.currentHP -= takeHP;
					col.gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, 450));
				}
			}
			if (col.gameObject.tag == "Lightning") {
				anim.SetBool("MovingEnemyIsDead",true);
				speed=0;
			}
		}
		void OnTriggerEnter2D(Collider2D col){
			if ((col.gameObject.tag == "Wall")||(col.gameObject.tag == "MovingEnemy")||(col.gameObject.tag == "Player"))
				direction *= -1f;
			if (col.gameObject.tag == "Player") {
				anim.SetBool("MovingEnemyIsDead",true);
				speed=0;
				Settings.currentPlayer.experience += 5;
				col.gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0,800));
			}
			if (col.gameObject.tag == "Lightning") {
				anim.SetBool("MovingEnemyIsDead",true);
				speed=0;
			}
		}
	}
}