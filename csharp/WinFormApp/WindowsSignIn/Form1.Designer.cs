namespace WindowsSignIn {
    partial class FormLogin {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.id = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.SignInButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("D2Coding ligature", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(157, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "로그인 창";
            this.label1.Click += new System.EventHandler(this.SignInButton_Click);
            // 
            // id
            // 
            this.id.Font = new System.Drawing.Font("D2Coding ligature", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.id.Location = new System.Drawing.Point(26, 77);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(362, 23);
            this.id.TabIndex = 1;
            this.id.Text = "ID";
            this.id.Click += new System.EventHandler(this.SignInButton_Click);
            this.id.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // password
            // 
            this.password.Font = new System.Drawing.Font("D2Coding ligature", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.password.Location = new System.Drawing.Point(26, 104);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(362, 23);
            this.password.TabIndex = 2;
            this.password.Text = "Password";
            this.password.Click += new System.EventHandler(this.SignInButton_Click);
            // 
            // SignInButton
            // 
            this.SignInButton.Font = new System.Drawing.Font("D2Coding ligature", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.SignInButton.Location = new System.Drawing.Point(161, 156);
            this.SignInButton.Name = "SignInButton";
            this.SignInButton.Size = new System.Drawing.Size(92, 34);
            this.SignInButton.TabIndex = 3;
            this.SignInButton.Text = "로그인";
            this.SignInButton.UseVisualStyleBackColor = true;
            this.SignInButton.Click += new System.EventHandler(this.SignInButton_Click);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 275);
            this.Controls.Add(this.SignInButton);
            this.Controls.Add(this.password);
            this.Controls.Add(this.id);
            this.Controls.Add(this.label1);
            this.Name = "FormLogin";
            this.Text = "로그인 화면";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox id;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Button SignInButton;
    }
}

