using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsSignIn {
    public partial class FormLogin : Form {
        public FormLogin() {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {

        }

        private void FormLogin_Load(object sender, EventArgs e) {

        }

        private void SignInButton_Click(object sender, EventArgs e) {
            // textbox id. password 값을 가져오기
            string userID = id.Text;
            string userPW = password.Text;
            // hong / 1234 이면 로그인 성공 아니면 로그인 실패
            if(userID.Equals("hong") && userPW.Equals("1234")) {
                // 로그인 성공
                MessageBox.Show("로그인 성공", "로그인");
            } else {
                // 로그인 실패
                MessageBox.Show("로그인 실패", "로그인");
            }
        }
    }
}
