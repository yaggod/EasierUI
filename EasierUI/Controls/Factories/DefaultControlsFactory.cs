using EasierUI.Controls.Contrainers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace EasierUI.Controls.Factories
{
	public class DefaultControlsFactory : ControlsFactory
	{
		private DefaultControls.Resources _toggleResources = new DefaultControls.Resources()
		{
			checkmark = SpritesHelper.GetFromBitmap(Images.checkmark)
		};

		private const float DefaultSensivity = 10;

		public static DefaultControlsFactory Instance
		{
			get;
		} = new DefaultControlsFactory();

		protected override ButtonContrainer CreateButton(ControlsResources.Resources resources = new ControlsResources.Resources())
		{
			GameObject GO = TMP_DefaultControls.CreateButton(ControlsResources.ConvertToTMP(resources));

			return new ButtonContrainer(
					GO,
					GO.GetComponent<Button>(),
					GO.GetComponent<Image>(),
					GO.GetComponentInChildren<TextMeshProUGUI>()
				);
		}

		protected override InputFieldContrainer CreateInputField(ControlsResources.Resources resources = new ControlsResources.Resources())
		{
			GameObject GO = TMP_DefaultControls.CreateInputField(ControlsResources.ConvertToTMP(resources));
			TextMeshProUGUI text = GO.transform.Find("Text Area/Text").gameObject.GetComponent<TextMeshProUGUI>();

			return new InputFieldContrainer(
					GO,
					GO.GetComponent<TMP_InputField>(),
					text,
					GO.transform.Find("Text Area/Placeholder").gameObject.GetComponent<TextMeshProUGUI>(),
					text.GetComponent<Image>()
				);
		}

		protected override PanelContainer CreatePanel(ControlsResources.Resources resources = new ControlsResources.Resources())
		{
			GameObject GO = DefaultControls.CreatePanel(ControlsResources.ConvertToDefault(resources));

			return new PanelContainer(GO, GO.GetComponent<RectTransform>());
		}

		protected override SliderContrainer CreateSlider(ControlsResources.Resources resources = new ControlsResources.Resources())
		{
			GameObject GO = DefaultControls.CreateSlider(ControlsResources.ConvertToDefault(resources));

			return new SliderContrainer(
					GO, 
					GO.GetComponent<Slider>(), 
					GO.transform.Find("Background").gameObject.GetComponent<Image>()
				);
		}

		protected override ToggleContrainer CreateToggle(ControlsResources.Resources resources = new ControlsResources.Resources())
		{
			GameObject GO = DefaultControls.CreateToggle(resources.Equals(new ControlsResources.Resources()) ? _toggleResources : ControlsResources.ConvertToDefault(resources));
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

		protected override ScrollContainer CreateVerticalScroll(ControlsResources.Resources resources = new ControlsResources.Resources())
		{
			GameObject GO = DefaultControls.CreateScrollView(ControlsResources.ConvertToDefault(resources));
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

		protected override ImageContrainer CreateImage(ControlsResources.Resources resources = new ControlsResources.Resources())
		{
			GameObject GO = DefaultControls.CreateImage(ControlsResources.ConvertToDefault(resources));

			return new ImageContrainer(
					GO,
					GO.GetComponent<Image>()
				);
		}

	}
	
}
