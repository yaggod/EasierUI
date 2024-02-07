using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace EasierUI.Controls
{
	public class SliderContrainer : ControlContainer
	{
		public readonly Slider Slider;
		public readonly Image BackgroundImage;
		public SliderContrainer(GameObject GO, Slider slider, Image backgroundImage) : base(GO)
		{
			BackgroundImage = backgroundImage;
			Slider = slider;
		}

		public void AddHandler(Action<float> handler)
		{
			Slider.onValueChanged.AddListener(new UnityAction<float>(handler));
		}
	}
}