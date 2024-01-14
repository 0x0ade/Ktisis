using System;

using Dalamud.Interface.Utility.Raii;

using ImGuiNET;

using Ktisis.Editor;
using Ktisis.Editor.Context;
using Ktisis.Interface.Components.Actors;
using Ktisis.Interface.Types;
using Ktisis.Scene.Entities.Game;

namespace Ktisis.Interface.Windows.Editors;

public class ActorEditWindow : EntityEditWindow<ActorEntity> {
	private readonly CustomizeEditor _custom;
	private readonly EquipmentEditor _equip;
	
	public ActorEditWindow(
		IEditorContext context,
		CustomizeEditor custom,
		EquipmentEditor equip
	) : base("Actor Editor", context) {
		this._custom = custom;
		this._equip = equip;
	}

	// Draw tabs
	
	public override void Draw() {
		using var _ = ImRaii.TabBar("##ActorEditTabs");
		this.DrawTab("Appearance", this.DrawCustomize);
		this.DrawTab("Equipment", this.DrawEquipment);
	}

	private void DrawTab(string name, Action draw) {
		using var tab = ImRaii.TabItem(name);
		if (tab.Success) draw.Invoke();
	}
	
	// Customize

	private unsafe void DrawCustomize() {
		var chara = this.Target.GetCharacter();
		if (chara == null) return;

		var custom = this.Target.GetCustomize();
		if (custom != null)
			this._custom.Draw(custom.Value);
	}
	
	// Equipment

	private void DrawEquipment() {
		ImGui.Text("Equip :3");
	}
}
