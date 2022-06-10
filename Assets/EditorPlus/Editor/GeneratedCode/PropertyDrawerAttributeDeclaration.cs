using UnityEditor;

namespace EditorPlus.Editor {

	[CustomPropertyDrawer(typeof(EditorPlus.CustomSpaceAttribute))]
	[CustomPropertyDrawer(typeof(EditorPlus.DisableIfAttribute))]
	[CustomPropertyDrawer(typeof(EditorPlus.EnableIfAttribute))]
	[CustomPropertyDrawer(typeof(EditorPlus.DisabledAttribute))]
	[CustomPropertyDrawer(typeof(EditorPlus.HideInEditModeAttribute))]
	[CustomPropertyDrawer(typeof(EditorPlus.DisableInEditModeAttribute))]
	[CustomPropertyDrawer(typeof(EditorPlus.HelpBoxAttribute))]
	[CustomPropertyDrawer(typeof(EditorPlus.HideIfAttribute))]
	[CustomPropertyDrawer(typeof(EditorPlus.ShowIfAttribute))]
	[CustomPropertyDrawer(typeof(EditorPlus.IndentAttribute))]
	[CustomPropertyDrawer(typeof(EditorPlus.OnValueChangedAttribute))]
	[CustomPropertyDrawer(typeof(EditorPlus.HideInPlayModeAttribute))]
	[CustomPropertyDrawer(typeof(EditorPlus.DisableInPlayModeAttribute))]
	[CustomPropertyDrawer(typeof(EditorPlus.DropdownAttribute))]
	[CustomPropertyDrawer(typeof(EditorPlus.MinMaxSliderAttribute))]
	[CustomPropertyDrawer(typeof(EditorPlus.TagAttribute))]
	[CustomPropertyDrawer(typeof(EditorPlus.Editor.DefaultPropertyAttribute))]
	public partial class EditorPlusPropertyDrawer { }
}
