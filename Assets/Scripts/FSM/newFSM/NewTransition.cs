using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 /// Базовый класс для переходов.
	/// Наследуемые компоненты должны быть выключены (disabled) в Inspector'е.
	public abstract class NewTransition : MonoBehaviour
	{
		/// Целевое состояние (куда переходим).
		/// Задается в Inspector'е.
		[SerializeField]
		NewState targetState;

		/// Проперти для получения целевого состояния.
		/// Используется в State при необходимости перехода.
		public NewState TargetState
		{
			get { return targetState; }
		}

		/// Когда переход должен произойти, необходимо в 
		/// наследнике установить это проперти в true.
		/// Проверяется оно в State.
		public bool NeedTransit
		{
			get;
			protected set;
		}
	}
 