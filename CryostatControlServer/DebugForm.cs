// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DebugForm.cs" company="SRON">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the DebugForm type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlServer
{
    using System;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    /// The debug form.
    /// </summary>
    public partial class DebugForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebugForm"/> class.
        /// </summary>
        public DebugForm()
        {
            this.InitializeComponent();
            Console.SetOut(new ControlWriter(this.textBox1));
        }

        /// <summary>
        /// The on form closing.
        /// </summary>
        /// <param name="e">
        /// The e.
        /// </param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown)
            {
                return;
            }

            this.Hide();
            e.Cancel = true;
        }

        /// <summary>
        /// The control writer.
        /// </summary>
        public class ControlWriter : TextWriter
        {
            /// <summary>
            /// The textbox.
            /// </summary>
            private Control textbox;

            /// <summary>
            /// Initializes a new instance of the <see cref="ControlWriter"/> class.
            /// </summary>
            /// <param name="textbox">
            /// The textbox.
            /// </param>
            public ControlWriter(Control textbox)
            {
                this.textbox = textbox;
            }

            /// <summary>
            /// Gets the encoding.
            /// </summary>
            public override Encoding Encoding
            {
                get
                {
                    return Encoding.ASCII;
                }
            }

            /// <summary>
            /// The write.
            /// </summary>
            /// <param name="value">
            /// The value.
            /// </param>
            public override void Write(char value)
            {
                this.textbox.Text += value;
            }

            /// <summary>
            /// The write.
            /// </summary>
            /// <param name="value">
            /// The value.
            /// </param>
            public override void Write(string value)
            {
                this.textbox.Text += value;
            }
        }
    }
}