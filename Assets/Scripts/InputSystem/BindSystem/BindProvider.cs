using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace InputSystem
{
	public class BindProvider
	{
		private const string DIRECTIONAL_BIND_PATH = "Binds/DirectionalBind";
		private const string KEY_BIND_PATH = "Binds/KeyBind";
		
		private static BindProvider _instance;

		public List<DirectionBind> DirectionBinds { get; private set; }
		public List<KeyBind> KeyBinds { get; private set; }

		private BindProvider()
		{
			DirectionBinds = new List<DirectionBind>();
			KeyBinds = new List<KeyBind>();

			DirectionBind[] directionalBinds = Resources.LoadAll<DirectionBind>(DIRECTIONAL_BIND_PATH);
			
			if (directionalBinds.Length == 0)
				throw new NullReferenceException("Directional bind is not found");
			
			DirectionBinds.AddRange(directionalBinds);

			KeyBind[] keyBinds = Resources.LoadAll<KeyBind>(KEY_BIND_PATH);

			if (keyBinds.Length == 0)
				throw new NullReferenceException("Key bind is not found");
			
			KeyBinds.AddRange(keyBinds);			
		}

		public static BindProvider GetInstance()
		{
			if (_instance is null)
			{
				_instance = new BindProvider();
			}

			return _instance;
		}
		
		public DirectionBind GetBind(DirectionBindType bindType)
		{
			return DirectionBinds.First(b => b.DirectionBindType == bindType);
		}

		public KeyBind GetBind(KeyBindType bindType)
		{
			return KeyBinds.First(b => b.KeyBindType == bindType);
		}
		
	}
}