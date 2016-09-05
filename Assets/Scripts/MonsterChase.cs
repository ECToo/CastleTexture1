using UnityEngine;
using System.Collections;

public class MonsterChase : MonoBehaviour {
	[SerializeField] private Transform player;
	[SerializeField] private float monsterSpeed = -0.05f;
	[SerializeField] private float monsterAttackDistance = 1;
	[SerializeField] private float monsterTurnSpeed = 0.1f;
	[SerializeField] private int monsterViewDistance = 10;

	private Animator _anim;

	// Use this for initialization
	void Start () {
		_anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 direction = player.position - this.transform.position;
//		float angle = Vector3.Angle(direction,this.transform.forward);
//		if(Vector3.Distance(player.position, this.transform.position) < 10 && angle < 30)
		if(Vector3.Distance(player.position, this.transform.position) < monsterViewDistance)
		{

			direction.y = 0;

			this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
				Quaternion.LookRotation(-direction), monsterTurnSpeed);

			_anim.SetBool("isIdle",false);
			if(direction.magnitude > monsterAttackDistance)
			{
				this.transform.Translate(0, 0, monsterSpeed);
				_anim.SetFloat ("speed", monsterSpeed);
				_anim.SetBool("isAttacking",false);
			}
			else
			{
				_anim.SetBool("isAttacking",true);
				_anim.SetFloat ("speed", 0.0f);
			}

		}
		else 
		{
			_anim.SetBool("isIdle", true);
			_anim.SetFloat ("speed", 0.0f);
			_anim.SetBool("isAttacking", false);
		}
	}
}
