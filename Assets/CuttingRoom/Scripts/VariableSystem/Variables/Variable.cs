﻿using UnityEngine;
using System;

namespace CuttingRoom.VariableSystem.Variables
{
	[ExecuteInEditMode]
	public class Variable : MonoBehaviour
	{
		public string Name = null;

		[HideInInspector]
		public string guid = string.Empty;

		/// <summary>
		/// Callback which is invoked when variable changes.
		/// </summary>
		public delegate void OnVariableSetCallback(Variable variable);
		public event OnVariableSetCallback OnVariableSet = null;

#if UNITY_EDITOR
		private void Awake()
		{
			if (guid == string.Empty)
			{
				// Generate a guid.
				guid = Guid.NewGuid().ToString();
			}
		}
#endif

        public virtual void SetValue(object value)
        {
            throw new NotImplementedException();
        }

        public virtual string GetValueAsString()
		{
			return string.Empty;
		}

		public virtual void SetValueFromString(string value)
		{
			throw new NotImplementedException();
        }

        /// <summary>
        /// Compares a value with this variables own value.
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public virtual bool ValueEqual(object val)
        {
            throw new NotImplementedException();
        }

        protected void RegisterVariableSet()
		{
			OnVariableSet?.Invoke(this);
		}
	}
}