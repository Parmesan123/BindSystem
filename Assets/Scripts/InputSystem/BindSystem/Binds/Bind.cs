using System;
using UnityEngine;

namespace InputSystem
{
	public abstract class Bind<T> : ScriptableObject
	{
		public Action ChangeBindEvent;
		
		public abstract T GetBindValue();

		public abstract void Update();
	}
}