using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
	[SerializeField] public int health = 500;

	[SerializeField] private GatesFunctionality leftGate;
	[SerializeField] private GatesFunctionality rightGate;

	public bool isInvulnerable = false;
	public bool isDead = false;

	public void TakeDamage(int damage)
	{
		if (isInvulnerable)
			return;

		health -= damage;

		if (health > 0)
		{
			GetComponent<Animator>().SetTrigger("Hurt");
		}

		if (health <= 200)
		{
			GetComponent<Animator>().SetBool("IsEnraged", true);
		}

		if (health <= 0)
		{
			StartCoroutine(Die());
		}
	}

	IEnumerator Die()
	{
		//Play Death animation
		GetComponent<Animator>().SetTrigger("Die");

        if (leftGate != null)
        {
			leftGate.ChangeOut();
        }

        if (rightGate != null)
        {
			rightGate.ChangeOut();
        }

		isDead = true;

		transform.GetComponent<BoxCollider2D>().enabled = false;

		//Wait for a bit. (IEnumerator).
		yield return new WaitForSeconds(2);
		
		Destroy(gameObject);
	}
}
