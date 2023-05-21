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
    public partial class Form_Sub : Form
    {
        public Form_Sub()
        {
            InitializeComponent();
            Initialize();
        }

        public void Initialize() //변수 초기화
        {
            this.richTextBox_Number.Text = "0";
            this.richTextBox_Memory.Text = "";
            m_strNumber = "";
            m_nNumber = int.MinValue;
            m_nFnum = int.MinValue;
            m_nSnum = int.MinValue;
            m_nRnum = int.MinValue;
            m_nMode = 1;
        }

        Boolean m_bOperatorFlag = false; //연산자 사용 유무
        Boolean m_bEqualFlag = false; //등호연산자인지 일반 연산자로 계산했는지 구분
        Boolean m_bCompleteFlag = false; //계산 완료인지 아닌지 구분

        string m_strNumber; //천의 자리 표시를 위한 문자열
        string m_strHexNumber = string.Empty; //16진수 값 받아오기위한 문자열
        string m_strOperate = string.Empty; //계산 문자열 저장
        string m_strBitNum = string.Empty;

        int[] m_arrBit = new int[16];//bit키패트 처리할 배열

        int m_nMode=1; //int,Hex 모드관리(1:Hex,2:int)
        int m_nNumber = int.MinValue; //계산기 값 받아옴
        int m_nFnum = int.MinValue; //첫번째 피연산자
        int m_nSnum = int.MinValue; //두번째 피연산자
        int m_nRnum = int.MinValue; //결과값 저장
        int m_nSnumber = int.MinValue; //word계산



        private void button_FormMChange(object sender, EventArgs e)
        {
            this.Visible = false;
            Form_Main f_main = new Form_Main();
            f_main.Show();

        }

        private void Form_Sub_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button_BitClick(object sender, EventArgs e)
        {
 
            Button button = (Button)sender;

            if (button.Text == "0")
            {
                button.Text = "1";
                m_arrBit[Convert.ToInt32(button.Tag.ToString())] = 1;
            }
            else
            {
                button.Text = "0";
                m_arrBit[Convert.ToInt32(button.Tag.ToString())] = 0;
            }

            SetBit(m_arrBit);

        }

        private void SetBit(int[] arr)
        {
            String strBit1 = "";
            String strBit2 = "";
            String strBit3 = "";
            String strBit4 = "";

            String strHex = "";
            String strHex1 = "";
            String strHex2 = "";
            String strHex3 = "";
            String strHex4 = "";

            int nHex1 = 0;
            int nHex2 = 0;
            int nHex3 = 0;
            int nHex4 = 0;

            int nDec = int.MinValue;

            for (int nNum = arr.Length - 1; nNum >= arr.Length-4; nNum--)
            {
                strBit1 += arr[nNum].ToString();
            }
            for (int nNum = arr.Length - 5; nNum >= arr.Length - 8; nNum--)
            {
                strBit2 += arr[nNum].ToString();
            }
            for (int nNum = arr.Length - 9; nNum >= arr.Length - 12; nNum--)
            {
                strBit3 += arr[nNum].ToString();
            }
            for (int nNum = arr.Length - 13; nNum >= 0; nNum--)
            {
                strBit4 += arr[nNum].ToString();
            }

            nHex1 = Convert.ToInt32(strBit1, 2);
            nHex2 = Convert.ToInt32(strBit2, 2);
            nHex3 = Convert.ToInt32(strBit3, 2);
            nHex4 = Convert.ToInt32(strBit4, 2);

            strHex1 = Convert.ToString(nHex1, 16);
            strHex2 = Convert.ToString(nHex2, 16);
            strHex3 = Convert.ToString(nHex3, 16);
            strHex4 = Convert.ToString(nHex4, 16);

            if ((strHex1 == "0")&&(strHex2!="0"))
            {
                strHex =  strHex2 + strHex3 + strHex4;
            }
            else if((strHex1=="0")&&(strHex2=="0")&&(strHex3!="0"))
            {
                strHex =  strHex3 + strHex4;
            }else if ((strHex1 == "0") && (strHex2 == "0") && (strHex3 == "0")&&(strHex4!="0"))
            {
                strHex = strHex4;
            }else if((strHex1 == "0") && (strHex2 == "0") && (strHex3 == "0") && (strHex4 == "0"))
            {
                strHex = "0";
            }
            else
            {
                strHex = strHex1 + strHex2 + strHex3 + strHex4;
            }
            
            
            nDec = Convert.ToInt32(strHex,16);

            if (nDec > short.MaxValue)
            {
                nDec = nDec-(short.MaxValue-short.MinValue)-1;
            }

            
            this.label_Hex.Text = string.Format("{0:X}", strHex);

            if(nDec>=1000 || nDec <= -1000)
            {
                this.richTextBox_Number.Text = string.Format("{0:#,###}", nDec);
                this.label_Dec.Text = string.Format("{0:#,###}", nDec);

            }
            else
            {
                this.richTextBox_Number.Text = nDec.ToString();
                this.label_Dec.Text = nDec.ToString();

            }

        }

        private void getBit(string strNum)
        {
            int[] arrBit;

            string strHex;
            int nDec;

            switch (m_nMode)
            {
                case 1:
                    strNum

                    break;
                case 2:

                    break;
            }
        }

        private int Lsh_Opt(int nPri, int nSec)
        {
            int nResult=int.MinValue;

            return nResult;
        }
        private int sh_Opt(int nPri, int nSec)
        {
            int nResult = int.MinValue;

            return nResult;
        }

        private void button_HexClick(object sender, EventArgs e)
        {
            m_nMode = 1;
            button_A.Enabled = true;
            button_B.Enabled = true;
            button_C.Enabled = true;
            button_D.Enabled = true;
            button_E.Enabled = true;
            button_F.Enabled = true;

            button_A.ForeColor = Color.Black;
            button_B.ForeColor = Color.Black;
            button_C.ForeColor = Color.Black;
            button_D.ForeColor = Color.Black;
            button_E.ForeColor = Color.Black;
            button_F.ForeColor = Color.Black;

            this.richTextBox_Memory.Text = "";
            this.richTextBox_Number.Text = this.label_Hex.Text;
        }

        private void button_DecClick(object sender, EventArgs e)
        {
            m_nMode = 2;
            button_A.Enabled = false;
            button_B.Enabled = false;
            button_C.Enabled = false;
            button_D.Enabled = false;
            button_E.Enabled = false;
            button_F.Enabled = false;

            button_A.ForeColor = Color.LightGray;
            button_B.ForeColor = Color.LightGray;
            button_C.ForeColor = Color.LightGray;
            button_D.ForeColor = Color.LightGray;
            button_E.ForeColor = Color.LightGray;
            button_F.ForeColor = Color.LightGray;

            this.richTextBox_Memory.Text = "";
            this.richTextBox_Number.Text = this.label_Dec.Text;

        }

        private void Button_NumberClick(object sender, EventArgs e)
        {
            if (m_bCompleteFlag == true)
            {
                m_bCompleteFlag = false;
            }
            if (this.richTextBox_Number.Text == "0" || m_bOperatorFlag ||m_bCompleteFlag) this.richTextBox_Number.Clear();
            Button button = (Button)sender;
            m_bOperatorFlag = false;

            m_strNumber = this.richTextBox_Number.Text + button.Text;

            getBit(m_strNumber);

            switch (m_nMode)
            {
                case 1:
                    m_strHexNumber = string.Format("{0:X}", m_strNumber);
                
                    m_nNumber = Convert.ToInt32(m_strHexNumber,16);

                    m_nSnumber = Convert.ToInt32(m_nNumber);

                    this.richTextBox_Number.Text = m_strHexNumber.ToString();
                    this.label_Hex.Text = m_strHexNumber.ToString();

                    
                    if (m_nSnumber >= 1000 || m_nSnumber <= -1000)
                    {
                        this.label_Dec.Text = string.Format("{0:#,###}", m_nSnumber);
                    }
                    else
                    {
                        this.label_Dec.Text = m_nSnumber.ToString();
                    }
               
                    if (m_nNumber >= 1000 || m_nNumber <= -1000)
                    {
                        this.label_Dec.Text = string.Format("{0:#,###}", m_nNumber);
                    }
                    else
                    {
                        this.label_Dec.Text = m_nNumber.ToString();
                    }
                   
                    break;
                case 2:

                    m_nNumber = Convert.ToInt32(m_strNumber.Replace(",", ""));
                    
                    m_strHexNumber = string.Format("{0:X}", m_nNumber);
            
                    if (m_nNumber >= 1000 || m_nNumber <= -1000)
                    {
                        this.richTextBox_Number.Text = string.Format("{0:#,###}", m_nNumber);
                        this.label_Dec.Text = string.Format("{0:#,###}", m_nNumber);
                    }
                    else
                    {
                        this.richTextBox_Number.Text = m_nNumber.ToString();
                        this.label_Dec.Text = m_nNumber.ToString();
                    }                                  
                    this.label_Hex.Text = m_strHexNumber;
            
            
                    break;
                default:
                    break;
            
            }
      
        }

        public void button_OperateClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (m_nFnum != int.MinValue && m_nNumber != int.MinValue && m_strNumber != string.Empty && m_bCompleteFlag == false)
            {
                m_bEqualFlag = true;               
                button_Equal.PerformClick();
                this.m_strOperate = button.Text;
                this.richTextBox_Memory.Text = m_nFnum + button.Text;
                this.m_bOperatorFlag = true;

            }
            else
            {
                if (this.richTextBox_Number.Text == "0")
                {
                    this.richTextBox_Memory.Text = "0" + button.Text;
                    this.m_strOperate = button.Text;
                    m_nFnum = 0;
                    return;
                }
                if (this.m_bCompleteFlag == true)
                {
                    this.m_strOperate = button.Text;
                    if (m_nMode == 1)
                    {
                        this.richTextBox_Memory.Text = string.Format("{0:X}", m_nFnum) + button.Text;
                    }
                    else
                    {
                        this.richTextBox_Memory.Text = m_nFnum + button.Text;
                    }
                    this.m_bOperatorFlag = true;
                    return;
                }

                this.m_strOperate = button.Text;

                m_strNumber = string.Empty;
               
                m_nFnum = m_nNumber;

                if (m_nMode == 1)
                {
                    if (this.m_strOperate == "NOT")
                    {
                        this.richTextBox_Memory.Text = "NOT("+string.Format("{0:X}", m_nFnum) + ")";
                        button_Equal.PerformClick();
                    }
                    else
                    {
                        this.richTextBox_Memory.Text = string.Format("{0:X}", m_nFnum) + button.Text;
                    }
                    
                }
                else
                {
                    if (this.m_strOperate == "NOT")
                    {
                        m_bEqualFlag = true;
                        this.richTextBox_Memory.Text = "NOT(" + m_nFnum + ")";
                        button_Equal.PerformClick();
                    }
                    else
                    {
                        this.richTextBox_Memory.Text = m_nFnum + button.Text;
                    }
                    
                }

                this.m_bOperatorFlag = true;
            }
        }

        private void button_EqualClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (this.richTextBox_Memory.Text == string.Empty)
            {
                return;
            }

            if (m_nMode == 1)
            {
                m_nSnum = Convert.ToInt32(richTextBox_Number.Text,16);
            }
            else{
                m_nSnum = int.Parse(richTextBox_Number.Text.Replace(",",""));
            }
            

            if (m_bEqualFlag == false)
            {
                if (this.m_strOperate != "NOT")
                {
                    this.richTextBox_Memory.Text += m_nSnum + button.Text;
                }
            }
            else
            {
                if (this.m_strOperate != "NOT")
                {
                    this.richTextBox_Memory.Text += m_nSnum + m_strOperate;
                }
                
                m_bEqualFlag = false;
            }

            switch (this.m_strOperate)
            {
                case "+":
                    m_nRnum = m_nFnum + m_nSnum;

                    break;
                case "-":

                    m_nRnum = m_nFnum - m_nSnum;

                    break;
                case "X":
                    m_nRnum = m_nFnum * m_nSnum;
                    
                    break;
                case "/":

                    if (m_nSnum == 0)
                    {
                        this.richTextBox_Number.Text = "0으로나눌수없습니다."; return;
                    }
                    else
                    {
                        m_nRnum =m_nFnum / m_nSnum;
                    }
                   

                    break;

                case "%":
                    m_nRnum = m_nFnum % m_nSnum;
                    break;

                case "AND":
                    m_nRnum = m_nFnum & m_nSnum;
                    
                    break;

                case "OR":
                    m_nRnum = m_nFnum | m_nSnum;
                    break;

                case "NOT":
                    m_nRnum = ~m_nSnum;
                    break;
                case "NAND":
                    m_nRnum = ~(m_nFnum & m_nSnum);
                    break;

                case "NOR":
                    m_nRnum = ~(m_nFnum | m_nSnum);
                    break;
                case "XOR":
                    m_nRnum = m_nFnum ^ m_nSnum;
                    break;
           
                case "<<":                   
                    m_nRnum = m_nFnum << m_nSnum;
                    break;
                case ">>":
                    m_nRnum = m_nFnum >> m_nSnum;
                    break;
                default:
                    break;

            }

            printResult();
            m_nFnum = m_nRnum;
            m_nSnum = int.MinValue;
            m_strNumber = string.Empty;
            this.m_bCompleteFlag = true;
        }

        private void printResult()
        {
            if (m_nMode == 1)
            {
                this.richTextBox_Number.Text = m_nRnum.ToString("X");
                this.label_Hex.Text = m_nRnum.ToString("X");
                if (m_nRnum >= 1000)
                {
                    this.label_Dec.Text = string.Format("{0:#,###}", m_nRnum);
                }
                else
                {
                    this.label_Dec.Text = m_nRnum.ToString();
                }
            }
            else
            {
                if (m_nRnum >= 1000)
                {
                    this.richTextBox_Number.Text = string.Format("{0:#,###}", m_nRnum);
                    this.label_Dec.Text = string.Format("{0:#,###}", m_nRnum);
                    this.label_Hex.Text = m_nRnum.ToString("X");
                }
                else
                {
                    this.richTextBox_Number.Text = m_nRnum.ToString();
                    this.label_Dec.Text = string.Format("{0:#,###}", m_nRnum);
                    this.label_Hex.Text = m_nRnum.ToString("X");
                }
            }
        }

        private void button_BackClick(object sender, EventArgs e)
        {
            if (richTextBox_Memory.Text != "0" && m_strOperate != "=" && richTextBox_Number.Text.Length > 0)
            {
                richTextBox_Number.Text = richTextBox_Number.Text.Substring(0, richTextBox_Number.Text.Length - 1);
            }
        }

        private void Button_CClick(object sender, EventArgs e)
        {
            this.richTextBox_Number.Text = "0";
            this.richTextBox_Memory.Text = "";
            m_strNumber = "";
            m_nNumber = int.MinValue;
            m_nFnum = int.MinValue;
            m_nSnum = int.MinValue;
            m_nRnum = short.MinValue;
            m_strOperate = string.Empty;
            m_strHexNumber = string.Empty;
            this.m_bOperatorFlag = false;
            this.m_bCompleteFlag = false;
            this.label_Dec .Text= string.Empty;
            this.label_Hex.Text = string.Empty;
        }


        private void button_PnClick(object sender, EventArgs e)
        {
            if (m_nNumber == int.MinValue)
            {
                return;
            }
            else
            {
                m_nNumber = m_nNumber * (-1);

                if (m_nMode == 1)
                {

                }
                else
                {
                    if (m_nNumber >= 1000 || m_nNumber <= -1000)
                    {
                        this.richTextBox_Number.Text = string.Format("{0:#,###}", m_nNumber);
                    }
                    else
                    {
                        this.richTextBox_Number.Text = m_nNumber.ToString();
                    }
                }


            }
        }

        private void Form_Sub_Load(object sender, EventArgs e)
        {
            switch (m_nMode)
            {
                case 1:
                    button_A.Enabled = true;
                    button_B.Enabled = true;
                    button_C.Enabled = true;
                    button_D.Enabled = true;
                    button_E.Enabled = true;
                    button_F.Enabled = true;

                    button_A.ForeColor = Color.Black;
                    button_B.ForeColor = Color.Black;
                    button_C.ForeColor = Color.Black;
                    button_D.ForeColor = Color.Black;
                    button_E.ForeColor = Color.Black;
                    button_F.ForeColor = Color.Black;
                    break;
                case 2:
                    button_A.Enabled = false;
                    button_B.Enabled = false;
                    button_C.Enabled = false;
                    button_D.Enabled = false;
                    button_E.Enabled = false;
                    button_F.Enabled = false;

                    button_A.ForeColor = Color.LightGray;
                    button_B.ForeColor = Color.LightGray;
                    button_C.ForeColor = Color.LightGray;
                    button_D.ForeColor = Color.LightGray;
                    button_E.ForeColor = Color.LightGray;
                    button_F.ForeColor = Color.LightGray;
                    break;
                default:
                    break;

            }
        }

    }
}
