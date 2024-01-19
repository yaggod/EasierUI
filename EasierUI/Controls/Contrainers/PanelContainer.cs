using UnityEngine;

namespace EasierUI.Controls
{
	public class PanelContainer : ControlContainer
	{
		public readonly RectTransform RectTransform;
		public PanelContainer(GameObject GO, RectTransform rectTransform) : base(GO)
		{
			RectTransform = rectTransform;
		}
	}
}