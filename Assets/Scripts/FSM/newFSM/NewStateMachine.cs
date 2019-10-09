using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 	public class NewStateMachine : MonoBehaviour
	{
		/// Начальное состояние.
		/// Задается в Inspector'е.
		[SerializeField]
		NewState startingState;

		/// Текущее состояние.
		NewState current;

		/// Доступ к текущему состоянию.
		public NewState Current
		{
			get { return current; }
		}

		/// Инициализация (переход в начальное состояние).
		void Start()
		{
			Reset();
		}

		/// Переводит стейт машину в начальное состояние.
		public void Reset()
		{
			Transit(startingState);
		}

		/// На каждом кадре проверяет, не нужно ли совершить
		/// переход. Если нужно - совершает.
		void Update()
		{
			if (current == null)
				return;

			var next = current.GetNext();
			if (next != null)
				Transit(next);
		}

		/// Собственно, переход.
		/// Выходит из текущего состояния,
		/// делает следующее текущим и
		/// входит в него.
		void Transit(NewState next)
		{
			if (current != null)
				current.Exit();

			current = next;
			if (current != null)
				current.Enter();
		}
	}
 
