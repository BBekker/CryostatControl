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
        }

        /// <summary>
        /// Override on form closing to prevent disposing of the form.
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
        /// The debug form load.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void DebugFormLoad(object sender, EventArgs e)
        {
            Console.SetOut(new ControlWriter(this.textBox1));
        }

        /// <summary>
        /// The control writer.
        /// </summary>
        private class ControlWriter : TextWriter
        {
            /// <summary>
            /// The buffer.
            /// </summary>
            private string buffer = string.Empty;

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
            /// Write a char to the textbox.
            /// </summary>
            /// <param name="value">
            /// The value.
            /// </param>
            public override void Write(char value)
            {
                this.buffer += value;
                if (value == '\n' || value == '\r')
                {
                    var buffercopy = this.buffer.Clone();
                    this.textbox.BeginInvoke(new Action(() => { this.textbox.Text = buffercopy + this.textbox.Text; }));
                    this.buffer = string.Empty;
                }
            }

            /// <summary>
            ///  Write a string to the textbox
            /// </summary>
            /// <param name="value">
            /// The value.
            /// </param>
            public override void Write(string value)
            {
                this.textbox.BeginInvoke(new Action(() => { this.textbox.Text = value + this.textbox.Text; }));
            }
        }
    }
}