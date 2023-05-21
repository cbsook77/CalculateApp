namespace CalculateApp
{
    partial class Form_Main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBox_Number = new System.Windows.Forms.RichTextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button_CE = new System.Windows.Forms.Button();
            this.button_C = new System.Windows.Forms.Button();
            this.button_Erase = new System.Windows.Forms.Button();
            this.button_Divide = new System.Windows.Forms.Button();
            this.button_Seven = new System.Windows.Forms.Button();
            this.button_Eight = new System.Windows.Forms.Button();
            this.button_Nine = new System.Windows.Forms.Button();
            this.button_Mutiple = new System.Windows.Forms.Button();
            this.button_Four = new System.Windows.Forms.Button();
            this.button_Five = new System.Windows.Forms.Button();
            this.button_Six = new System.Windows.Forms.Button();
            this.button_Minus = new System.Windows.Forms.Button();
            this.button_One = new System.Windows.Forms.Button();
            this.button_Two = new System.Windows.Forms.Button();
            this.button_Three = new System.Windows.Forms.Button();
            this.button_plus = new System.Windows.Forms.Button();
            this.button_Pn = new System.Windows.Forms.Button();
            this.button_Zero = new System.Windows.Forms.Button();
            this.button_Decpoint = new System.Windows.Forms.Button();
            this.button_Equal = new System.Windows.Forms.Button();
            this.richTextBox_Memory = new System.Windows.Forms.RichTextBox();
            this.button_FormChange = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox_Number
            // 
            this.richTextBox_Number.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox_Number.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox_Number.Font = new System.Drawing.Font("굴림", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.richTextBox_Number.Location = new System.Drawing.Point(13, 128);
            this.richTextBox_Number.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBox_Number.Multiline = false;
            this.richTextBox_Number.Name = "richTextBox_Number";
            this.richTextBox_Number.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.richTextBox_Number.Size = new System.Drawing.Size(512, 70);
            this.richTextBox_Number.TabIndex = 2;
            this.richTextBox_Number.TabStop = false;
            this.richTextBox_Number.Text = "";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.button_CE);
            this.flowLayoutPanel1.Controls.Add(this.button_C);
            this.flowLayoutPanel1.Controls.Add(this.button_Erase);
            this.flowLayoutPanel1.Controls.Add(this.button_Divide);
            this.flowLayoutPanel1.Controls.Add(this.button_Seven);
            this.flowLayoutPanel1.Controls.Add(this.button_Eight);
            this.flowLayoutPanel1.Controls.Add(this.button_Nine);
            this.flowLayoutPanel1.Controls.Add(this.button_Mutiple);
            this.flowLayoutPanel1.Controls.Add(this.button_Four);
            this.flowLayoutPanel1.Controls.Add(this.button_Five);
            this.flowLayoutPanel1.Controls.Add(this.button_Six);
            this.flowLayoutPanel1.Controls.Add(this.button_Minus);
            this.flowLayoutPanel1.Controls.Add(this.button_One);
            this.flowLayoutPanel1.Controls.Add(this.button_Two);
            this.flowLayoutPanel1.Controls.Add(this.button_Three);
            this.flowLayoutPanel1.Controls.Add(this.button_plus);
            this.flowLayoutPanel1.Controls.Add(this.button_Pn);
            this.flowLayoutPanel1.Controls.Add(this.button_Zero);
            this.flowLayoutPanel1.Controls.Add(this.button_Decpoint);
            this.flowLayoutPanel1.Controls.Add(this.button_Equal);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(17, 357);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(519, 431);
            this.flowLayoutPanel1.TabIndex = 11;
            // 
            // button_CE
            // 
            this.button_CE.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_CE.Font = new System.Drawing.Font("굴림", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_CE.Location = new System.Drawing.Point(4, 4);
            this.button_CE.Margin = new System.Windows.Forms.Padding(4);
            this.button_CE.Name = "button_CE";
            this.button_CE.Size = new System.Drawing.Size(120, 75);
            this.button_CE.TabIndex = 0;
            this.button_CE.Text = "CE";
            this.button_CE.UseVisualStyleBackColor = false;
            this.button_CE.Click += new System.EventHandler(this.button_CEClick);
            // 
            // button_C
            // 
            this.button_C.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_C.Font = new System.Drawing.Font("굴림", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_C.Location = new System.Drawing.Point(132, 4);
            this.button_C.Margin = new System.Windows.Forms.Padding(4);
            this.button_C.Name = "button_C";
            this.button_C.Size = new System.Drawing.Size(120, 75);
            this.button_C.TabIndex = 1;
            this.button_C.Text = "C";
            this.button_C.UseVisualStyleBackColor = false;
            this.button_C.Click += new System.EventHandler(this.button_CClick);
            // 
            // button_Erase
            // 
            this.button_Erase.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_Erase.Font = new System.Drawing.Font("굴림", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_Erase.Image = global::CalculateApp.Properties.Resources.사진;
            this.button_Erase.Location = new System.Drawing.Point(260, 4);
            this.button_Erase.Margin = new System.Windows.Forms.Padding(4);
            this.button_Erase.Name = "button_Erase";
            this.button_Erase.Size = new System.Drawing.Size(120, 75);
            this.button_Erase.TabIndex = 2;
            this.button_Erase.UseVisualStyleBackColor = false;
            this.button_Erase.Click += new System.EventHandler(this.button_Erase_Click);
            // 
            // button_Divide
            // 
            this.button_Divide.Font = new System.Drawing.Font("굴림", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_Divide.Location = new System.Drawing.Point(388, 4);
            this.button_Divide.Margin = new System.Windows.Forms.Padding(4);
            this.button_Divide.Name = "button_Divide";
            this.button_Divide.Size = new System.Drawing.Size(120, 75);
            this.button_Divide.TabIndex = 3;
            this.button_Divide.Text = "/";
            this.button_Divide.UseVisualStyleBackColor = true;
            this.button_Divide.Click += new System.EventHandler(this.button_Operate_Click);
            // 
            // button_Seven
            // 
            this.button_Seven.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_Seven.Font = new System.Drawing.Font("굴림", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_Seven.Location = new System.Drawing.Point(4, 87);
            this.button_Seven.Margin = new System.Windows.Forms.Padding(4);
            this.button_Seven.Name = "button_Seven";
            this.button_Seven.Size = new System.Drawing.Size(120, 75);
            this.button_Seven.TabIndex = 4;
            this.button_Seven.Text = "7";
            this.button_Seven.UseVisualStyleBackColor = false;
            this.button_Seven.Click += new System.EventHandler(this.button_NumClick);
            // 
            // button_Eight
            // 
            this.button_Eight.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_Eight.Font = new System.Drawing.Font("굴림", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_Eight.Location = new System.Drawing.Point(132, 87);
            this.button_Eight.Margin = new System.Windows.Forms.Padding(4);
            this.button_Eight.Name = "button_Eight";
            this.button_Eight.Size = new System.Drawing.Size(120, 75);
            this.button_Eight.TabIndex = 5;
            this.button_Eight.Text = "8";
            this.button_Eight.UseVisualStyleBackColor = false;
            this.button_Eight.Click += new System.EventHandler(this.button_NumClick);
            // 
            // button_Nine
            // 
            this.button_Nine.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_Nine.Font = new System.Drawing.Font("굴림", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_Nine.Location = new System.Drawing.Point(260, 87);
            this.button_Nine.Margin = new System.Windows.Forms.Padding(4);
            this.button_Nine.Name = "button_Nine";
            this.button_Nine.Size = new System.Drawing.Size(120, 75);
            this.button_Nine.TabIndex = 6;
            this.button_Nine.Text = "9";
            this.button_Nine.UseVisualStyleBackColor = false;
            this.button_Nine.Click += new System.EventHandler(this.button_NumClick);
            // 
            // button_Mutiple
            // 
            this.button_Mutiple.Font = new System.Drawing.Font("굴림", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_Mutiple.Location = new System.Drawing.Point(388, 87);
            this.button_Mutiple.Margin = new System.Windows.Forms.Padding(4);
            this.button_Mutiple.Name = "button_Mutiple";
            this.button_Mutiple.Size = new System.Drawing.Size(120, 75);
            this.button_Mutiple.TabIndex = 7;
            this.button_Mutiple.Text = "X";
            this.button_Mutiple.UseVisualStyleBackColor = true;
            this.button_Mutiple.Click += new System.EventHandler(this.button_Operate_Click);
            // 
            // button_Four
            // 
            this.button_Four.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_Four.Font = new System.Drawing.Font("굴림", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_Four.Location = new System.Drawing.Point(4, 170);
            this.button_Four.Margin = new System.Windows.Forms.Padding(4);
            this.button_Four.Name = "button_Four";
            this.button_Four.Size = new System.Drawing.Size(120, 75);
            this.button_Four.TabIndex = 8;
            this.button_Four.Text = "4";
            this.button_Four.UseVisualStyleBackColor = false;
            this.button_Four.Click += new System.EventHandler(this.button_NumClick);
            // 
            // button_Five
            // 
            this.button_Five.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_Five.Font = new System.Drawing.Font("굴림", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_Five.Location = new System.Drawing.Point(132, 170);
            this.button_Five.Margin = new System.Windows.Forms.Padding(4);
            this.button_Five.Name = "button_Five";
            this.button_Five.Size = new System.Drawing.Size(120, 75);
            this.button_Five.TabIndex = 9;
            this.button_Five.Text = "5";
            this.button_Five.UseVisualStyleBackColor = false;
            this.button_Five.Click += new System.EventHandler(this.button_NumClick);
            // 
            // button_Six
            // 
            this.button_Six.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_Six.Font = new System.Drawing.Font("굴림", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_Six.Location = new System.Drawing.Point(260, 170);
            this.button_Six.Margin = new System.Windows.Forms.Padding(4);
            this.button_Six.Name = "button_Six";
            this.button_Six.Size = new System.Drawing.Size(120, 75);
            this.button_Six.TabIndex = 10;
            this.button_Six.Text = "6";
            this.button_Six.UseVisualStyleBackColor = false;
            this.button_Six.Click += new System.EventHandler(this.button_NumClick);
            // 
            // button_Minus
            // 
            this.button_Minus.Font = new System.Drawing.Font("굴림", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_Minus.Location = new System.Drawing.Point(388, 170);
            this.button_Minus.Margin = new System.Windows.Forms.Padding(4);
            this.button_Minus.Name = "button_Minus";
            this.button_Minus.Size = new System.Drawing.Size(120, 75);
            this.button_Minus.TabIndex = 11;
            this.button_Minus.Text = "-";
            this.button_Minus.UseVisualStyleBackColor = true;
            this.button_Minus.Click += new System.EventHandler(this.button_Operate_Click);
            // 
            // button_One
            // 
            this.button_One.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_One.Font = new System.Drawing.Font("굴림", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_One.Location = new System.Drawing.Point(4, 253);
            this.button_One.Margin = new System.Windows.Forms.Padding(4);
            this.button_One.Name = "button_One";
            this.button_One.Size = new System.Drawing.Size(120, 75);
            this.button_One.TabIndex = 12;
            this.button_One.Text = "1";
            this.button_One.UseVisualStyleBackColor = false;
            this.button_One.Click += new System.EventHandler(this.button_NumClick);
            // 
            // button_Two
            // 
            this.button_Two.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_Two.Font = new System.Drawing.Font("굴림", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_Two.Location = new System.Drawing.Point(132, 253);
            this.button_Two.Margin = new System.Windows.Forms.Padding(4);
            this.button_Two.Name = "button_Two";
            this.button_Two.Size = new System.Drawing.Size(120, 75);
            this.button_Two.TabIndex = 13;
            this.button_Two.Text = "2";
            this.button_Two.UseVisualStyleBackColor = false;
            this.button_Two.Click += new System.EventHandler(this.button_NumClick);
            // 
            // button_Three
            // 
            this.button_Three.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_Three.Font = new System.Drawing.Font("굴림", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_Three.Location = new System.Drawing.Point(260, 253);
            this.button_Three.Margin = new System.Windows.Forms.Padding(4);
            this.button_Three.Name = "button_Three";
            this.button_Three.Size = new System.Drawing.Size(120, 75);
            this.button_Three.TabIndex = 14;
            this.button_Three.Text = "3";
            this.button_Three.UseVisualStyleBackColor = false;
            this.button_Three.Click += new System.EventHandler(this.button_NumClick);
            // 
            // button_plus
            // 
            this.button_plus.Font = new System.Drawing.Font("굴림", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_plus.Location = new System.Drawing.Point(388, 253);
            this.button_plus.Margin = new System.Windows.Forms.Padding(4);
            this.button_plus.Name = "button_plus";
            this.button_plus.Size = new System.Drawing.Size(120, 75);
            this.button_plus.TabIndex = 15;
            this.button_plus.Text = "+";
            this.button_plus.UseVisualStyleBackColor = true;
            this.button_plus.Click += new System.EventHandler(this.button_Operate_Click);
            // 
            // button_Pn
            // 
            this.button_Pn.Font = new System.Drawing.Font("굴림", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_Pn.Location = new System.Drawing.Point(4, 336);
            this.button_Pn.Margin = new System.Windows.Forms.Padding(4);
            this.button_Pn.Name = "button_Pn";
            this.button_Pn.Size = new System.Drawing.Size(120, 75);
            this.button_Pn.TabIndex = 16;
            this.button_Pn.Text = "+/-";
            this.button_Pn.UseVisualStyleBackColor = true;
            this.button_Pn.Click += new System.EventHandler(this.button_Pn_Click);
            // 
            // button_Zero
            // 
            this.button_Zero.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_Zero.Font = new System.Drawing.Font("굴림", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_Zero.Location = new System.Drawing.Point(132, 336);
            this.button_Zero.Margin = new System.Windows.Forms.Padding(4);
            this.button_Zero.Name = "button_Zero";
            this.button_Zero.Size = new System.Drawing.Size(120, 75);
            this.button_Zero.TabIndex = 17;
            this.button_Zero.Text = "0";
            this.button_Zero.UseVisualStyleBackColor = false;
            this.button_Zero.Click += new System.EventHandler(this.button_NumClick);
            // 
            // button_Decpoint
            // 
            this.button_Decpoint.Font = new System.Drawing.Font("굴림", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_Decpoint.Location = new System.Drawing.Point(260, 336);
            this.button_Decpoint.Margin = new System.Windows.Forms.Padding(4);
            this.button_Decpoint.Name = "button_Decpoint";
            this.button_Decpoint.Size = new System.Drawing.Size(120, 75);
            this.button_Decpoint.TabIndex = 18;
            this.button_Decpoint.Text = ".";
            this.button_Decpoint.UseVisualStyleBackColor = true;
            this.button_Decpoint.Click += new System.EventHandler(this.button_Decpoint_Click);
            // 
            // button_Equal
            // 
            this.button_Equal.Font = new System.Drawing.Font("굴림", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_Equal.Location = new System.Drawing.Point(388, 336);
            this.button_Equal.Margin = new System.Windows.Forms.Padding(4);
            this.button_Equal.Name = "button_Equal";
            this.button_Equal.Size = new System.Drawing.Size(120, 75);
            this.button_Equal.TabIndex = 19;
            this.button_Equal.Text = "=";
            this.button_Equal.UseVisualStyleBackColor = true;
            this.button_Equal.Click += new System.EventHandler(this.button_Equal_Click);
            // 
            // richTextBox_Memory
            // 
            this.richTextBox_Memory.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox_Memory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox_Memory.Font = new System.Drawing.Font("굴림", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.richTextBox_Memory.Location = new System.Drawing.Point(13, 58);
            this.richTextBox_Memory.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBox_Memory.Multiline = false;
            this.richTextBox_Memory.Name = "richTextBox_Memory";
            this.richTextBox_Memory.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.richTextBox_Memory.Size = new System.Drawing.Size(512, 52);
            this.richTextBox_Memory.TabIndex = 17;
            this.richTextBox_Memory.TabStop = false;
            this.richTextBox_Memory.Text = "";
            // 
            // button_FormChange
            // 
            this.button_FormChange.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_FormChange.Location = new System.Drawing.Point(3, 1);
            this.button_FormChange.Name = "button_FormChange";
            this.button_FormChange.Size = new System.Drawing.Size(145, 50);
            this.button_FormChange.TabIndex = 18;
            this.button_FormChange.Text = "표준";
            this.button_FormChange.UseVisualStyleBackColor = true;
            this.button_FormChange.Click += new System.EventHandler(this.button_ChangeClick);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 801);
            this.Controls.Add(this.button_FormChange);
            this.Controls.Add(this.richTextBox_Memory);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.richTextBox_Number);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(571, 857);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(571, 857);
            this.Name = "Form_Main";
            this.ShowIcon = false;
            this.Text = "계산기";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Main_FormClosing);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox richTextBox_Number;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button button_CE;
        private System.Windows.Forms.Button button_C;
        private System.Windows.Forms.Button button_Erase;
        private System.Windows.Forms.Button button_Divide;
        private System.Windows.Forms.Button button_Seven;
        private System.Windows.Forms.Button button_Eight;
        private System.Windows.Forms.Button button_Nine;
        private System.Windows.Forms.Button button_Mutiple;
        private System.Windows.Forms.Button button_Four;
        private System.Windows.Forms.Button button_Five;
        private System.Windows.Forms.Button button_Six;
        private System.Windows.Forms.Button button_Minus;
        private System.Windows.Forms.Button button_One;
        private System.Windows.Forms.Button button_Two;
        private System.Windows.Forms.Button button_Three;
        private System.Windows.Forms.Button button_plus;
        private System.Windows.Forms.Button button_Pn;
        private System.Windows.Forms.Button button_Zero;
        private System.Windows.Forms.Button button_Decpoint;
        private System.Windows.Forms.Button button_Equal;
        private System.Windows.Forms.RichTextBox richTextBox_Memory;
        private System.Windows.Forms.Button button_FormChange;
    }
}

