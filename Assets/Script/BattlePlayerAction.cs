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

	[Header("�ړ��̑���"), SerializeField]
	private float _speed = 3;

	[Header("�W�����v����u�Ԃ̑���"), SerializeField]
	private float _jumpSpeed = 7;

	[Header("�d�͉����x"), SerializeField]
	private float _gravity = 15;

	[Header("�������̑��������iInfinity�Ŗ������j"), SerializeField]
	private float _fallSpeed = 10;

	[Header("�����̏���"), SerializeField]
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
		// ���͒l��ێ����Ă���
		_inputMove = context.ReadValue<Vector2>();
		animator.SetBool("Move", true);
	}
	private void OnMoveCancel(InputAction.CallbackContext context)
	{
		// ���͒l��ێ����Ă���
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
			// ���n����u�Ԃɗ����̏������w�肵�Ă���
			_verticalVelocity = -_initFallSpeed;
		}
		else if (!isGrounded)
		{
			// �󒆂ɂ���Ƃ��́A�������ɏd�͉����x��^���ė���������
			_verticalVelocity -= _gravity * Time.deltaTime;

			// �������鑬���ȏ�ɂȂ�Ȃ��悤�ɕ␳
			if (_verticalVelocity < -_fallSpeed)
				_verticalVelocity = -_fallSpeed;
		}

		_isGroundedPrev = isGrounded;

		
		// ������͂Ɖ����������x����A���ݑ��x���v�Z
		var moveVelocity = new Vector3(
			_inputMove.x * _speed,
			_verticalVelocity,
			_inputMove.y * _speed
		);

		
		// ���݃t���[���̈ړ��ʂ��ړ����x����v�Z
		var moveDelta = moveVelocity * Time.deltaTime;

		// CharacterController�Ɉړ��ʂ��w�肵�A�I�u�W�F�N�g�𓮂���
		characterController.Move(moveDelta);

		if (_inputMove != Vector2.zero)
		{
			//animator.SetBool("Move", true);
			// �ړ����͂�����ꍇ�́A�U�����������s��
			/*
			// ������͂���y������̖ڕW�p�x[deg]���v�Z
			var targetAngleY = -Mathf.Atan2(moveVelocity.z, moveVelocity.x)
				* Mathf.Rad2Deg + 90;

			// �C�[�W���O���Ȃ��玟�̉�]�p�x[deg]���v�Z
			var angleY = Mathf.SmoothDampAngle(
				_transform.eulerAngles.y,
				targetAngleY,
				ref _turnVelocity,
				0.1f
			);

			// �I�u�W�F�N�g�̉�]���X�V
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
