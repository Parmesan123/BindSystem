using System;
using UI;
using UnityEngine;

namespace InputSystem
{
	[CreateAssetMenu(fileName = "DirectionalBind", menuName = "ScriptableObject/Binds/DirectionalBind")]
	public class DirectionBind : Bind<float>
	{
		[SerializeField] private DirectionBindType _directionBindType;
		[SerializeField] private KeyCodeData _keyCodes;

		[Serializable]
		public struct KeyCodeData
		{
			public KeyCode NegativeKey;
			public KeyCode PositiveKey;
		}
		
		private float _value;
		
		public DirectionBindType DirectionBindType => _directionBindType;

		public KeyCodeData GetKeyCodeData => _keyCodes;
		
		public override void Update()
		{
			SetValue();
		}

		public override float GetBindValue() => _value;

		public void ChangeKey((KeyCode negativeKey, KeyCode positiveKey) keyCodes)
		{
			_keyCodes.NegativeKey = keyCodes.negativeKey;
			_keyCodes.PositiveKey = keyCodes.positiveKey;
			ChangeBindEvent.Invoke();
		}

		public void ChangeKey(DirectionKey directionKey, KeyCode newKey)
		{
			switch (directionKey)
			{
				case DirectionKey.Positive:
					_keyCodes.PositiveKey = newKey;
					break;
				case DirectionKey.Negative:
					_keyCodes.NegativeKey = newKey;
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(directionKey), directionKey, null);
			}
			ChangeBindEvent.Invoke();
		}
		
		private void SetValue()
		{
			bool pressedAnyKey = false;
			
			if (Input.GetKey(_keyCodes.NegativeKey))
			{
				_value -= 1;
				pressedAnyKey = true;
			}

			if (Input.GetKey(_keyCodes.PositiveKey))
			{
				_value += 1;
				pressedAnyKey = true;
			}

			if (!pressedAnyKey ||
				(Input.GetKey(_keyCodes.NegativeKey) && Input.GetKey(_keyCodes.PositiveKey))){
				_value = 0;
				return;
			}
			
			if (_value != 0)
				_value /= Mathf.Abs(_value);
		}
		
	}
}