<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/659310713/17.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T1174644)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# WinForms - How to create custom shapes based on DiagramContainers

This example demonstrates how to create custom shapes that are consist of DiagramContainers with several inner shapes. You can use this technique when you need to create custom shapes whose geometry can be build using several predefined shapes combined together.

To accomplish this task, you can create a container and add static, non-selectable shapes:

```cs
public DiagramContainer CreateContainerShape1() {
	var container = new DiagramContainer();
	container.Appearance.BorderSize = 0;
	container.Appearance.BackColor = Color.Transparent;

	var innerShape1 = new DiagramShape() {
		CanSelect = false,
		CanChangeParent = false,
		CanEdit = false,
		CanCopyWithoutParent = false,
		CanDeleteWithoutParent = false,
		CanMove = false,
		Shape = BasicShapes.Trapezoid,
		Anchors = Sides.Top | Sides.Left | Sides.Right,
		Height = 50,
		Width = 200,

		Content = "Custom text"
	};


	var innerShape2 = new DiagramShape()
	{
		CanSelect = false,
		CanChangeParent = false,
		CanEdit = false,
		CanCopyWithoutParent = false,
		CanDeleteWithoutParent = false,
		CanMove = false,
		Shape = BasicShapes.Rectangle,
		Anchors = Sides.All,
		Height = 150,
		Width = 200,
		Position = new DevExpress.Utils.PointFloat(0, 50),
	};


	container.Items.Add(innerShape1);
	container.Items.Add(innerShape2);

	return container;
}

```

After that, register a custom FactoryItemTool that creates this container's instance:

```cs
void RegisterStencil() {
	var stencil = new DiagramStencil("CustomStencil", "Custom Shapes");

	var itemTool = new FactoryItemTool("CustomShape1",
		() => "Custom Shape 1",
		diagram => CreateContainerShape1(),
		new System.Windows.Size(200, 200), false);

	stencil.RegisterTool(itemTool);
	DiagramToolboxRegistrator.RegisterStencil(stencil);

	diagramControl1.OptionsBehavior.SelectedStencils = new StencilCollection() { "CustomStencil" };
}

```

See also: [WinForms DiagramControl - Register FactoryItemTools for Regular and Custom Shapes](https://supportcenter.devexpress.com/internal/ticket/details/T1174024).
## Files to Review

- link.cs (VB: link.vb)
- link.js
- ...

## Documentation

- link
- link
- ...

## More Examples

- link
- link
- ...
