using System;
using System.Collections.Generic;
using System.Linq;
using UI;
using UnityEngine;

namespace InputSystem
{
	public class BindHandler : MonoBehaviour
	{
		private List<DirectionBind> _directionBinds;
		private List<KeyBind> _keyBinds;

		private BindProvider _bindProvider;
		
		public void Awake()
		{
			_bindProvider =  BindProvider.GetInstance();

			_directionBinds = _bindProvider.DirectionBinds;
			_keyBinds = _bindProvider.KeyBinds;
		}
		
		private void Update()
		{
			UpdateDirectionBindValue();
			UpdateKeyBindValue();
		}

		public void ChangeKey(DirectionBindType bindType, DirectionKey directionKey, KeyCode newKey)
		{
			DirectionBind bind = _directionBinds.FirstOrDefault(b => b.GetKeyCodeData.NegativeKey == newKey);
			if(bind is not null)
				bind.ChangeKey(DirectionKey.Negative, KeyCode.None);

			bind = _directionBinds.FirstOrDefault(b => b.GetKeyCodeData.PositiveKey == newKey);
			if(bind is not null)
				bind.ChangeKey(DirectionKey.Positive, KeyCode.None);
			
			KeyBind keyBind = _keyBinds.FirstOrDefault(b => b.KeyCode == newKey);
			if (keyBind is not null)
				keyBind.ChangeKeyCode(KeyCode.None);

			bind = _directionBinds.First(b => b.DirectionBindType == bindType);

			bind.ChangeKey(directionKey, newKey);
		}

		public void ChangeKey(KeyBindType bindType, KeyCode newKey)
		{
			DirectionBind bind = _directionBinds.FirstOrDefault(b => b.GetKeyCodeData.NegativeKey == newKey);
			if(bind is not null)
				bind.ChangeKey(DirectionKey.Negative, KeyCode.None);

			bind = _directionBinds.FirstOrDefault(b => b.GetKeyCodeData.PositiveKey == newKey);
			if(bind is not null)
				bind.ChangeKey(DirectionKey.Positive, KeyCode.None);
			
			KeyBind keyBind = _keyBinds.FirstOrDefault(b => b.KeyCode == newKey);
			if (keyBind is not null)
				keyBind.ChangeKeyCode(KeyCode.None);
			
			keyBind = _keyBinds.First(b => b.KeyBindType == bindType);
			keyBind.ChangeKeyCode(newKey);
		}

		private void UpdateDirectionBindValue()
		{
			foreach (DirectionBind bind in _directionBinds)
			{
				bind.Update();
			}
		}

		private void UpdateKeyBindValue()
		{
			foreach (KeyBind keyBind in _keyBinds)
			{
				keyBind.Update();
			}
		}
	}
}