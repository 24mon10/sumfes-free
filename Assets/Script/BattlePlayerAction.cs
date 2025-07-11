using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using static UnityEngine.EventSystems.StandaloneInputModule;

public class BattlePlayerAction : MonoBehaviour
{
	[SerializeField] GameObject player;
	private Transform _transform; 
	private CharacterController characterController;

	[Header("移動の速さ"), SerializeField]
	private float _speed = 3;

	[Header("ジャンプする瞬間の速さ"), SerializeField]
	private float _jumpSpeed = 7;

	[Header("重力加速度"), SerializeField]
	private float _gravity = 15;

	[Header("落下時の速さ制限（Infinityで無制限）"), SerializeField]
	private float _fallSpeed = 10;

	[Header("落下の初速"), SerializeField]
	private float _initFallSpeed = 2;

	private PlayerInput playerInput;

	private Vector2 _inputMove;
	private float _verticalVelocity;
	private float _turnVelocity;
	private bool _isGroundedPrev;

	Animator animator;

	public void OnEnable()
	{
		playerInput.actions["Move"].performed += OnMove;
		playerInput.actions["Move"].canceled += OnMoveCancel;

		
		playerInput.actions["Attack"].performed += OnAttack;
		playerInput.actions["Attack"].canceled += OnAttackCansel;
		
	}

	private void OnDisable()
	{
		playerInput.actions["Move"].performed -= OnMove;
		playerInput.actions["Move"].canceled -= OnMoveCancel;

		playerInput.actions["Attack"].performed -= OnAttack;
		playerInput.actions["Attack"].canceled -= OnAttackCansel;
		
	}


	public void OnMove(InputAction.CallbackContext context)
	{
		// 入力値を保持しておく
		_inputMove = context.ReadValue<Vector2>();
		animator.SetBool("Move", true);
	}
	private void OnMoveCancel(InputAction.CallbackContext context)
	{
		// 入力値を保持しておく
		_inputMove = context.ReadValue<Vector2>();
		animator.SetBool("Move", false);
	}

	public void OnAttack(InputAction.CallbackContext context)
	{

		animator.SetTrigger("Attack");
	}

	private void OnAttackCansel(InputAction.CallbackContext context)
	{
		animator.SetTrigger("Idle");
	}

	// Start is called before the first frame update
	void Start()
    {
		animator = player.GetComponentInChildren<Animator>();
    }
	private void Awake()
	{
		_transform = transform;
		characterController = GetComponent<CharacterController>();
		animator = GetComponent<Animator>();
		playerInput =GetComponent<PlayerInput>();
	}



	private void FixedUpdate()
	{
		var isGrounded = characterController.isGrounded;

		if (isGrounded && !_isGroundedPrev)
		{
			// 着地する瞬間に落下の初速を指定しておく
			_verticalVelocity = -_initFallSpeed;
		}
		else if (!isGrounded)
		{
			// 空中にいるときは、下向きに重力加速度を与えて落下させる
			_verticalVelocity -= _gravity * Time.deltaTime;

			// 落下する速さ以上にならないように補正
			if (_verticalVelocity < -_fallSpeed)
				_verticalVelocity = -_fallSpeed;
		}

		_isGroundedPrev = isGrounded;

		
		// 操作入力と鉛直方向速度から、現在速度を計算
		var moveVelocity = new Vector3(
			_inputMove.x * _speed,
			_verticalVelocity,
			_inputMove.y * _speed
		);

		
		// 現在フレームの移動量を移動速度から計算
		var moveDelta = moveVelocity * Time.deltaTime;

		// CharacterControllerに移動量を指定し、オブジェクトを動かす
		characterController.Move(moveDelta);

		if (_inputMove != Vector2.zero)
		{
			//animator.SetBool("Move", true);
			// 移動入力がある場合は、振り向き動作も行う
			/*
			// 操作入力からy軸周りの目標角度[deg]を計算
			var targetAngleY = -Mathf.Atan2(moveVelocity.z, moveVelocity.x)
				* Mathf.Rad2Deg + 90;

			// イージングしながら次の回転角度[deg]を計算
			var angleY = Mathf.SmoothDampAngle(
				_transform.eulerAngles.y,
				targetAngleY,
				ref _turnVelocity,
				0.1f
			);

			// オブジェクトの回転を更新
			_transform.rotation = Quaternion.Euler(0, angleY, 0);
			*/

			transform.rotation = Quaternion.Lerp(
				transform.rotation,
				Quaternion.LookRotation(Vector3.Scale(moveVelocity, new Vector3(1, 0, 1))),
				0.1f);
		}
		else
		{
			animator.SetBool("Move", false);
		}
	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
