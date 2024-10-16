<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/659310713/17.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T1174644)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# WinForms DiagramControl - Create Custom Shapes Based on Diagram Containers

The following example creates custom DevExpress Diagram shapes ([DiagramContainers](https://docs.devexpress.com/WindowsForms/DevExpress.XtraDiagram.DiagramContainer)) with multiple inner shapes. You can use this technique to create custom shapes if/when associated geometries must consist of combined predefined shapes.

![image](https://github.com/DevExpress-Examples/winforms-diagram-create-custom-shapes-based-on-diagram-containers/assets/65009440/58c4b65d-1a2e-4af8-ba8a-26dc9ff736ee)

## Implementation Details

To begin, you must:

1. Create a container and add static non-selectable shapes:

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

       var innerShape2 = new DiagramShape() {
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

2. Register a [FactoryItemTool](https://docs.devexpress.com/CoreLibraries/DevExpress.Diagram.Core.FactoryItemTool) to create an instance of this container:

   ```cs
   void RegisterStencil() {
       var stencil = new DiagramStencil("CustomStencil", "Custom Shapes");

       var itemTool = new FactoryItemTool("CustomShape1",
           () => "Custom Shape 1",
           diagram => CreateContainerShape1(),
           new System.Windows.Size(200, 200), 
           false
       );

       stencil.RegisterTool(itemTool);
       DiagramToolboxRegistrator.RegisterStencil(stencil);

       diagramControl1.OptionsBehavior.SelectedStencils = new StencilCollection() { "CustomStencil" };
   }
   ```

## Files to Review

- [Form1.cs](./CS/WindowsFormsApp4/Form1.cs) (VB: [Form1.vb](./VB/WindowsFormsApp4/Form1.vb))

## Documentation

- [DiagramContainer](https://docs.devexpress.com/WindowsForms/DevExpress.XtraDiagram.DiagramContainer)
- [Containers and Lists](https://docs.devexpress.com/WindowsForms/117672/controls-and-libraries/diagrams/diagram-items/containers)
- [Shapes](https://docs.devexpress.com/WindowsForms/116882/controls-and-libraries/diagrams/diagram-items/shapes)
- [Create Custom Diagram Items](https://docs.devexpress.com/WindowsForms/404797/controls-and-libraries/diagrams/diagram-items/create-custom-diagram-items)
- [Manage Item Interaction](https://docs.devexpress.com/WindowsForms/120271/controls-and-libraries/diagrams/diagram-items/managing-items-interaction)

## More Examples

- [WinForms DiagramControl - Register FactoryItemTools for Regular and Custom Shapes](https://github.com/DevExpress-Examples/winforms-diagram-register-factoryitemtools-for-shapes)
- [WinForms DiagramControl - Create Rotatable Containers with Shapes](https://github.com/DevExpress-Examples/winforms-diagram-create-rotatable-containers-with-shapes)
- [WinForms DiagramControl - Proportionally Resize Shapes Within the Parent Container](https://github.com/DevExpress-Examples/winforms-diagram-proportionally-resize-shapes-within-container)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-diagram-create-custom-shapes-based-on-diagram-containers&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-diagram-create-custom-shapes-based-on-diagram-containers&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
