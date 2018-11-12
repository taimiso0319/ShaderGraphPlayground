using System.Linq;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public static class HierarchyIcons
{
	private static readonly Color mDisabledColor = new Color (1, 1, 1, 0.5f);

	private const int WIDTH = 16;
	private const int HEIGHT = 16;


	static HierarchyIcons ()
	{
		EditorApplication.hierarchyWindowItemOnGUI += ShowHierarchyIcons;
	}

	private static void ShowHierarchyIcons (int instanceID, Rect selectionRect)
	{
		var go = EditorUtility.InstanceIDToObject (instanceID) as GameObject;

		if (go == null) {
			return;
		}

		var pos = selectionRect;
		pos.x = pos.xMax - WIDTH;
		pos.width = WIDTH;
		pos.height = HEIGHT;

		var components = go
			.GetComponents<Component> ()
			.Where (c => c != null)
			.Where (c => !(c is Transform))
			.Reverse ();

		Rect r = new Rect (pos);
		r.width = pos.width;
		go.SetActive (GUI.Toggle (r, go.activeSelf, string.Empty));

		pos.x -= pos.width;

		var current = Event.current;
		Texture lastImage = null;
		foreach (var c in components) {
			Texture image = AssetPreview.GetMiniThumbnail (c);

			if (image == null && c is MonoBehaviour) {
				var ms = MonoScript.FromMonoBehaviour (c as MonoBehaviour);
				var path = AssetDatabase.GetAssetPath (ms);
				image = AssetDatabase.GetCachedIcon (path);
				if (lastImage == image) {
					lastImage = image;
					continue;
				}
			}

			if (image == null) {
				continue;
			}
			if (lastImage == image) {
				lastImage = image;
				continue;
			}

			if (current.type == EventType.MouseDown &&
			    pos.Contains (current.mousePosition)) {
				c.SetEnable (!c.IsEnabled ());
			}

			var color = GUI.color;
			GUI.color = c.IsEnabled () ? Color.white : mDisabledColor;
			GUI.DrawTexture (pos, image, ScaleMode.ScaleToFit);
			GUI.color = color;
			pos.x -= pos.width;
			lastImage = image;
		}
	}

	public static bool IsEnabled (this Component self)
	{
		if (self == null) {
			return true;
		}
		var type = self.GetType ();

		var property = type.GetProperty ("enabled", typeof(bool));

		if (property == null) {
			return true;
		}

		return (bool)property.GetValue (self, null);
	}

	public static void SetEnable (this Component self, bool isEnabled)
	{
		if (self == null) {
			return;
		}
		if (self is MonoBehaviour) {
			return;
		}
		var type = self.GetType ();
		var property = type.GetProperty ("enabled", typeof(bool));

		if (property == null) {
			return;
		}

		property.SetValue (self, isEnabled, null);
	}
}