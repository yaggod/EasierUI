using UnityEngine;
using UnityEngine.UI;

namespace EasierUI.Controls.Contrainers
{
	public class ScrollContainer : ControlContainer
	{
		public readonly GameObject ContentHolder;
		public readonly ScrollRect Scroll;
		public readonly Image Background;
		public ScrollContainer(GameObject GO, ScrollRect scroll, Image background, GameObject contentHolder) : base(GO)
		{
			Scroll = scroll;
			ContentHolder = contentHolder;
			Background = background;
		}

		internal void SetHeight(float height)
		{
			RectTransform rectTransform = ContentHolder.transform as RectTransform;
			if (rectTransform != null)
			{
				Vector2 sizeDelta = rectTransform.sizeDelta;
				rectTransform.sizeDelta = new Vector2(sizeDelta.x, height);
			}
		}
	}
}