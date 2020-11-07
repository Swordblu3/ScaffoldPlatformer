using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scaffold.Player
{
	internal class PlayerController : MonoBehaviour
	{
		// =========================================================
		// Fields
		// =========================================================

		public float velocity = 8;
		public float acceleration = 30;
		public float jumpVel = 10;

		[Space]
		public bool grounded;
		public BoxCollider2D groundedZone = default;
		public LayerMask groundedMask = int.MaxValue;

		private Vector2 inputAxes;

		// For correct behavior, you should check the time the button was
		// pressed, and if the time you read the button is less than a
		// threshold, activate the relevant code and set the timestamp back to
		// something like -100
		private bool inputJumpDown;

		private Rigidbody2D body;
		private SpriteRenderer sr;
		private Animator anim;

		// =========================================================
		// Methods
		// =========================================================

		private void Awake()
		{
			body = GetComponent<Rigidbody2D>();
			sr = GetComponent<SpriteRenderer>();
			anim = GetComponent<Animator>();
		}

		private void Start()
		{
			grounded = false;
		}

		private void UpdateSprite()
		{
			if (inputAxes.x != 0)
			{
				sr.flipX = inputAxes.x < 0;
			}

			if (grounded)
			{
				anim.Play(inputAxes.x != 0 ? "Run" : "Idle");
			}
			else
			{
				anim.Play("Jump");
			}
		}

		private void Update()
		{
			inputAxes = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
			if (Input.GetButtonDown("Jump"))
			{
				inputJumpDown = true;
			}
			UpdateSprite();
		}

		private void UpdateGrounded()
		{
			if (grounded)
			{
				Collider2D hit = Physics2D.OverlapBox(body.position + groundedZone.offset, groundedZone.size, 0, groundedMask);
				if (hit == null)
				{
					grounded = false;
				}
			}
		}

		private void FixedUpdate()
		{
			UpdateGrounded();

			Vector2 vel = body.velocity;

			vel.x = Mathf.MoveTowards(vel.x, velocity * inputAxes.x, acceleration * Time.fixedDeltaTime);

			if (inputJumpDown && grounded)
			{
				vel.y = jumpVel;
				inputJumpDown = false;
			}

			body.velocity = vel;
		}

		private void OnCollisionEnter2D(Collision2D collision)
		{
			if (collision.contactCount > 1)
			{
				Vector2 normal = collision.GetContact(0).normal;
				if (Vector2.Angle(normal, Vector2.up) < 30)
				{
					grounded = true;
				}
			}
		}
	}
}