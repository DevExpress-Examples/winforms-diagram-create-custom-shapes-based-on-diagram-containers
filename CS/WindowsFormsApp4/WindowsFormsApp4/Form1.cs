using DevExpress.Diagram.Core;
using DevExpress.XtraDiagram;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            RegisterStencil();
        }

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
    }
}
