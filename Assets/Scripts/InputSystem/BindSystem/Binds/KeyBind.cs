using UnityEngine;

namespace InputSystem
{
	[CreateAssetMenu(fileName = "KeyBind", menuName = "ScriptableObject/Binds/KeyBind")]
	public class KeyBind : Bind<bool>
	{
		[SerializeField] private KeyBindType _keyBindType;
		[SerializeField] private KeyCode _keyCode;
		
		private bool _keyDown;
		
		private bool _isPressed;

		private bool _keyUp;

		public KeyCode KeyCode => _keyCode;
		public KeyBindType KeyBindType => _keyBindType;
		
		public override void Update()
		{
			KeySetDown();
			KeySetUp();
		}
		
		public override bool GetBindValue() => _isPressed;

		public void ChangeKeyCode(KeyCode newKeyCode)
		{
			_keyCode = newKeyCode;
			ChangeBindEvent.Invoke();
		}

		public bool GetKeyDown()
		{
			if (!_keyDown)
				return false;

			_keyDown = false;
			
			return true;
		}
		
		private void KeySetDown()
		{
			if (!Input.GetKeyDown(_keyCode))
				return;

			_keyDown = true;
			_isPressed = true;
		}

		private void KeySetUp()
		{
			if (!Input.GetKeyUp(_keyCode))
				return;

			_isPressed = false;
			_keyDown = false;
		}
	}
}