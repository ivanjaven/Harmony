using UnityEngine;

public class BallCollision : MonoBehaviour // This script is use to add explosion animation effect on collision
{
	ParticleSystem explosionFx; // Use unity built in particle system
	int ballIndex;
	SoundEffectManager audioManager;


	void Start ()
	{
		explosionFx = transform.GetChild (0).GetComponent <ParticleSystem> ();
		ballIndex = transform.position.x > 0 ? 0 : 1;
		audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<SoundEffectManager>();
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.collider.CompareTag ("Obstacle")) { //check if the ball collide on any obstacle
			GameManager.Instance.isGameover = true; //save the state in game manager
			explosionFx.Play (); // play the explosion effect
			audioManager.PlaySFX(audioManager.splat);
			PlayerMovement.Instance.Restart (); // execute restart on playermovement
		}
	}
}
