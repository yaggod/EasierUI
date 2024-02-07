﻿using EasierUI.Controls.Contrainers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace EasierUI.Controls.Factories
{
	public class DefaultControlsFactory : ControlsFactory
	{
		private TMP_DefaultControls.Resources __defaultResourcesTMP = new TMP_DefaultControls.Resources();
		private DefaultControls.Resources _defaultResources = new DefaultControls.Resources();
		private DefaultControls.Resources _resources = new DefaultControls.Resources()
		{
			checkmark = SpritesHelper.GetFromBitmap(Images.checkmark)
		};

		private const float DefaultSensivity = 10;

		public static DefaultControlsFactory Instance
		{
			get;
		} = new DefaultControlsFactory();

		public override ButtonContrainer CreateButton()
		{
			GameObject GO = TMP_DefaultControls.CreateButton(__defaultResourcesTMP);

			return new ButtonContrainer(
					GO,
					GO.GetComponent<Button>(),
					GO.GetComponent<Image>(),
					GO.GetComponentInChildren<TextMeshProUGUI>()
				);
		}

		public override InputFieldContrainer CreateInputField()
		{
			GameObject GO = TMP_DefaultControls.CreateInputField(__defaultResourcesTMP);
			TextMeshProUGUI text = GO.transform.Find("Text Area/Text").gameObject.GetComponent<TextMeshProUGUI>();

			return new InputFieldContrainer(
					GO,
					GO.GetComponent<TMP_InputField>(),
					text,
					GO.transform.Find("Text Area/Placeholder").gameObject.GetComponent<TextMeshProUGUI>(),
					text.GetComponent<Image>()
				);
		}

		public override PanelContainer CreatePanel()
		{
			GameObject GO = DefaultControls.CreatePanel(_resources);

			return new PanelContainer(GO, GO.GetComponent<RectTransform>());
		}

		public override SliderContrainer CreateSlider()
		{
			GameObject GO = DefaultControls.CreateSlider(_resources);

			return new SliderContrainer(
					GO, 
					GO.GetComponent<Slider>(), 
					GO.transform.Find("Background").gameObject.GetComponent<Image>()
				);
		}

		public override ToggleContrainer CreateToggle()
		{
			GameObject GO = DefaultControls.CreateToggle(_resources);
			Toggle toggle = GO.GetComponent<Toggle>();
			toggle.isOn = false;

			// little crutch
			Text text_ = GO.GetComponentInChildren<Text>();
			GameObject textObject = text_.gameObject;
			Object.DestroyImmediate(text_);

			return new ToggleContrainer(
					GO,
					toggle,
					GO.transform.Find("Background").gameObject.GetComponent<Image>(),
					GO.transform.Find("Background/Checkmark").gameObject.GetComponent<Image>(),
					textObject.AddComponent<TextMeshPro>()
				);
		}

		public override ScrollContainer CreateVerticalScroll()
		{
			GameObject GO = DefaultControls.CreateScrollView(_resources);
			ScrollRect scroll = GO.GetComponent<ScrollRect>();
			scroll.horizontal = false;
			scroll.scrollSensitivity = DefaultSensivity;

			return new ScrollContainer(
					GO,
					scroll,
					GO.GetComponent<Image>(),
					GO.transform.Find("Viewport/Content").gameObject
				);
		}

		public override ImageContrainer CreateImage()
		{
			GameObject GO = DefaultControls.CreateImage(_resources);

			return new ImageContrainer(
					GO,
					GO.GetComponent<Image>()
				);
		}

	}
	
}
