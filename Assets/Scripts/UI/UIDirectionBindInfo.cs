using InputSystem;
using System;
using UnityEngine;

namespace UI
{
	public class UIDirectionBindInfo : UIBindInfo
	{
		[SerializeField] private DirectionBindType _directionBindType;
		[SerializeField] private DirectionKey _directionKey;
		
		private DirectionBind _directionBind;
		private BindHandler _bindHandler;

		private void Awake()
		{
			_bindHandler = FindObjectOfType<BindHandler>();

			if (_bindHandler == null)
				throw new NullReferenceException("BindHandler is not found on scene");

			_directionBind = BindProvider.GetInstance().GetBind(_directionBindType);

			_directionBind.ChangeBindEvent += SetTextOnButton;
			
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
			if (_directionKey == DirectionKey.Negative)
			{
				_buttonText.text = _directionBind.GetKeyCodeData.NegativeKey.ToString();
				return;
			}

			_buttonText.text = _directionBind.GetKeyCodeData.PositiveKey.ToString();
		}

		private void ChangeBindKey(KeyCode newKey)
		{
			if (_directionKey == DirectionKey.Negative)
			{
				_bindHandler.ChangeKey(_directionBindType, DirectionKey.Negative, newKey);
				return;
			}
			
			_bindHandler.ChangeKey(_directionBindType, DirectionKey.Positive, newKey);
		}
	}
}