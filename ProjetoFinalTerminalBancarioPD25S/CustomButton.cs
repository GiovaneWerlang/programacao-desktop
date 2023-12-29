using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DESKTOP
{
    public partial class CustomButton : Control
    {
        public enum Shapetype
        {            
            Rectangle,//Se mudar a ordem, a cada build os botôes resetam para elipses
            Ellipse
        }

        #region Atributos

        private Shapetype _Shape;
        /// <summary>
        /// Modifica o formato do botão.
        /// </summary>
        [Description("Modifica o formato do botão."),
         Category("Appearance"),
         DefaultValue(typeof(Shapetype), "Rectangle"),
         Browsable(true)]
        public  Shapetype Shape
        {
            get { return _Shape; }
            set {
                if (value == _Shape) return;
                _Shape = value;
                Invalidate();
            }
        }

        private Color _BorderColor;
        /// <summary>
        /// Modifica a cor do botão.
        /// </summary>
        [Description("Cor da borda do botão."),
         Category("Appearance"),
         DefaultValue(typeof(Color), "Blue"),
         Browsable(true)]


        public Color BorderColor
        {
            get { return _BorderColor; }
            set
            {
                if (value == _BorderColor) return;
                _BorderColor = value;
                Invalidate();
            }
        }

        private bool _Hovering = false;
        /// <summary>
        ///  Mouse Hover
        /// </summary>

        public bool Hovering
        {
            get { return _Hovering; }
            set
            {
                if (value == _Hovering) return;
                _Hovering = value;
                Invalidate();
            }
        }

        private bool _MousePressed;
        /// <summary>
        /// Mouse Pressionado
        /// </summary>

        public bool MousePressed
        {
            get { return _MousePressed; }
            set
            {
                if (value == _MousePressed) return;
                _MousePressed = value;
                Invalidate();
            }
        }

        private Color _MouseHoverColor;
        /// <summary>
        /// Cor do Mouse Hover
        /// </summary>
        [Description("Cor de fundo quando mouse está sobre."),
         Category("Appearance"),
         DefaultValue(typeof(Color), "Grey"),
         Browsable(true)]

        public Color MouseHoverColor
        {
            get { return _MouseHoverColor; }
            set
            {
                if (value == _MouseHoverColor) return;
                _MouseHoverColor = value;
                Invalidate();
            }
        }


        #endregion


        #region Eventos

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Hovering = true;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            Hovering = false;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            MousePressed = true;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            MousePressed = false;
        }

        #endregion

        public CustomButton()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            var g = pe.Graphics;
            var r = ClientRectangle;

            g.FillRectangle(new SolidBrush(Parent.BackColor), r);

            r.Width -= 1;
            r.Height -= 1;

            Color fillColor;
            if (_MousePressed) fillColor = Color.Gray;
            else if (_Hovering) fillColor = _MouseHoverColor;
            else fillColor = Color.LightGray;

            if (Shape == Shapetype.Rectangle)
            {
                g.FillRectangle(new SolidBrush(fillColor), r);
                g.DrawRectangle(new Pen(BorderColor, 1.0f), r);
            }
            else
            {
                g.FillEllipse(new SolidBrush(fillColor), r);
                g.DrawEllipse(new Pen(BorderColor, 1.0f), r);
            }
            var f = new Font(base.Font.Name, (float)r.Height * 0.25f, FontStyle.Bold, GraphicsUnit.Pixel);
            var sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            g.DrawString(Text, f, new SolidBrush(ForeColor), new RectangleF((float)r.Left, (float)r.Top, (float)r.Width, (float)r.Height), sf);

        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
        }
    }
}
