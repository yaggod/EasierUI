using EasierUI.Controls.Contrainers;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace EasierUI.Controls.Factories
{
	public class DefaultControlsFactory : ControlsFactory
	{
		private const float DefaultSensivity = 10;

		public static DefaultControlsFactory Instance
		{
			get;
		} = new DefaultControlsFactory();

		protected override ButtonContrainer CreateButton(ControlsResources.Resources resources = new ControlsResources.Resources())
		{
			GameObject GO = TMP_DefaultControls.CreateButton(ControlsResources.ConvertToTMP(resources));
			TextMeshProUGUI text = GO.GetComponentInChildren<TextMeshProUGUI>();
			if(resources.font != null)
			{
				text.font = resources.font;
			}

			return new ButtonContrainer(
					GO,
					GO.GetComponent<Button>(),
					GO.GetComponent<Image>(),
					text
				);
		}

		protected override InputFieldContrainer CreateInputField(ControlsResources.Resources resources = new ControlsResources.Resources())
		{
			GameObject GO = TMP_DefaultControls.CreateInputField(ControlsResources.ConvertToTMP(resources));
			TextMeshProUGUI text = GO.transform.Find("Text Area/Text").gameObject.GetComponent<TextMeshProUGUI>();
			TextMeshProUGUI textPlaceHolder = GO.transform.Find("Text Area/Placeholder").gameObject.GetComponent<TextMeshProUGUI>();
			if(resources.font != null)
			{
				text.font = resources.font;
				textPlaceHolder.font = resources.font;
			}

			return new InputFieldContrainer(
					GO,
					GO.GetComponent<TMP_InputField>(),
					text,
					textPlaceHolder,
					GO.GetComponent<Image>()
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
			GameObject GO = DefaultControls.CreateToggle(ControlsResources.ConvertToDefault(resources));
			Toggle toggle = GO.GetComponent<Toggle>();
			toggle.isOn = false;

			// little crutch
			Text text_ = GO.GetComponentInChildren<Text>();
			Object.DestroyImmediate(text_.gameObject);
			// add real text object
			GameObject textObject = TMP_DefaultControls.CreateText(ControlsResources.ConvertToTMP(resources));
			textObject.transform.SetParent(GO.transform, worldPositionStays: false);
			SetLayerRecursively(textObject, GO.layer);
			TextMeshProUGUI text = textObject.GetComponent<TextMeshProUGUI>();
			if(resources.font != null)
				text.font = resources.font;
			
			return new ToggleContrainer(
					GO,
					toggle,
					GO.transform.Find("Background").gameObject.GetComponent<Image>(),
					GO.transform.Find("Background/Checkmark").gameObject.GetComponent<Image>(),
					text
				);
		}

		private static void SetLayerRecursively(GameObject go, int layer)
		{
			go.layer = layer;
			Transform transform = go.transform;
			for (int i = 0; i < transform.childCount; i++)
			{
				SetLayerRecursively(transform.GetChild(i).gameObject, layer);
			}
		}

		protected override ScrollContainer CreateVerticalScroll(ControlsResources.Resources resources = new ControlsResources.Resources())
		{
			GameObject GO = DefaultControls.CreateScrollView(ControlsResources.ConvertToDefault(resources));
			ScrollRect scroll = GO.GetComponent<ScrollRect>();
			scroll.horizontal = false;
			scroll.scrollSensitivity = DefaultSensivity;
			GameObject scrollbarV = GO.transform.Find("Scrollbar Vertical").gameObject;
			GameObject scrollbarH = GO.transform.Find("Scrollbar Horizontal").gameObject;
			scrollbarV.GetComponent<Image>().sprite = resources.childBackground;
			scrollbarH.GetComponent<Image>().sprite = resources.childBackground;

			return new ScrollContainer(
					GO,
					scroll,
					GO.GetComponent<Image>(),
					GO.transform.Find("Viewport/Content").gameObject,
					scrollbarV,
					scrollbarH
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
