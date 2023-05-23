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
        public enum eTYPE
        {
            HEX = 0,
            DECIMAL = 1,
        }

        public enum eShift
        {
            LOGICAL=0,
            ARITHMETIC=1,
        }

        eTYPE m_etype = eTYPE.HEX;
        eShift m_eshift = eShift.LOGICAL;

        Boolean m_bOperatorFlag = false; //연산자 사용 유무
        Boolean m_bEqualFlag = false; //등호연산자인지 일반 연산자로 계산했는지 구분
        Boolean m_bCompleteFlag = false; //계산 완료인지 아닌지 구분

        string m_strNumber; //천의 자리 표시를 위한 문자열
        string m_strHexNumber = string.Empty; //16진수 값 받아오기위한 문자열
        string m_strOperate = string.Empty; //계산 문자열 저장
        string m_strBitNum = string.Empty;

        int[] m_arrBit = new int[16];//bit키패트 처리할 배열

        //int m_nMode = (int)eTYPE.HEX; //Hex, DEC 모드관리(0:HEX,1:DEC)
        //int m_nSmode = 1; //shitf 모드관리(1: 논리 쉬프트,2: 산술 쉬프트)
        int m_nNumber = int.MinValue; //계산기 값 받아옴
        int m_nFnum = int.MinValue; //첫번째 피연산자
        int m_nSnum = int.MinValue; //두번째 피연산자
        int m_nRnum = int.MinValue; //결과값 저장
        int m_nSnumber = int.MinValue; //word계산

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
            m_etype = eTYPE.HEX;
            m_eshift = eShift.LOGICAL;
        }

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

        private void button_BitClick(object sender, EventArgs e) //비트키패드 입력
        {
            Button button = (Button)sender;

            Set_Bit_FromButton();

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

        private void Set_Bit_FromButton() //4byte 배열 처리할 함수
        {
            m_arrBit[0] = Convert.ToInt32(button_BitZero.Text);
            m_arrBit[1] = Convert.ToInt32(button_BitOne.Text);
            m_arrBit[2] = Convert.ToInt32(button_BitTwo.Text);
            m_arrBit[3] = Convert.ToInt32(button_BitThree.Text);
            m_arrBit[4] = Convert.ToInt32(button_BitFour.Text);
            m_arrBit[5] = Convert.ToInt32(button_BitFive.Text);
            m_arrBit[6] = Convert.ToInt32(button_BitSix.Text);
            m_arrBit[7] = Convert.ToInt32(button_BitSeven.Text);
            m_arrBit[8] = Convert.ToInt32(button_BitEight.Text);
            m_arrBit[9] = Convert.ToInt32(button_BitNine.Text);
            m_arrBit[10] = Convert.ToInt32(button_BitTen.Text);
            m_arrBit[11] = Convert.ToInt32(button_BitEleven.Text);
            m_arrBit[12] = Convert.ToInt32(button_BitTwelve.Text);
            m_arrBit[13] = Convert.ToInt32(button_BitThirteen.Text);
            m_arrBit[14] = Convert.ToInt32(button_BitFourteen.Text);
            m_arrBit[15] = Convert.ToInt32(button_BitFifteen.Text);
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

            this.label_Hex.Text = strHex;

            if (m_etype == eTYPE.HEX)
            {
                this.richTextBox_Number.Text = this.label_Hex.Text;
                m_nNumber = Convert.ToInt32(this.label_Hex.Text, 16);

                if(nDec>=1000 || nDec <= -1000)
                {
                    this.label_Dec.Text = string.Format("{0:#,###}", nDec);
                }
                else
                {
                    this.label_Dec.Text = nDec.ToString();
                }                
            }
            else
            {                
                
                if (nDec >= 1000 || nDec <= -1000)
                {
                    this.label_Dec.Text = string.Format("{0:#,###}", nDec);
                }
                else
                {
                    this.label_Dec.Text = nDec.ToString();
                }
                
                this.richTextBox_Number.Text = this.label_Dec.Text;
                m_nNumber = nDec;
            }
        }

        private void SetByte(int nNum,String strHex) //byte별 Hex값 Button에 세팅
        {
            switch (nNum)
            {
                case 1:
                    button_BitZero.Text = Convert.ToString(strHex[3]);
                    button_BitOne.Text = Convert.ToString(strHex[2]);
                    button_BitTwo.Text = Convert.ToString(strHex[1]);
                    button_BitThree.Text = Convert.ToString(strHex[0]);
                    break;
                case 2:
                    button_BitFour.Text = Convert.ToString(strHex[3]);
                    button_BitFive.Text = Convert.ToString(strHex[2]);
                    button_BitSix.Text = Convert.ToString(strHex[1]);
                    button_BitSeven.Text = Convert.ToString(strHex[0]);
                    break;
                case 3:
                    button_BitEight.Text = Convert.ToString(strHex[3]);
                    button_BitNine.Text = Convert.ToString(strHex[2]);
                    button_BitTen.Text = Convert.ToString(strHex[1]);
                    button_BitEleven.Text = Convert.ToString(strHex[0]);
                    break;
                case 4:
                    button_BitTwelve.Text = Convert.ToString(strHex[3]);
                    button_BitThirteen.Text = Convert.ToString(strHex[2]);
                    button_BitFourteen.Text = Convert.ToString(strHex[1]);
                    button_BitFifteen.Text = Convert.ToString(strHex[0]);
                    break;
                default:
                    break;
            }
        }
       
        private void getBit(string strNum)
        {
            int[] arrBit = new int[4];
            int[] arrBit1 = new int[4];
            int[] arrBit2 = new int[4];
            int[] arrBit3 = new int[4];
            int[] arrBit4 = new int[4];

            int ntemp1;
            int ntemp2;
            int ntemp3;
            int ntemp4;
            int nDec;

            string strHex;
            string strHex1;
            string strHex2;
            string strHex3;
            string strHex4;

            string nHex1;
            string nHex2;
            string nHex3;
            string nHex4;

            switch (m_etype)
            {
                case eTYPE.HEX:

                    strHex= string.Format("{0:X}", strNum);
                    strHex = strHex.PadLeft(8, '0');
                    strHex = strHex.Substring(4, 4);

                    if (strHex.Length == 1)
                    {
                        ntemp4=Convert.ToInt32(strHex, 16);
                        nHex4 =Convert.ToString(ntemp4, 2);
                        nHex4 = nHex4.PadLeft(4, '0');    

                        SetByte(1, nHex4);
                        SetByte(2, "0");
                        SetByte(3, "0");
                        SetByte(4, "0");
                    }
                    else if (strHex.Length == 2)
                    {
                        strHex4 = strHex.ToString().Substring(strHex.ToString().Length - 1, 1);
                        ntemp4 = Convert.ToInt32(strHex4, 16);
                        nHex4 = Convert.ToString(ntemp4, 2);
                        nHex4 = nHex4.PadLeft(4, '0');

                        strHex3 = strHex.ToString().Substring(strHex.ToString().Length - 2, 1);
                        ntemp3 = Convert.ToInt32(strHex3, 16);
                        nHex3 = Convert.ToString(ntemp3, 2);
                        nHex3 = nHex3.PadLeft(4, '0');

                        SetByte(1, nHex4);
                        SetByte(2, nHex3);
                        SetByte(3, "0");
                        SetByte(4, "0");
                    }
                    else if (strHex.Length == 3)
                    {
                        strHex4 = strHex.ToString().Substring(strHex.ToString().Length - 1, 1);
                        ntemp4 = Convert.ToInt32(strHex4, 16);
                        nHex4 = Convert.ToString(ntemp4, 2);
                        nHex4 = nHex4.PadLeft(4, '0');

                        strHex3 = strHex.ToString().Substring(strHex.ToString().Length - 2, 1);
                        ntemp3 = Convert.ToInt32(strHex3, 16);
                        nHex3 = Convert.ToString(ntemp3, 2);
                        nHex3 = nHex3.PadLeft(4, '0');

                        strHex2 = strHex.ToString().Substring(strHex.ToString().Length - 3, 1);
                        ntemp2 = Convert.ToInt32(strHex2, 16);
                        nHex2 = Convert.ToString(ntemp2, 2);
                        nHex2 = nHex2.PadLeft(4, '0');

                        SetByte(1, nHex4);
                        SetByte(2, nHex3);
                        SetByte(3, nHex2);
                        SetByte(4, "0");
                    }
                    else if(strHex.Length==4)
                    {
                        strHex4 = strHex.ToString().Substring(strHex.ToString().Length - 1, 1);
                        ntemp4 = Convert.ToInt32(strHex4, 16);
                        nHex4 = Convert.ToString(ntemp4, 2);
                        nHex4 = nHex4.PadLeft(4, '0');

                        strHex3 = strHex.ToString().Substring(strHex.ToString().Length - 2, 1);
                        ntemp3 = Convert.ToInt32(strHex3, 16);
                        nHex3 = Convert.ToString(ntemp3, 2);
                        nHex3 = nHex3.PadLeft(4, '0');

                        strHex2 = strHex.ToString().Substring(strHex.ToString().Length - 3, 1);
                        ntemp2 = Convert.ToInt32(strHex2, 16);
                        nHex2 = Convert.ToString(ntemp2, 2);
                        nHex2 = nHex2.PadLeft(4, '0');

                        strHex1 = strHex.ToString().Substring(strHex.ToString().Length - 4, 1);
                        ntemp1 = Convert.ToInt32(strHex1, 16);
                        nHex1 = Convert.ToString(ntemp1, 2);
                        nHex1 = nHex1.PadLeft(4, '0');

                        SetByte(1, nHex4);
                        SetByte(2, nHex3);
                        SetByte(3, nHex2);
                        SetByte(4, nHex1);
                    }
                    else
                    {
                        return;
                    }
                    break;

                case eTYPE.DECIMAL:

                    nDec = Convert.ToInt32(strNum.Replace(",", ""));
                    strHex = nDec.ToString("X");
                    strHex = strHex.PadLeft(8, '0');
                    strHex = strHex.Substring(4, 4);

                    if (strHex.Length == 1)
                    {
                        ntemp4 = Convert.ToInt32(strHex, 16);
                        nHex4 = Convert.ToString(ntemp4, 2);
                        nHex4 = nHex4.PadLeft(4, '0');

                        SetByte(1, nHex4);
                    }
                    else if (strHex.Length == 2)
                    {
                        strHex4 = strHex.ToString().Substring(strHex.ToString().Length - 1, 1);
                        ntemp4 = Convert.ToInt32(strHex4, 16);
                        nHex4 = Convert.ToString(ntemp4, 2);
                        nHex4 = nHex4.PadLeft(4, '0');

                        strHex3 = strHex.ToString().Substring(strHex.ToString().Length - 2, 1);
                        ntemp3 = Convert.ToInt32(strHex3, 16);
                        nHex3 = Convert.ToString(ntemp3, 2);
                        nHex3 = nHex3.PadLeft(4, '0');

                        SetByte(1, nHex4);
                        SetByte(2, nHex3);
                    }
                    else if (strHex.Length == 3)
                    {
                        strHex4 = strHex.ToString().Substring(strHex.ToString().Length - 1, 1);
                        ntemp4 = Convert.ToInt32(strHex4, 16);
                        nHex4 = Convert.ToString(ntemp4, 2);
                        nHex4 = nHex4.PadLeft(4, '0');

                        strHex3 = strHex.ToString().Substring(strHex.ToString().Length - 2, 1);
                        ntemp3 = Convert.ToInt32(strHex3, 16);
                        nHex3 = Convert.ToString(ntemp3, 2);
                        nHex3 = nHex3.PadLeft(4, '0');

                        strHex2 = strHex.ToString().Substring(strHex.ToString().Length - 3, 1);
                        ntemp2 = Convert.ToInt32(strHex2, 16);
                        nHex2 = Convert.ToString(ntemp2, 2);
                        nHex2 = nHex2.PadLeft(4, '0');

                        SetByte(1, nHex4);
                        SetByte(2, nHex3);
                        SetByte(3, nHex2);
                    }
                    else if (strHex.Length == 4)
                    {
                        strHex4 = strHex.ToString().Substring(strHex.ToString().Length - 1, 1);
                        ntemp4 = Convert.ToInt32(strHex4, 16);
                        nHex4 = Convert.ToString(ntemp4, 2);
                        nHex4 = nHex4.PadLeft(4, '0');

                        strHex3 = strHex.ToString().Substring(strHex.ToString().Length - 2, 1);
                        ntemp3 = Convert.ToInt32(strHex3, 16);
                        nHex3 = Convert.ToString(ntemp3, 2);
                        nHex3 = nHex3.PadLeft(4, '0');

                        strHex2 = strHex.ToString().Substring(strHex.ToString().Length - 3, 1);
                        ntemp2 = Convert.ToInt32(strHex2, 16);
                        nHex2 = Convert.ToString(ntemp2, 2);
                        nHex2 = nHex2.PadLeft(4, '0');

                        strHex1 = strHex.ToString().Substring(strHex.ToString().Length - 4, 1);
                        ntemp1 = Convert.ToInt32(strHex1, 16);
                        nHex1 = Convert.ToString(ntemp1, 2);
                        nHex1 = nHex1.PadLeft(4, '0');   
                        
                        SetByte(1, nHex4);
                        SetByte(2, nHex3);
                        SetByte(3, nHex2);
                        SetByte(4, nHex1);
                    }
                    else
                    {
                        return;
                    }
                    break;
            }
        }

        private int Lsh_Opt(int nPri, int nSec)
        {
            string strResult;
            string strBinPri;

            int[] arrHex = new int[16];

            strBinPri = Convert.ToString(nPri, 2);
            strBinPri = strBinPri.PadLeft(16, '0');

            for (int nNum = 0; nNum <= arrHex.Length-1; nNum++)
            {
                arrHex[nNum] = Convert.ToInt32(strBinPri[nNum] - '0');
            }

            if (m_eshift == eShift.LOGICAL)
            {
                for (int nNum = 0; nNum <= arrHex.Length - 1; nNum++)
                {
                    try
                    {
                        arrHex[nNum] = arrHex[nNum + nSec];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        arrHex[nNum] = 0;
                    }
                }
            }
            else
            {
                for (int nNum = 0; nNum < arrHex.Length - 1; nNum++)
                {
                    try
                    {
                        arrHex[nNum] = arrHex[nNum + nSec];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        arrHex[nNum] = arrHex[0];
                    }
                }
            }

            strResult = string.Join("", arrHex);
            SetBit(arrHex);

            if (m_etype==eTYPE.HEX)
            {
                getBit(Convert.ToInt32(strResult, 2).ToString("X"));
            }
            else
            {
                getBit(Convert.ToInt32(strResult, 2).ToString());
            }
           
            return Convert.ToInt32(strResult, 2);
        }
        private int Rsh_Opt(int nPri, int nSec)
        {  
            
            int[] arrHex = new int[16];

            string strResult;
            string strBinPri;

            strBinPri = Convert.ToString(nPri, 2);
            strBinPri = strBinPri.PadLeft(16, '0');

            for (int nNum = 0; nNum < arrHex.Length; nNum++)
            {
                arrHex[nNum] = Convert.ToInt32(strBinPri[nNum]-'0');
            }

            if (m_eshift == eShift.LOGICAL)
            {
                for (int nNum = arrHex.Length - 1; nNum >= 0; nNum--)
                {
                    try
                    {
                        arrHex[nNum] = arrHex[nNum - nSec];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        arrHex[nNum] = 0;
                    }
                }
            }
            else
            {
                for (int nNum = arrHex.Length - 1; nNum > 0; nNum--)
                {
                    try
                    {
                        arrHex[nNum] = arrHex[nNum - nSec];
                        
                    }
                    catch (IndexOutOfRangeException)
                    {
                        arrHex[nNum] = arrHex[0];
                    }
                }
            }

            strResult = string.Join("", arrHex);

            if (m_etype==eTYPE.HEX)
            {
                getBit(Convert.ToInt32(strResult, 2).ToString("X"));
            }
            else
            {
                getBit(Convert.ToInt32(strResult, 2).ToString());
            }

            SetBit(arrHex);

            return Convert.ToInt32(strResult,2);
        }

        private int Not_Opt(int nSec)
        {
            string strResult;
            string strBinPri;

            int[] arrHex = new int[16];

            strBinPri = Convert.ToString(nSec, 2);
            strBinPri = strBinPri.PadLeft(16, '0');

            for (int nNum = 0; nNum < arrHex.Length-1; nNum++)
            {
                arrHex[nNum] = Convert.ToInt32(strBinPri[nNum] - '0');
            }

            for(int nNum=0; nNum <= arrHex.Length - 1;nNum++)
            {
                if (arrHex[nNum] == 0)
                {
                    arrHex[nNum] = 1;
                }
                else
                {
                    arrHex[nNum] = 0;
                }
            }

            strResult = string.Join("", arrHex);

            SetBit(arrHex);
            if (m_etype == eTYPE.HEX)
            {
                getBit(Convert.ToInt32(strResult, 2).ToString("X"));
            }
            else
            {
                getBit(Convert.ToInt32(strResult, 2).ToString());
            }

            return Convert.ToInt32(strResult, 2);
        }

        private void button_HexClick(object sender, EventArgs e)//16진수 버튼 클릭(10진수 모드 On)
        {
            m_etype = eTYPE.HEX;

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

            button_Hex.FlatAppearance.BorderColor = Color.Blue;
            button_Dec.FlatAppearance.BorderColor = Color.Gray;
            this.richTextBox_Memory.Text = "";
            this.richTextBox_Number.Text = this.label_Hex.Text;
        }

        private void button_DecClick(object sender, EventArgs e) //10진수 버튼 클릭(10진수 모드 On)
        {
            m_etype = eTYPE.DECIMAL;
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

            button_Hex.FlatAppearance.BorderColor = Color.Gray;
            button_Dec.FlatAppearance.BorderColor = Color.Blue;
            this.richTextBox_Memory.Text = "";
            this.richTextBox_Number.Text = this.label_Dec.Text;
        }

        private void Button_NumberClick(object sender, EventArgs e) //계산기 버튼 누를시 실행
        {
            if (m_bCompleteFlag == true)
            {
                m_bCompleteFlag = false;
            }

            if (this.richTextBox_Number.Text == "0" || m_bOperatorFlag ||m_bCompleteFlag) this.richTextBox_Number.Clear();

            Button button = (Button)sender;
            m_bOperatorFlag = false;
            m_strNumber = this.richTextBox_Number.Text + button.Text;
            m_strNumber = m_strNumber.Replace(",", "");

            if (m_strNumber.Length >= 6)
            {
                return;
            }

            getBit(m_strNumber);

            switch (m_etype)
            {
                case eTYPE.HEX:

                    m_strHexNumber = string.Format("{0:X}", m_strNumber);

                    if (m_strHexNumber.Length > 4)
                    {
                        return;
                    }

                    m_nNumber = Convert.ToInt32(m_strHexNumber,16);
                    m_nSnumber = Convert.ToInt32(m_nNumber);

                    if (m_nSnumber > short.MaxValue)
                    {
                        m_nSnumber = m_nSnumber - (short.MaxValue - short.MinValue) - 1;
                    }

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

                    break;

                case eTYPE.DECIMAL:

                    m_nNumber = Convert.ToInt32(m_strNumber);

                    if (m_nNumber > short.MaxValue)
                    {
                        m_nNumber = Convert.ToInt32(m_nNumber.ToString().Remove(m_nNumber.ToString().Length - 1));
                        return;
                    }
                    
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

        public void button_OperateClick(object sender, EventArgs e) //연산자 버튼 클릭 한번 누르면 연산자 등록후 두번누르면 기존에 저장되있던 연산자 실행
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
                    if (button.Text == "(")
                    {
                        this.richTextBox_Memory.Text = button.Text;
                    }
                    else
                    {
                        this.richTextBox_Memory.Text = "0" + button.Text;
                        this.m_strOperate = button.Text;
                        m_nFnum = 0;
                    }
                    return;
                }
                if (this.m_bCompleteFlag == true)
                {
                    this.m_strOperate = button.Text;
                    if (m_etype==eTYPE.HEX)
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
                
                if (m_etype==eTYPE.HEX)
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

            if (m_etype==eTYPE.HEX)
            {
                m_nSnum = Convert.ToInt32(richTextBox_Number.Text,16);
            }
            else{
                m_nSnum = int.Parse(richTextBox_Number.Text.Replace(",",""));
            }
            

            if (m_bEqualFlag == false)
            {
                if (m_etype==eTYPE.HEX)
                {
                    if (this.m_strOperate != "NOT")
                    {
                        this.richTextBox_Memory.Text += m_nSnum.ToString("X") + button.Text;
                    }
                }
                else
                {
                    if (this.m_strOperate != "NOT")
                    {
                        this.richTextBox_Memory.Text += m_nSnum + button.Text;
                    }
                }
                
            }
            else
            {
                if (m_etype==eTYPE.HEX)
                {
                    if (this.m_strOperate != "NOT")
                    {
                        this.richTextBox_Memory.Text += m_nSnum.ToString("X") + button.Text;
                    }
                }
                else
                {
                    if (this.m_strOperate != "NOT")
                    {
                        this.richTextBox_Memory.Text += m_nSnum + button.Text;
                    }
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

                    m_nRnum = Not_Opt(m_nSnum);

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
                    m_nRnum = Lsh_Opt(m_nFnum, m_nSnum);
                    
                    break;
                case ">>":
                    m_nRnum = Rsh_Opt(m_nFnum, m_nSnum);
                    
                    break;
                default:
                    break;

            }

            if (m_nRnum > short.MaxValue)
            {
                m_nRnum = m_nRnum - (short.MaxValue - short.MinValue) - 1;
            }

            if (m_etype==eTYPE.HEX)
            {
                getBit(m_nRnum.ToString("X"));
            }
            else
            {
                getBit(m_nRnum.ToString());
            }
           
            printResult();
            m_nFnum = m_nRnum;
            m_nSnum = int.MinValue;
            m_strNumber = string.Empty;
            this.m_bCompleteFlag = true;
        }

        private void printResult() //계산 결과문 출력
        {
            if (m_etype==eTYPE.HEX)
            {
                this.richTextBox_Number.Text = m_nRnum.ToString("X");

                if (m_nRnum < 0)
                {
                    this.label_Hex.Text = m_nRnum.ToString("X").Substring(4, 4);
                }
                else
                {
                    this.label_Hex.Text = m_nRnum.ToString("X");
                }               

                if (m_nRnum >= 1000|| m_nRnum<=-1000)
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
                if (m_nRnum >= 1000 || m_nRnum <= -1000)
                {                    
                    this.label_Dec.Text = string.Format("{0:#,###}", m_nRnum);
                    if (m_nRnum > 0)
                    {
                        this.richTextBox_Number.Text = string.Format("{0:#,###}", m_nRnum);
                        this.label_Hex.Text = m_nRnum.ToString("X");
                    }
                    else
                    {
                        this.richTextBox_Number.Text = string.Format("{0:#,###}", m_nRnum);
                        this.label_Hex.Text = m_nRnum.ToString("X").Substring(4,4);
                    }                    
                }
                else
                {                    
                    this.label_Dec.Text = string.Format("{0:#,###}", m_nRnum);
                    if (m_nRnum > 0)
                    {
                        this.label_Hex.Text = m_nRnum.ToString("X");
                        this.richTextBox_Number.Text = m_nRnum.ToString();
                    }
                    else
                    {
                        this.label_Hex.Text = m_nRnum.ToString("X").Substring(4, 4);
                        this.richTextBox_Number.Text = m_nRnum.ToString();
                    }
                }
            }
        }

        private void button_BackClick(object sender, EventArgs e) //글자지우기
        {
            int nNum;
        
            if (richTextBox_Memory.Text != "0" && m_strOperate != "=" && richTextBox_Number.Text.Length > 0)
            {
                richTextBox_Number.Text=richTextBox_Number.Text.Remove(richTextBox_Number.Text.Length - 1);
            }
            else
            {
                richTextBox_Number.Text = "0";
                return;
            }

            if (m_etype==eTYPE.HEX)
            {
                try
                {
                    nNum = Convert.ToInt32(this.richTextBox_Number.Text, 16);
                }
                catch (ArgumentOutOfRangeException)
                {
                    nNum = 0;
                }

                m_nNumber = nNum;
                this.richTextBox_Number.Text = nNum.ToString("X");
                this.label_Hex.Text = nNum.ToString("X");

                if (nNum >= 1000)
                {
                    this.label_Dec.Text = string.Format("{0:#,###}", nNum);
                }
                else
                {
                    this.label_Dec.Text = nNum.ToString();
                }
            }
            else
            {
                try
                {
                    nNum = Convert.ToInt32(this.richTextBox_Number.Text.Replace(",", ""));
                }
                catch(FormatException )
                {
                    nNum = 0;
                }
                m_nNumber = nNum;

                if (nNum >= 1000)
                {
                    this.richTextBox_Number.Text = string.Format("{0:#,###}", nNum);
                    this.label_Dec.Text = string.Format("{0:#,###}", nNum);
                    this.label_Hex.Text = nNum.ToString("X");
                }
                else
                {
                    this.richTextBox_Number.Text = nNum.ToString();
                    this.label_Dec.Text = nNum.ToString();
                    this.label_Hex.Text = nNum.ToString("X");
                }
            }

            if (m_etype==eTYPE.HEX)
            {
                getBit(string.Format("{0:X}", richTextBox_Number.Text));
            }
            else
            {
                getBit(richTextBox_Number.Text);
            }

        }

        private void Button_CClick(object sender, EventArgs e) //계산기 데이터 삭제
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

            button_BitZero.Text = "0";
            button_BitOne.Text = "0";
            button_BitTwo.Text = "0";
            button_BitThree.Text = "0";

            button_BitFour.Text = "0";
            button_BitFive.Text = "0";
            button_BitSix.Text = "0";
            button_BitSeven.Text = "0";

            button_BitEight.Text = "0";
            button_BitNine.Text = "0";
            button_BitTen.Text = "0";
            button_BitEleven.Text = "0";

            button_BitTwelve.Text = "0";
            button_BitThirteen.Text = "0";
            button_BitFourteen.Text = "0";
            button_BitFifteen.Text = "0";
        }

        private void button_PnClick(object sender, EventArgs e) //양수 음수 변환
        {
            if (m_nNumber == int.MinValue)
            {
                return;
            }
            else
            {               
                m_nNumber = m_nNumber * (-1);

                if (m_nNumber < 0)
                {
                     this.label_Hex.Text = m_nNumber.ToString("X");
                     this.label_Hex.Text = this.label_Hex.Text.PadLeft(8, '0');
                     this.label_Hex.Text = this.label_Hex.Text.Substring(4, 4);
                }
                else
                {
                    this.label_Hex.Text = m_nNumber.ToString("X");
                }

                if (m_nNumber >= 1000 || m_nNumber <= -1000)
                {
                     this.richTextBox_Number.Text = string.Format("{0:#,###}", m_nNumber);
                     this.label_Dec.Text=string.Format("{0:#,###}", m_nNumber);
                }
                else
                {
                     this.richTextBox_Number.Text = m_nNumber.ToString();
                     this.label_Dec.Text = string.Format("{0:#,###}", m_nNumber);
                }

                if (m_etype==eTYPE.HEX)
                {
                    getBit(this.label_Hex.Text);
                }
                else
                {
                    getBit(m_nNumber.ToString());
                }
            }
        }

        private void Form_Sub_Load(object sender, EventArgs e) //프로그래머용 계산기 불러올시
        {
            switch (m_etype)
            {
                case eTYPE.HEX:
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

                    button_Hex.FlatAppearance.BorderColor = Color.Blue;
                    break;

                case eTYPE.DECIMAL:
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
                    button_Dec.FlatAppearance.BorderColor = Color.Blue;
                    break;

                default:
                    break;
            }
        }

        private void button_shiftClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (button.Text == "산술")
            {
                button.Text = "논리";
                m_eshift = eShift.LOGICAL;
            }
            else
            {
                button.Text = "산술";
                m_eshift = eShift.ARITHMETIC;
            }
        }
    }
}
