using JetBrains.Annotations;
using EasierUI.Controls.Contrainers;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace EasierUI.Controls.Factories
{
	public class DefaultControlsFactory : ControlsFactory
	{
		private DefaultControls.Resources _resources = new DefaultControls.Resources()
		{
			checkmark = SpritesHelper.GetFromBitmap(Images.checkmark)
		};
		private TMP_DefaultControls.Resources _resourcesTMP;

		private const float DefaultSensivity = 10;

		public static DefaultControlsFactory Instance
		{
			get;
		} = new DefaultControlsFactory();

		public override ButtonContrainer CreateButton()
		{
			GameObject GO = TMP_DefaultControls.CreateButton(_resourcesTMP);
			Button button = GO.GetComponent<Button>();
			Image image = GO.GetComponent<Image>();
			TextMeshProUGUI text = GO.GetComponentInChildren<TextMeshProUGUI>();

			return new ButtonContrainer(GO, button, image, text);
		}

		public override InputFieldContrainer CreateInputField()
		{
			GameObject GO = TMP_DefaultControls.CreateInputField(_resourcesTMP);
			TMP_InputField inputField = GO.GetComponent<TMP_InputField>();
			TextMeshProUGUI text = GO.transform.Find("Text Area/Text").gameObject.GetComponent<TextMeshProUGUI>();
			TextMeshProUGUI textPlaceholder = GO.transform.Find("Text Area/Placeholder").gameObject.GetComponent<TextMeshProUGUI>();
			Image image = text.GetComponent<Image>();

			return new InputFieldContrainer(GO, inputField, text, textPlaceholder, image);
		}

		public override PanelContainer CreatePanel()
		{
			GameObject GO = DefaultControls.CreatePanel(_resources);
			RectTransform rectTransform = GO.GetComponent<RectTransform>();

			return new PanelContainer(GO, rectTransform);
		}

		public override SliderContrainer CreateSlider()
		{
			GameObject GO = DefaultControls.CreateSlider(_resources);
			Slider slider = GO.GetComponent<Slider>();
			Image image = GO.transform.Find("Background").gameObject.GetComponent<Image>();

			return new SliderContrainer(GO, slider, image);
		}

		public override ToggleContrainer CreateToggle()
		{
			GameObject GO = DefaultControls.CreateToggle(_resources);
			Toggle toggle = GO.GetComponent<Toggle>();
			toggle.isOn = false;

			Image backgroundImage = GO.transform.Find("Background").gameObject.GetComponent<Image>();
			Image checkmarkImage = GO.transform.Find("Background/Checkmark").gameObject.GetComponent<Image>();
			Text text = GO.GetComponentInChildren<Text>();

			return new ToggleContrainer(GO, toggle, backgroundImage, checkmarkImage, text);
		}

		public override ScrollContainer CreateVerticalScroll()
		{
			GameObject GO = DefaultControls.CreateScrollView(_resources);
			ScrollRect scroll = GO.GetComponent<ScrollRect>();
			scroll.horizontal = false;
			GameObject content = GO.transform.Find("Viewport/Content").gameObject;
			scroll.scrollSensitivity = DefaultSensivity;
			RectTransform transform = content.GetComponent<RectTransform>();

			return new ScrollContainer(GO, scroll, content, transform);
		}

		public override ImageContrainer CreateImage()
		{
			GameObject GO = DefaultControls.CreateImage(_resources);
			Image image = GO.GetComponent<Image>();

			return new ImageContrainer(GO, image);
		}
	}
}
