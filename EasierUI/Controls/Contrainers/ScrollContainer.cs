using UnityEngine;
using UnityEngine.UI;

namespace EasierUI.Controls
{
	public class ScrollContainer : ControlContainer
	{
		public readonly GameObject ContentHolder;
		public readonly ScrollRect Scroll;
		public readonly RectTransform ContentTransform;
		public ScrollContainer(GameObject GO, ScrollRect scroll, GameObject contentHolder, RectTransform contentTransform) : base(GO)
		{
			Scroll = scroll;
			ContentHolder = contentHolder;
			ContentTransform = contentTransform;
		}

		internal void SetHeight(float height)
		{
			Vector2 sizeDelta = ContentTransform.sizeDelta;
			ContentTransform.sizeDelta = new Vector2(sizeDelta.x, height);
		}
	}
}