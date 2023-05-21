using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculateApp
{
    public partial class Form_Main : Form
    {
        //int m_nNumber;
        //string m_strNumber;
        //int[] m_arrNumber;
        //List<int> m_lstNumber;
        //List<string> m_lstNumber2;
        //bool m_bNumber;



        Boolean m_bOperatorFlag = false; //연산자 사용 유무
        Boolean m_bEqualFlag = false; //등호연산자인지 일반 연산자로 계산했는지 구분
        Boolean m_bCompleteFlag = false; //계산 완료인지 아닌지 구분

        string m_strNumber; //천의 자리 표시를 위한 문자열
        decimal m_dNumber=decimal.MinValue; //계산기 값 받아옴
        decimal m_dFnum= decimal.MinValue; //첫번째 피연산자
        decimal m_dSnum= decimal.MinValue; //두번째 피연산자
        decimal m_dRnum= decimal.MinValue; //결과값 저장
        string m_strOperate=string.Empty; //계산 문자열 저장

        public Form_Main()
        {
            //List<string> lstNumber;
            InitializeComponent();  
            Initialize();
        }



        public void Initialize() //변수 초기화
        {
            this.richTextBox_Number.Text = "0";
            this.richTextBox_Memory.Text = "";
            m_strNumber = "";
            m_dNumber = decimal.MinValue;
            m_dFnum = decimal.MinValue;
            m_dSnum = decimal.MinValue;
            m_dRnum = decimal.MinValue;
        }
     

        private void button_Erase_Click(object sender, EventArgs e) //뒤로가기 버튼 클릭시 한자리씩 지움
        {
            if(richTextBox_Memory.Text!="0" && m_strOperate !="=" && richTextBox_Number.Text.Length>0)
            {                
                richTextBox_Number.Text = richTextBox_Number.Text.Substring(0, richTextBox_Number.Text.Length - 1);
            }
        }

       

        private void button_Pn_Click(object sender, EventArgs e) // 양수 음수 변환 양수 일대는 음수로 음수일때는 양수로 변환
        {
            if (m_dNumber == decimal.MinValue)
            {
                return;
            }
            else
            {
                m_dNumber = m_dNumber * (-1);

                if (m_dNumber >= 1000 || m_dNumber <= -1000)
                {
                    this.richTextBox_Number.Text = string.Format("{0:#,###}", m_dNumber);
                }
                else
                {
                    this.richTextBox_Number.Text = m_dNumber.ToString();
                }

            }
        }

        private void button_Decpoint_Click(object sender, EventArgs e) //소숫점이 없을시 소숫점 표시
        {
            Button button = (Button)sender;

            if (!this.richTextBox_Number.Text.Contains("."))
            {
                this.richTextBox_Number.Text += button.Text;
                
            }
        }

        private void button_Equal_Click(object sender, EventArgs e) //연산자 계산 피연산자가 있는 상태에서 연산자를 누르거나 등호 누를시 실행
        {
            Button button = (Button)sender;

            if (this.richTextBox_Memory.Text == string.Empty)
            {
                return;
            }

            m_dSnum = decimal.Parse(richTextBox_Number.Text);

            if (m_bEqualFlag == false)
            {
                this.richTextBox_Memory.Text += m_dSnum + button.Text;
            }
            else
            {
                this.richTextBox_Memory.Text += m_dSnum + m_strOperate;
                m_bEqualFlag = false;
            }

            switch (this.m_strOperate)
            {
                case "+":                  
                    m_dRnum = m_dFnum + m_dSnum;
                    if (m_dRnum >= 1000)
                    {
                        this.richTextBox_Number.Text = string.Format("{0:#,###}", m_dRnum);
                    }
                    else
                    {
                        this.richTextBox_Number.Text = m_dRnum.ToString();
                    }
                    break;    
                case "-":
                    
                    m_dRnum = m_dFnum - m_dSnum;
                    if (m_dRnum >= 1000)
                    {
                        this.richTextBox_Number.Text = string.Format("{0:#,###}", m_dRnum);
                    }
                    else
                    {
                        this.richTextBox_Number.Text = m_dRnum.ToString();
                    }
                    break;
                case "X":
                    
                    m_dRnum = m_dFnum * m_dSnum;
                    if (m_dRnum >= 1000)
                    {
                        this.richTextBox_Number.Text = string.Format("{0:#,###}", m_dRnum);
                    }
                    else
                    {
                        this.richTextBox_Number.Text = m_dRnum.ToString();
                    }
                    break;
                case "/":
                   
                    if (m_dSnum==0)
                    {
                        this.richTextBox_Number.Text = "0으로나눌수없습니다."; return;
                    }
                    else
                    {
                        m_dRnum = m_dFnum / m_dSnum;
                    }
                       
                    if (m_dRnum >= 1000)
                    {
                        this.richTextBox_Number.Text = string.Format("{0:#,###}", m_dRnum);
                    }
                    else
                    {
                        this.richTextBox_Number.Text = m_dRnum.ToString();
                    }
                    break;
                default:
                    break;

            }            
            m_dFnum = m_dRnum;
            m_dSnum = decimal.MinValue;
            m_strNumber = string.Empty;
            this.m_bCompleteFlag = true;
            
        }

        private void button_CClick(object sender, EventArgs e) //전체 정보 초기화
        {
            this.richTextBox_Number.Text = "0";
            this.richTextBox_Memory.Text = "";
            m_strNumber = "";
            m_dNumber = decimal.MinValue;
            m_dFnum = decimal.MinValue;
            m_dSnum = decimal.MinValue;
            m_dRnum = decimal.MinValue;
            m_strOperate = string.Empty;
            this.m_bOperatorFlag = false;
            this.m_bCompleteFlag = false;
        }

        private void button_CEClick(object sender, EventArgs e) //현재 숫자 입력된 정보 초기화
        {
            this.richTextBox_Number.Text = "0";
            m_strNumber = "";
            m_dNumber = decimal.MinValue;
            m_strOperate = string.Empty;
            this.m_bOperatorFlag = false;
            this.m_bCompleteFlag = false;
        }

        private void button_Operate_Click(object sender, EventArgs e) //연산자 버튼 누를시 실행
        {
            Button button = (Button)sender;

            if (m_dFnum != decimal.MinValue &&m_dNumber!=decimal.MinValue&& m_strNumber != string.Empty  && m_bCompleteFlag == false)
            {           
                m_bEqualFlag = true;
                button_Equal.PerformClick();
                this.m_strOperate = button.Text;
                this.richTextBox_Memory.Text = m_dFnum + button.Text;          
                this.m_bOperatorFlag = true;
            }
            else
            {
                if (this.richTextBox_Number.Text == "0")
                {
                    this.richTextBox_Memory.Text = "0" + button.Text;
                    this.m_strOperate = button.Text;
                    m_dFnum = 0;
                    return;
                }
                if (this.m_bCompleteFlag == true)
                {
                    this.m_strOperate = button.Text;
                    this.richTextBox_Memory.Text = m_dFnum + button.Text;
                    this.m_bOperatorFlag = true;
                    return;
                }
                this.m_strOperate = button.Text;
  
                m_strNumber = string.Empty;
                m_dFnum = m_dNumber;              
                this.richTextBox_Memory.Text = m_dFnum + button.Text;
                this.m_bOperatorFlag = true;              
            }
        }

        private void button_NumClick(object sender, EventArgs e) //숫자 입력
        {
            if (m_bCompleteFlag == true)
            {
                m_bCompleteFlag = false;
            }
            if (this.richTextBox_Number.Text == "0" || m_bOperatorFlag) this.richTextBox_Number.Clear();
            Button button = (Button)sender;
            m_bOperatorFlag = false;

            m_strNumber = this.richTextBox_Number.Text+button.Text;
            m_dNumber = decimal.Parse(m_strNumber);

            if (m_dNumber >= 1000)
            {
              this.richTextBox_Number.Text = string.Format("{0:#,###}", m_dNumber);
            }
            else
            {
              this.richTextBox_Number.Text = m_dNumber.ToString();
            }
        }

        private void button_ChangeClick(object sender, EventArgs e)
        {
            this.Visible = false ;
            Form_Sub Subform = new Form_Sub();
            Subform.Show();
            
        }

        private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
