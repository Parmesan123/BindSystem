using InputSystem;
using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace UI
{
	public class UIKeyBindInfo : UIBindInfo
	{
		[SerializeField] private KeyBindType _keyBindType;
		
		private KeyBind _keyBind;
		private BindHandler _bindHandler;

		private void Awake()
		{
			_bindHandler = FindObjectOfType<BindHandler>();

			if (_bindHandler == null)
				throw new NullReferenceException("BindHandler is not found on scene");

			_keyBind = BindProvider.GetInstance().GetBind(_keyBindType);

			_keyBind.ChangeBindEvent += SetTextOnButton;
			
			SetTextOnButton();
		}

		private void OnGUI()
		{
			if (!_isChangingBind)
				return;

			Event e = Event.current;
			
			if (!e.isKey)
				return;

			_isChangingBind = false;
			
			ChangeBindKey(e.keyCode);
			
			_changeBindPanel.SetActive(false);
			
		}
		
		protected override void SetTextOnButton()
		{
			_buttonText.text = _keyBind.KeyCode.ToString();
		}

		private void ChangeBindKey(KeyCode newKey)
		{
			_bindHandler.ChangeKey(_keyBindType, newKey);
		}
	}
}