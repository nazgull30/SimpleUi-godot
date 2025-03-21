﻿using System.Collections.Generic;
using Godot;
using Godot.Collections;
using SimpleUi.Interfaces;
using SimpleUi.Models;
using VContainer;

namespace SimpleUi.Abstracts
{
	public abstract class UiController<T> : IUiController where T : IUiView
	{
		private readonly Stack<UiControllerState> _states = new();
		private readonly UiControllerState _defaultState = new(false, false, 0);

		private UiControllerState _currentState;

		protected T View { private set; get; }
		public bool IsActive { get; private set; }
		public bool InFocus { get; private set; }

        [Inject]
        public void SetView(T view, IObjectResolver resolver)
        {
            View = view;
            resolver.Inject(view);
        }
		
		public void SetState(UiControllerState state)
		{
			_currentState = state;
			_states.Push(state);
		}

		public void ProcessStateOrder()
		{
			if (!_currentState.IsActive)
				return;
			SetOrder(_currentState.Order);
		}

		public void ProcessState()
		{
			if (IsActive != _currentState.IsActive)
			{
				IsActive = _currentState.IsActive;
				if (_currentState.IsActive)
					Show();
				else
					Hide();
			}

			if (InFocus == _currentState.InFocus)
				return;
			InFocus = _currentState.InFocus;
			OnHasFocus(_currentState.InFocus);
		}

		public void Back()
		{
			if (_states.Count > 0)
				_states.Pop();
			if (_states.Count == 0)
			{
				_currentState = _defaultState;
				return;
			}

			SetState(_states.Pop());
		}

		Array<Control> IUiController.GetUiElements()
		{
			return View.GetUiElements();
		}

		private void Show()
		{
			View.Show();
			OnShow();
		}

		public virtual void OnShow()
		{
		}

		private void Hide()
		{
			View.Hide();
			OnHide();
		}

		public virtual void OnHide()
		{
		}

		public virtual void OnHasFocus(bool inFocus)
		{
		}

		private void SetOrder(int index)
		{
			View.SetOrder(index);
		}
	}
}