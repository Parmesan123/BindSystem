using InputSystem;
using System;
using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;

namespace UI
{
	public abstract class UIBindInfo : MonoBehaviour
	{
		[SerializeField] protected GameObject _changeBindPanel;
		[SerializeField] protected TextMeshProUGUI _buttonText;

		protected bool _isChangingBind;

		protected abstract void SetTextOnButton();

		public void ChangeBind()
		{
			_changeBindPanel.SetActive(true);

			_isChangingBind = true;
		}
	}


	public enum DirectionKey
	{
		Positive,
		Negative
	}
}